using DataServiceLib.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataServiceLib.DataServices
{
    public class BookMarkDS : IBookMarkDS
    {
        public bool AddMovieBookMark(string userName, string movieId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.AddMovieBookMark(userName, movieId);
            }
        }
        public bool RemoveMovieBookMark(string userName, string movieId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.RemoveMovieBookMark(userName, movieId);
            }
        }
        public bool AddNameBookMark(string userName, string personId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.AddNameBookMark(userName, personId);
            }
        }
        public bool RemoveNameBookMark(string userName, string personId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.RemoveNameBookMark(userName, personId);
            }
        }
        public IList<BookmarkMovies> GetUsersBookmarksTitles(string username, int page, int pagesize)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.bookmarkMovies.Where(u => u.UserName == username).Include(x => x.Movie).Skip(page * pagesize).Take(pagesize).ToList();
            }
        }

        public IList<BookmarkActors> GetUsersBookmarksActors(string username, int page, int pagesize)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.bookmarkActors.Where(u => u.UserName == username).Skip(page * pagesize).Take(pagesize).ToList();
            }
        }

        public BookmarkMovies isBookmarked(string userName, string movieId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.bookmarkMovies.Where(x => x.UserName == userName && x.MovieId == movieId).FirstOrDefault();
            }
        }
    }
}
