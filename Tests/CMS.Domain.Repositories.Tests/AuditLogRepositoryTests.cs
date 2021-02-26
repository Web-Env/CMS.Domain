using CMS.Domain.Entities;
using CMS.Domain.Tests.Funcs;
using Nito.AsyncEx;
using System;
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
            using (var context = NewContext())
            {
                //Arrange
                var user = await UserFunc.CreateOneUser(context);
                var auditLog = await AuditLogFunc.CreateOneAuditLog(context, user.Id);

                //Act
                var fetchedAuditLog = await RepositoryManager.AuditLogRepository.GetByIdAsync(auditLog.Id);

                //Assert
                Assert.Equal(auditLog.Id, fetchedAuditLog.Id);
            }
        }

        [Fact]
        public async Task GetManyById_ShouldReturnManyUsers()
        {
            using (var context = NewContext())
            {
                //Arrange
                var fetchedIdsCorrect = false;
                var user = await UserFunc.CreateOneUser(context);
                var auditLogsIds = (await AuditLogFunc.CreateManyAuditLogs(context, user.Id)).Select(a => a.Id);

                //Act
                var fetchedAuditLogsIds = (await RepositoryManager.AuditLogRepository.GetManyByIdAsync(auditLogsIds)).Select(a => a.Id);
                foreach (var auditLogsId in auditLogsIds)
                {
                    if (!fetchedAuditLogsIds.Contains(auditLogsId))
                    {
                        fetchedIdsCorrect = false;
                    }
                }

                //Assert
                Assert.True(fetchedIdsCorrect);
            }
        }



    }
}
