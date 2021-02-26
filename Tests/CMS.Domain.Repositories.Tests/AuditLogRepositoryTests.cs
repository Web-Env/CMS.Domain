using CMS.Domain.Entities;
using CMS.Domain.Tests.Funcs;
using Nito.AsyncEx;
using Xunit;

namespace CMS.Domain.Repositories.Tests
{
    [Trait("Category", "Unit")]
    public class AuditLogRepositoryTests : RepositoryTestBase
    {
        private readonly User _user;

        public AuditLogRepositoryTests(RepositoryDatabaseFixture fixture) : base(fixture)
        {
            _user = AsyncContext.Run(() => UserFunc.CreateOneUser(GetContext()));
        }
        


    }
}
