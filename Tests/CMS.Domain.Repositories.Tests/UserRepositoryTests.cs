using CMS.Domain.Tests.Funcs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace CMS.Domain.Repositories.Tests
{
    [Trait("Category", "Unit")]
    public class UserRepositoryTests : RepositoryTestBase
    {
        public UserRepositoryTests(RepositoryDatabaseFixture fixture) : base(fixture) { }

        [Fact]
        public async Task Test_UserRepository_GetById_ReturnsUser()
        {
            using(var context = GetContext())
            {
                await InvokeFuncsAsync(
                    UserFunc.CreateOneUser
                );

                var user = await context.Users.FirstOrDefaultAsync();

                Assert.NotNull(await RepositoryManager.UserRepository.GetByIdAsync(user.Id));
            }
            
        }
    }
}
