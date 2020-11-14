using DataServiceLib.Models;
using System.Collections.Generic;

namespace DataServiceLib.DataServices
{
    public interface IUserDS
    {
        User GetUser(string userName);
        User GetUser(int id);

        bool Delete(string userName);

        User CreateUser(string userName, string name, string email, string password, string salt);
        IList<User> GetUsers(int page, int pagesize);
    }
}