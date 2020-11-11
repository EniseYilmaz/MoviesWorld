using SubProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.DataServices
{
    public class MoviesDS : IMoviesDS
    {
        private readonly MoviesContext ctx = new MoviesContext();
        public IList<SimilarMovies> SimilarMovies(string movieTitle)
        {
            return ctx.SimilarMovies(movieTitle);
        }
        public IList<TitleBasics> GetMovie(string id)
        {
            return ctx.titleBasics.Where(m => m.Id == id).ToList();
        }
    }
}
