﻿using CMS.Domain.Tests.Funcs;
using CMS.Domain.Tests.Helpers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CMS.Domain.Repositories.Tests
{
    [Trait("Category", "Unit")]
    public class UserRepositoryTests : RepositoryTestBase
    {
        public UserRepositoryTests(RepositoryDatabaseFixture fixture) : base(fixture) { }

        [Fact]
        public async Task GetById_ShouldReturnSingleUser()
        {
            using(var context = NewContext())
            {
                //Arrange
                var user = await UserFunc.CreateOneUser(context);

                //Act
                var fetchedUser = await RepositoryManager.UserRepository.GetByIdAsync(user.Id);

                //Assert
                Assert.Equal(user.Id, fetchedUser.Id);
            }
        }

        [Fact]
        public async Task GetManyById_ShouldReturnManyUsers()
        {
            using (var context = NewContext())
            {
                //Arrange
                var fetchedIdsCorrect = true;
                var userIds = (await UserFunc.CreateManyUsers(context)).Select(u => u.Id);

                //Act
                var fetchedUserIds = (await RepositoryManager.UserRepository.GetManyByIdAsync(userIds)).Select(u => u.Id);
                foreach (var userId in userIds)
                {
                    if (!fetchedUserIds.Contains(userId))
                    {
                        fetchedIdsCorrect = false;
                    }
                }

                //Assert
                Assert.True(fetchedIdsCorrect);
            }
        }

        [Fact]
        public async Task GetPage_ShouldReturnUsers()
        {
            using (var context = NewContext())
            {
                //Arrange
                var fetchedIdsCorrect = true;
                var userIds = (await UserFunc.CreateUsersPage(context)).Select(u => u.Id);

                //Act
                var fetchedUserIds = (await RepositoryManager.UserRepository.GetPageAsync(0, 25)).Select(u => u.Id);
                foreach (var userId in userIds)
                {
                    if (!fetchedUserIds.Contains(userId))
                    {
                        fetchedIdsCorrect = false;
                    }
                }

                //Assert
                Assert.True(fetchedIdsCorrect);
            }
        }

        [Fact]
        public async Task Find_ShouldReturnSingleUser()
        {
            using (var context = NewContext())
            {
                //Arrange
                var user = (await UserFunc.CreateOneUser(context));

                //Act
                var fetchedUser = await RepositoryManager.UserRepository.FindAsync(u => u.Id == user.Id);

                //Assert
                Assert.Equal(user.Id, fetchedUser.FirstOrDefault().Id);
            }
        }

        [Fact]
        public async Task Find_ShouldReturnManyUsers()
        {
            using (var context = NewContext())
            {
                //Arrange
                var fetchedIdsCorrect = true;
                var userIds = (await UserFunc.CreateManyUsers(context)).Select(u => u.Id);

                //Act
                var fetchedUserIds = (await RepositoryManager.UserRepository.FindAsync(u => userIds.Contains(u.Id))).Select(u => u.Id);
                foreach (var userId in userIds)
                {
                    if (!fetchedUserIds.Contains(userId))
                    {
                        fetchedIdsCorrect = false;
                    }
                }

                //Assert
                Assert.True(fetchedIdsCorrect);
            }
        }

        [Fact]
        public async Task Add_ShouldCreateSingleUser()
        {
            using (var context = NewContext())
            {
                //Arrange
                var user = UserHelper.CreateOneUserObject();

                //Act
                await RepositoryManager.UserRepository.AddAsync(user);
                var fetchedUser = await UserFunc.GetUserById(context, user.Id);

                //Assert
                Assert.NotNull(fetchedUser);
            }
        }

        [Fact]
        public async Task AddRange_ShouldCreateMultipleUsers()
        {
            using (var context = NewContext())
            {
                //Arrange
                var fetchedIdsCorrect = true;
                var users = UserHelper.CreateManyUserObjects();

                //Act
                await RepositoryManager.UserRepository.AddRangeAsync(users);
                var userIds = users.Select(u => u.Id);
                var fetchedUserIds = (await UserFunc.GetManyUsersById(context, userIds)).Select(u => u.Id);
                foreach (var userId in userIds)
                {
                    if (!fetchedUserIds.Contains(userId))
                    {
                        fetchedIdsCorrect = false;
                    }
                }

                //Assert
                Assert.True(fetchedIdsCorrect);
            }
        }

        [Fact]
        public async Task Update_ShouldUpdateSingleUser()
        {
            using (var context = NewContext())
            {
                //Arrange
                var user = await UserFunc.CreateOneUser(context);
                var newUserFirstName = "New Tester";
                user.FirstName = newUserFirstName;

                //Act
                await RepositoryManager.UserRepository.UpdateAsync(user);
                var fetchedUser = await UserFunc.GetUserById(context, user.Id);

                //Assert
                Assert.Equal(newUserFirstName, fetchedUser.FirstName);
            }
        }

        [Fact]
        public async Task UpdateRange_ShouldUpdateMultipleUsers()
        {
            using (var context = NewContext())
            {
                //Arrange
                var fetchedNamesCorrect = true;
                var users = await UserFunc.CreateManyUsers(context);
                foreach(var user in users)
                {
                    user.FirstName = $"{user.FirstName} Updated";
                }

                //Act
                await RepositoryManager.UserRepository.UpdateRangeAsync(users);
                var userIds = users.Select(u => u.Id);
                var userFirstNames = users.Select(u => u.FirstName);
                var fetchedUserFirstNames = (await UserFunc.GetManyUsersById(context, userIds)).Select(u => u.FirstName);
                foreach (var userFirstName in userFirstNames)
                {
                    if (!fetchedUserFirstNames.Contains(userFirstName))
                    {
                        fetchedNamesCorrect = false;
                    }
                }

                //Assert
                Assert.True(fetchedNamesCorrect);
            }
        }

        [Fact]
        public async Task Remove_ShouldRemoveSingleUser()
        {
            using (var context = NewContext())
            {
                //Arrange
                var user = await UserFunc.CreateOneUser(context);

                //Act
                await RepositoryManager.UserRepository.RemoveAsync(user);
                var fetchedUser = await RepositoryManager.UserRepository.GetByIdAsync(user.Id);

                //Assert
                Assert.Null(fetchedUser);
            }
        }

        [Fact]
        public async Task RemoveById_ShouldRemoveSingleUser()
        {
            using (var context = NewContext())
            {
                //Arrange
                var user = await UserFunc.CreateOneUser(context);

                //Act
                await RepositoryManager.UserRepository.RemoveByIdAsync(user.Id);
                var fetchedUser = await RepositoryManager.UserRepository.GetByIdAsync(user.Id);

                //Assert
                Assert.Null(fetchedUser);
            }
        }

        [Fact]
        public async Task RemoveRange_ShouldRemoveMultipleUsers()
        {
            using (var context = NewContext())
            {
                //Arrange
                var users = await UserFunc.CreateManyUsers(context);
                var userIds = users.Select(u => u.Id);

                //Act
                await RepositoryManager.UserRepository.RemoveRangeAsync(users);
                var fetchedUser = await RepositoryManager.UserRepository.GetManyByIdAsync(userIds);

                //Assert
                Assert.Empty(fetchedUser);
            }
        }

        [Fact]
        public async Task RemoveRangeById_ShouldRemoveMultipleUsers()
        {
            using (var context = NewContext())
            {
                //Arrange
                var users = await UserFunc.CreateManyUsers(context);
                var userIds = users.Select(u => u.Id);

                //Act
                await RepositoryManager.UserRepository.RemoveRangeByIdAsync(userIds);
                var fetchedUser = await RepositoryManager.UserRepository.GetManyByIdAsync(userIds);

                //Assert
                Assert.Empty(fetchedUser);
            }
        }
    }
}
