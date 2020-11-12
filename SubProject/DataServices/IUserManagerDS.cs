
using System.Collections.Generic;
using SubProject.Models;

namespace SubProject.DataServices
{
    public interface IUserManagerDS
    {
        public bool CreateUser(string username, string name, string email, string password);
        public bool DeleteUser(string username, string email);
        public IList<User> GetAllUsers(int page, int pagesize);
    }
}
