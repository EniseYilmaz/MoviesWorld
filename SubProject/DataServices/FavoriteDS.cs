using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
