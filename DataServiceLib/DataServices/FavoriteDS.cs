using System.Collections.Generic;
using System.Linq;
using DataServiceLib.Models;

namespace DataServiceLib.DataServices
{
    public class FavoriteDS : IFavoriteDS
    {
        private readonly MoviesContext ctx = new MoviesContext();
        public bool AddMovieFavorite(string userName, string movieId)
        {
            return ctx.AddMovieFavorite(userName, movieId);
        }
        public bool RemoveMovieFavorite(string userName, string movieId)
        {
            return ctx.RemoveMovieFavorite(userName, movieId);
        }

        public IList<UsersFavorite> GetUsersFavorites(string username, int page, int pagesize)
        {
            return ctx.favorites.Where(u => u.UserName == username).Skip(page * pagesize).Take(pagesize).ToList();
        }
        public UsersFavorite isFav(string userName, string movieId)
        {
            return ctx.favorites.Where(x => x.UserName == userName && x.MovieId == movieId).FirstOrDefault();
        }
    }
}
