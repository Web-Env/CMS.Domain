using CMS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CMS.Domain.Tests.Helpers
{
    public static class UserHelper
    {
        public static User CreateOneUserObject(string name = "")
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = string.IsNullOrWhiteSpace(name) ? "Tester" : name,
                LastName = "McTesterson",
                Email = string.IsNullOrWhiteSpace(name) ? "Tester.McTesterson@testing.com" : $"{name}.McTesterson@testing.com",
                Password = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
                IsAdmin = false,
                CreatedBy = Guid.Empty,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = Guid.Empty,
                LastUpdatedOn = DateTime.Now
            };
        }

        public static List<User> CreateManyUserObjects()
        {
            return new List<User> {
                CreateOneUserObject("Tester"),
                CreateOneUserObject("Testson"),
                CreateOneUserObject("Testy")
            };
        }

        public static List<User> CreateUserPageObjects()
        {
            var users = new List<User>();

            for (var i = 0; i < 25; i++)
            {
                users.Add(CreateOneUserObject($"Tester{i}"));
            }

            return users;
        }


    }
}
