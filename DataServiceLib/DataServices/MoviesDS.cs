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
        public TitleBasics GetMovie(string id)
        {
            return ctx.titleBasics.Where(m => m.Id == id).FirstOrDefault();
        }
        public IList<TitleBasics> GetMovies(int page, int pagesize)
        {
            return ctx.titleBasics.Skip(page * pagesize).Take(pagesize).ToList();
        }

        public OMBDdata GetOMBDData(string id)
        {

            return ctx.GetOMDBData(id);
        }
    }
}
