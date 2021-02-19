using CMS.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CMS.Domain.Tests.Funcs
{
    public static class UserFunc
    {
        public static readonly Func<CMSContext, Task> CreateOneUser = async (context) =>
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
        };
    }
}
