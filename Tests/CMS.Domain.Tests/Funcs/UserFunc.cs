using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Domain.Tests.Funcs
{
    public static class UserFunc
    {
        public static async Task<User> CreateOneUser(CMSContext context)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Tester",
                LastName = "McTesterson",
                Email = "Tester.McTesterson@testing.com",
                Password = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
                IsAdmin = false,
                CreatedBy = Guid.Empty,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = Guid.Empty,
                LastUpdatedOn = DateTime.Now
            };

            context.Users.Add(user);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return user;
        }

        public static async Task<List<User>> CreateManyUsers(CMSContext context)
        {
            var users = new List<User> {
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Tester",
                    LastName = "McTesterson",
                    Email = "Tester.McTesterson@testing.com",
                    Password = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
                    IsAdmin = false,
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = Guid.Empty,
                    LastUpdatedOn = DateTime.Now
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Testson",
                    LastName = "McTestering",
                    Email = "Testson.McTestering@testing.com",
                    Password = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
                    IsAdmin = false,
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = Guid.Empty,
                    LastUpdatedOn = DateTime.Now
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Testy",
                    LastName = "McTester",
                    Email = "Testy.McTester@testing.com",
                    Password = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
                    IsAdmin = false,
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = Guid.Empty,
                    LastUpdatedOn = DateTime.Now
                }
            };

            context.Users.AddRange(users);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return users;
        }
    }
}
