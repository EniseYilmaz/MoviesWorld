using SubProject.Models;
using System.Collections.Generic;
namespace SubProject.DataServices
{
    public interface IBookMarkDS
    {
        bool AddMovieBookMark(string userName, string movieId);
        bool RemoveMovieBookMark(string userName, string movieId);
        bool AddNameBookMark(string userName, string personId);
        bool RemoveNameBookMark(string userName, string personId);
        IList<UserBookmarksTitles> GetUsersBookmarksTitles(string username, int page, int pagesize);
        IList<UserBookmarksActors> GetUsersBookmarksActors(string username, int page, int pagesize);

    }
}