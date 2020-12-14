using DataServiceLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataServiceLib.DataServices
{
    public class MoviesDS : IMoviesDS
    {
        public IList<SimilarMovies> SimilarMovies(string movieTitle)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.getSimilarMovies(movieTitle);
            }
        }
        public TitleBasics GetMovie(string id)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.titleBasics.Where(m => m.Id == id).FirstOrDefault();
            }
        }
        public IList<TitleBasics> GetMovies(int page, int pagesize)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.titleBasics.Skip(page * pagesize).Take(pagesize).ToList();
            }
        }

        public OMDBData GetOMBDData(string id)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.OMDBDatas.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public IList<PopularMovies> GetPopularMovies()
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.getPopularMovies();
            }
        }
    }
}
