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
        private readonly User _user;

        public AuditLogRepositoryTests(RepositoryDatabaseFixture fixture) : base(fixture)
        {
            _user = AsyncContext.Run(() => UserFunc.CreateOneUser(NewContext()));
        }

        [Fact]
        public async Task GetById_ShouldReturnSingleAuditLog()
        {
            using (var context = NewContext())
            {
                //Arrange
                System.Diagnostics.Debug.WriteLine("\n");
                System.Diagnostics.Debug.WriteLine(_user.Id);
                System.Diagnostics.Debug.WriteLine("\n");
                var auditLog = await AuditLogFunc.CreateOneAuditLog(context, _user.Id);

                //Act
                var fetchedAuditLog = await RepositoryManager.AuditLogRepository.GetByIdAsync(_user.Id);

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
                var auditLogsIds = (await AuditLogFunc.CreateManyAuditLogs(context)).Select(a => a.Id);

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
