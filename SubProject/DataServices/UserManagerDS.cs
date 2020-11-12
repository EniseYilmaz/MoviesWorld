using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubProject.Models;

namespace SubProject.DataServices
{
    public class UserManagerDS: IUserManagerDS
    {
        
        public bool CreateUser(string username, string name, string email, string password)
        {
            MoviesContext ctx = new MoviesContext();
            return ctx.CreateUser(username, name, email, password);
        }
        public bool DeleteUser(string username, string email)
        {
            MoviesContext ctx = new MoviesContext();
            return ctx.DeleteUser(username, email);
        }

        public IList<User> GetAllUsers(int page, int pagesize)
        {
            MoviesContext ctx = new MoviesContext();
            return ctx.GetAllUsers().Skip(page * pagesize).Take(pagesize).ToList();
        }

        


    }
}
