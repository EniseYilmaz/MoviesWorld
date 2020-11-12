using SubProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.DataServices
{
    public class UserDS : IUserDS
    {
        private readonly MoviesContext ctx = new MoviesContext();

        public User GetUser(string userName)
        {
            return ctx.users.Where(u => u.UserName == userName).FirstOrDefault();
        }

        public User CreateUser(string userName, string name, string email, string password)
        {
            var user = new User
            {
                UserName = userName,
                Name = name,
                Email = email,
                Password = password
            };
            ctx.users.Add(user);
            ctx.SaveChanges();
            return user;
        }

        public bool IsValidUserCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return true;
        }

        public bool IsAnExistingUser(string userName)
        {
            var user = ctx.users.Where(u => u.UserName == userName).Count();
            if (user >= 1)
            {
                return true;
            }
            return false;
        }

    }
}
