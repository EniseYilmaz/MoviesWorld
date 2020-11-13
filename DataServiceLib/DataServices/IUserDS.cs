using SubProject.Models;

namespace SubProject.DataServices
{
    public interface IUserDS
    {
        User GetUser(string userName);
        User GetUser(int id);

        bool Delete(string userName);

        User CreateUser(string userName, string name, string email, string password, string salt);
    }
}