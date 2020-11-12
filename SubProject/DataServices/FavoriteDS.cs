using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubProject.Models;

namespace SubProject.DataServices
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
            return ctx.GetusersFavorites(username).Skip(page * pagesize).Take(pagesize).ToList();
        }
    }
}
