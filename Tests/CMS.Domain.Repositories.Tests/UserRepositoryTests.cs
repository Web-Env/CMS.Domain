﻿using CMS.Domain.Entities;
using CMS.Domain.Tests.Funcs;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CMS.Domain.Repositories.Tests
{
    [Trait("Category", "Unit")]
    public class UserRepositoryTests : RepositoryTestBase
    {
        private CMSContext _context;
        public UserRepositoryTests(RepositoryDatabaseFixture fixture) : base(fixture) {
            _context = GetContext();
        }

        [Fact]
        public async Task Test_UserRepository_GetById_ReturnsUser()
        {
            using(var context = _context)
            {
                //Arrange
                var user = await UserFunc.CreateOneUser(context);

                //Act
                var fetchedUser = await RepositoryManager.UserRepository.GetByIdAsync(user.Id);

                //Assert
                Assert.Equal(fetchedUser.Id, user.Id);
            }
        }

        //[Fact]
        //public async Task Test_UserRepository_GetManyById_ReturnsUsers()
        //{
        //    using (var context = _context)
        //    {
        //        //Arrange
        //        var fetchedIdsCorrect = true;
        //        var userIds = (await UserFunc.CreateManyUsers(context)).Select(u => u.Id);

        //        //Act
        //        var fetchedUserIds = (await RepositoryManager.UserRepository.GetManyByIdAsync(userIds)).Select(u => u.Id);
        //        foreach (var userId in userIds)
        //        {
        //            if (!fetchedUserIds.Contains(userId))
        //            {
        //                fetchedIdsCorrect = false;
        //            }
        //        }

        //        //Assert
        //        Assert.True(fetchedIdsCorrect);
        //    }

        //}
    }
}
