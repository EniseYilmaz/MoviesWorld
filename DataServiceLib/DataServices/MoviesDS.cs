using DataServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceLib.DataServices
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
        public IList<TitleBasics> GetMovies(int page, int pagesize)
        {
            using var ctx = new MoviesContext();
            return ctx.titleBasics.Skip(page * pagesize).Take(pagesize).ToList();
        }
    }
}
