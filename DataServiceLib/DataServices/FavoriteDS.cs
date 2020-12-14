using System.Collections.Generic;
using System.Linq;
using DataServiceLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLib.DataServices
{
    public class FavoriteDS : IFavoriteDS
    {
        public bool AddMovieFavorite(string userName, string movieId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.AddMovieFavorite(userName, movieId);
            }
        }
        public bool RemoveMovieFavorite(string userName, string movieId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.RemoveMovieFavorite(userName, movieId);
            }
        }

        public IList<UsersFavorite> GetUsersFavorites(string username, int page, int pagesize)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.favorites.Where(u => u.UserName == username).Include(x => x.Movie).Skip(page * pagesize).Take(pagesize).ToList();
            }
        }
        public UsersFavorite isFav(string userName, string movieId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.favorites.Where(x => x.UserName == userName && x.MovieId == movieId).FirstOrDefault();
            }
        }
    }
}
