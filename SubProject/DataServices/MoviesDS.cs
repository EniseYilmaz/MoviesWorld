using SubProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.DataServices
{
    public class MoviesDS : IMoviesDS
    {
        public IList<SimilarMovies> SimilarMovies(string movieTitle)
        {
            using var ctx = new MoviesContext("host=rawdata.ruc.dk;db=raw10;uid=raw10;pwd=Y)oCi6U(");
            return ctx.SimilarMovies(movieTitle);
        }
        public IList<TitleBasics> GetMovie(string id)
        {
            using var ctx = new MoviesContext("host=rawdata.ruc.dk;db=raw10;uid=raw10;pwd=Y)oCi6U(");
            return ctx.titleBasics.Where(m => m.Id == id).ToList();
        }
    }
}
