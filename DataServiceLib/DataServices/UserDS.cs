using DataServiceLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataServiceLib.DataServices
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

        public IList<User> GetUsers(int page, int pagesize)
        {
            using var ctx = new MoviesContext();
            return ctx.users.Skip(page * pagesize).Take(pagesize).ToList();
        }

        public bool Delete(string userName)
        {
            try
            {
                var user = ctx.users.Where(u => u.UserName == userName).FirstOrDefault();
                ctx.users.Remove(user);
                ctx.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;

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
