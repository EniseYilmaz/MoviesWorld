using DataServiceLib.Models;
using System.Collections.Generic;


namespace DataServiceLib.DataServices
{
    public interface IMoviesDS
    {
        IList<SimilarMovies> SimilarMovies(string movieTitle);
        IList<TitleBasics> GetMovie(string id);
        IList<TitleBasics> GetMovies(int page, int pagesize);
    }
}