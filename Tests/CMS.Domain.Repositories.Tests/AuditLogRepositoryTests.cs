using CMS.Domain.Enums;
using CMS.Domain.Tests.Funcs;
using CMS.Domain.Tests.Helpers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CMS.Domain.Repositories.Tests
{
    [Trait("Category", "Unit")]
    public class AuditLogRepositoryTests : RepositoryTestBase
    {
        public AuditLogRepositoryTests(RepositoryDatabaseFixture fixture) : base(fixture) { }

        [Fact]
        public async Task GetById_ShouldReturnSingleAuditLog()
        {
            var context = NewContext();
            //Arrange
            var user = await UserFunc.CreateOneUser(context);
            var auditLog = await AuditLogFunc.CreateOneAuditLog(context, user.Id);

            //Act
            var fetchedAuditLog = await RepositoryManager.AuditLogRepository.GetByIdAsync(auditLog.Id);

            //Assert
            Assert.Equal(auditLog.Id, fetchedAuditLog.Id);
        }

        [Fact]
        public async Task GetManyById_ShouldReturnManyUsers()
        {
            using var context = NewContext();
            //Arrange
            var fetchedIdsCorrect = false;
            var user = await UserFunc.CreateOneUser(context);
            var auditLogIds = (await AuditLogFunc.CreateManyAuditLogs(context, user.Id)).Select(a => a.Id);

            //Act
            var fetchedAuditLogsIds = (await RepositoryManager.AuditLogRepository.GetManyByIdAsync(auditLogIds)).Select(a => a.Id);
            fetchedIdsCorrect = HelperBase.CheckListsMatch(auditLogIds.ToHashSet(), fetchedAuditLogsIds.ToHashSet());

            //Assert
            Assert.True(fetchedIdsCorrect);
        }

        [Fact]
        public async Task GetPage_ShouldReturnAuditLogs()
        {
            //Arrange
            using var context = NewContext();
            var fetchedIdsCorrect = true;
            var user = await UserFunc.CreateOneUser(context);
            var auditLogsIds = (await AuditLogFunc.CreateManyAuditLogs(context, user.Id)).Select(a => a.Id);

            //Act
            var fetchedAuditLogsIds = (await RepositoryManager.AuditLogRepository.GetPageAsync(0, 25)).Select(a => a.Id);
            fetchedIdsCorrect = HelperBase.CheckListsMatch(auditLogsIds.ToHashSet(), fetchedAuditLogsIds.ToHashSet());

            //Assert
            Assert.True(fetchedIdsCorrect);
        }


        [Fact]
        public async Task Find_ShouldReturnAuditLogUser()
        {
            //Arrange
            using var context = NewContext();
            var user = (await UserFunc.CreateOneUser(context));
            var auditLog = (await AuditLogFunc.CreateOneAuditLog(context, user.Id));

            //Act
            var fetchedAuditLog = await RepositoryManager.AuditLogRepository.FindAsync(a => a.Id == auditLog.Id);

            //Assert
            Assert.Equal(auditLog.Id, fetchedAuditLog.FirstOrDefault().Id);
        }

        [Fact]
        public async Task Find_ShouldReturnManyAuditLogs()
        {
            //Arrange
            using var context = NewContext();
            var fetchedIdsCorrect = true;
            var user = await UserFunc.CreateOneUser(context);
            var auditLogIds = (await AuditLogFunc.CreateManyAuditLogs(context, user.Id)).Select(a => a.Id);

            //Act
            var fetchedAuditLogIds = (await RepositoryManager.AuditLogRepository.FindAsync(a => auditLogIds.Contains(a.Id))).Select(a => a.Id);
            fetchedIdsCorrect = HelperBase.CheckListsMatch(auditLogIds.ToHashSet(), fetchedAuditLogIds.ToHashSet());

            //Assert
            Assert.True(fetchedIdsCorrect);
        }

        [Fact]
        public async Task Add_ShouldCreateAuditLog()
        {
            //Arrange
            using var context = NewContext();
            var user = await UserFunc.CreateOneUser(context);
            var auditLog = AuditLogHelper.CreateOneAuditLogObject(user.Id);

            //Act
            await RepositoryManager.AuditLogRepository.AddAsync(auditLog);
            var fetchedAuditLog = await AuditLogFunc.GetAuditLogById(context, auditLog.Id);

            //Assert
            Assert.NotNull(fetchedAuditLog);
        }

        [Fact]
        public async Task AddRange_ShouldCreateMultipleAuditLogs()
        {
            //Arrange
            using var context = NewContext();
            var fetchedIdsCorrect = true;
            var user = await UserFunc.CreateOneUser(context);
            var auditLogs = AuditLogHelper.CreateManyAuditLogObjects(user.Id);

            //Act
            await RepositoryManager.AuditLogRepository.AddRangeAsync(auditLogs);
            var auditLogIds = auditLogs.Select(a => a.Id);
            var fetchedAuditLogIds = (await AuditLogFunc.GetManyAuditLogsById(context, auditLogIds)).Select(a => a.Id);
            fetchedIdsCorrect = HelperBase.CheckListsMatch(auditLogIds.ToHashSet(), fetchedAuditLogIds.ToHashSet());

            //Assert
            Assert.True(fetchedIdsCorrect);
        }

        [Fact]
        public async Task Update_ShouldUpdateSingleAuditLog()
        {
            //Arrange
            using var context = NewContext();
            var user = await UserFunc.CreateOneUser(context);
            var auditLog = await AuditLogFunc.CreateOneAuditLog(context, user.Id);
            var newActionCategory = (short)UserActionCategory.Section;
            auditLog.ActionCategory = newActionCategory;

            //Act
            await RepositoryManager.AuditLogRepository.UpdateAsync(auditLog);
            var fetchedAuditLog = await AuditLogFunc.GetAuditLogById(context, auditLog.Id);

            //Assert
            Assert.Equal(newActionCategory, fetchedAuditLog.ActionCategory);
        }

        [Fact]
        public async Task UpdateRange_ShouldUpdateMultipleUsers()
        {
            //Arrange
            using var context = NewContext();
            var fetchedAuditLogCorrect = true;
            var user = await UserFunc.CreateOneUser(context);
            var auditLogs = await AuditLogFunc.CreateManyAuditLogs(context, user.Id);
            foreach (var auditLog in auditLogs)
            {
                auditLog.User.FirstName = $"{auditLog.User.FirstName} Updated";
            }

            //Act
            await RepositoryManager.AuditLogRepository.UpdateRangeAsync(auditLogs);
            var auditLogsIds = auditLogs.Select(a => a.Id);
            var auditLogsUserFirstNames = auditLogs.Select(a => a.User.FirstName);
            var fetchedAuditLogUserFirstNames = (await AuditLogFunc.GetManyAuditLogsById(context, auditLogsIds)).Select(a => a.User.FirstName);
            fetchedAuditLogCorrect = HelperBase.CheckListsMatch(auditLogsUserFirstNames.ToHashSet(), fetchedAuditLogUserFirstNames.ToHashSet());

            //Assert
            Assert.True(fetchedAuditLogCorrect);
        }

        [Fact]
        public async Task Remove_ShouldRemoveSingleAuditLog()
        {
            //Arrange
            using var context = NewContext();
            var user = await UserFunc.CreateOneUser(context);
            var auditLog = await AuditLogFunc.CreateOneAuditLog(context, user.Id);

            //Act
            await RepositoryManager.AuditLogRepository.RemoveAsync(auditLog);
            var fetchedAuditLog = await RepositoryManager.AuditLogRepository.GetByIdAsync(auditLog.Id);

            //Assert
            Assert.Null(fetchedAuditLog);
        }

        [Fact]
        public async Task RemoveById_ShouldRemoveSingleAuditLog()
        {
            //Arrange
            using var context = NewContext();
            var user = await UserFunc.CreateOneUser(context);
            var auditLog = await AuditLogFunc.CreateOneAuditLog(context, user.Id);

            //Act
            await RepositoryManager.AuditLogRepository.RemoveByIdAsync(auditLog.Id);
            var fetchedAuditLog = await RepositoryManager.AuditLogRepository.GetByIdAsync(auditLog.Id);

            //Assert
            Assert.Null(fetchedAuditLog);
        }

        [Fact]
        public async Task RemoveRange_ShouldRemoveMultipleAuditLogs()
        {
            //Arrange
            using var context = NewContext();
            var user = await UserFunc.CreateOneUser(context);
            var auditLogs = await AuditLogFunc.CreateManyAuditLogs(context, user.Id);
            var auditLogIds = auditLogs.Select(a => a.Id);

            //Act
            await RepositoryManager.AuditLogRepository.RemoveRangeAsync(auditLogs);
            var fetchedAuditLogs = await RepositoryManager.AuditLogRepository.GetManyByIdAsync(auditLogIds);

            //Assert
            Assert.Empty(fetchedAuditLogs);
        }

        [Fact]
        public async Task RemoveRangeById_ShouldRemoveMultipleAuditLogs()
        {
            //Arrange
            using var context = NewContext();
            var user = await UserFunc.CreateOneUser(context);
            var auditLogs = await AuditLogFunc.CreateManyAuditLogs(context, user.Id);
            var auditLogIds = auditLogs.Select(a => a.Id);

            //Act
            await RepositoryManager.AuditLogRepository.RemoveRangeByIdAsync(auditLogIds);
            var fetchedAuditLogs = await RepositoryManager.AuditLogRepository.GetManyByIdAsync(auditLogIds);

            //Assert
            Assert.Empty(fetchedAuditLogs);
        }
    }
}
