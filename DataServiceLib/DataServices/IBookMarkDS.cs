using DataServiceLib.Models;
using System.Collections.Generic;
namespace DataServiceLib.DataServices
{
    public interface IBookMarkDS
    {
        bool AddMovieBookMark(string userName, string movieId);
        bool RemoveMovieBookMark(string userName, string movieId);
        bool AddNameBookMark(string userName, string personId);
        bool RemoveNameBookMark(string userName, string personId);
        IList<BookmarkMovies> GetUsersBookmarksTitles(string username, int page, int pagesize);
        IList<BookmarkActors> GetUsersBookmarksActors(string username, int page, int pagesize);
        BookmarkMovies isBookmarked(string userName, string movieId);

    }
}