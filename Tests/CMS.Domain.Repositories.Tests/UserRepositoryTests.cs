using CMS.Domain.Entities;
using CMS.Domain.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CMS.Domain.Repositories.Tests
{
    public class UserRepositoryTests : RepositoryTestBase
    {
        private IUserRepository GetInMemoryUserRepository()
        {
            var context = CreateTestContext();
            return new Repositories.UserRepository(context);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Test_UserRepository_GetsById_Async()
        {
            IUserRepository userRepository = GetInMemoryUserRepository();
            var userId = Guid.NewGuid();
            var user = new User()
            {
                Id = userId,
                FirstName = "Tester",
                LastName = "McTesterson",
                Email = "Tester.McTesterson@testing.com",
                IsAdmin = false,
                CreatedBy = Guid.Empty,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = Guid.Empty,
                LastUpdatedOn = DateTime.Now
            };

            user = await userRepository.AddOrUpdateAsync(user);

            Assert.NotNull(await userRepository.GetByIdAsync(user.Id));
        }
    }
}
