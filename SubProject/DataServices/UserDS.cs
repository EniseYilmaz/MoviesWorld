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

        public User GetUser(int id)
        {
            return ctx.users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User CreateUser(string userName, string name, string email, string password, string salt)
        {
            var user = new User
            {
                UserName = userName,
                Name = name,
                Email = email,
                Password = password,
                Salt = salt
            };
            ctx.users.Add(user);
            ctx.SaveChanges();
            return user;
        }
    }
}
