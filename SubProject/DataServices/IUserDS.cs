using SubProject.Models;

namespace SubProject.DataServices
{
    public interface IUserDS
    {
        User GetUser(string userName);
        User GetUser(int id);

        User CreateUser(string userName, string name, string email, string password, string salt);
    }
}