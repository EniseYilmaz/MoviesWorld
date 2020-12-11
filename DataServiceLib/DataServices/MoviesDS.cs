﻿using DataServiceLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataServiceLib.DataServices
{
    public class MoviesDS : IMoviesDS
    {
        private readonly MoviesContext ctx = new MoviesContext();
        public IList<SimilarMovies> SimilarMovies(string movieTitle)
        {
            return ctx.getSimilarMovies(movieTitle);
        }
        public TitleBasics GetMovie(string id)
        {
            return ctx.titleBasics.Where(m => m.Id == id).FirstOrDefault();
        }
        public IList<TitleBasics> GetMovies(int page, int pagesize)
        {
            return ctx.titleBasics.Skip(page * pagesize).Take(pagesize).ToList();
        }

        public OMDBData GetOMBDData(string id)
        {

            return ctx.OMDBDatas.Where(m => m.Id == id).FirstOrDefault();
        }

        public IList<PopularMovies> GetPopularMovies()
        {
            return ctx.getPopularMovies();
        }
    }
}
