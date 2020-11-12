using SubProject.Models;

namespace SubProject.DataServices
{
    public interface IUserDS
    {
        bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);

        User GetUser(string userName);

        User CreateUser(string userName, string name, string email, string password);
    }
}