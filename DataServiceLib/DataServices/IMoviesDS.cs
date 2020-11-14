using SubProject.Models;
using System.Collections.Generic;

namespace SubProject.DataServices
{
    public interface IMoviesDS
    {
        IList<SimilarMovies> SimilarMovies(string movieTitle);
        IList<TitleBasics> GetMovie(string id);
        IList<TitleBasics> GetMovies(int page, int pagesize);
    }
}