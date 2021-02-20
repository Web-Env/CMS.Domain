using CMS.Domain.Entities;
using CMS.Domain.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Domain.Tests.Funcs
{
    public static class UserFunc
    {
        public static async Task<User> GetUserById(CMSContext context, Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public static async Task<List<User>> GetManyUsersById(CMSContext context, IEnumerable<Guid> ids)
        {
            return await context.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
        }

        public static async Task<User> CreateOneUser(CMSContext context)
        {
            var user = UserHelper.CreateOneUserObject();

            context.Users.Add(user);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return user;
        }

        public static async Task<List<User>> CreateManyUsers(CMSContext context)
        {
            var users = UserHelper.CreateManyUserObjects();

            context.Users.AddRange(users);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return users;
        }

        public static async Task<List<User>> CreateUsersPage(CMSContext context)
        {
            var users = UserHelper.CreateUserPageObjects();

            context.Users.AddRange(users);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return users;
        }
    }
}
