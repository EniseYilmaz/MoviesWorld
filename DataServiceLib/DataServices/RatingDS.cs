using DataServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceLib.DataServices
{
    public class RatingDS : IRatingDS
    {
        private readonly MoviesContext ctx = new MoviesContext();
        public bool AddMovieRating(MovieRatingDto movieRaingDto)
        {
            return ctx.AddMovieRating(movieRaingDto);
        }

        public bool RemoveMovieRating(MovieRatingDto movieRaingDto)
        {
            return ctx.RemoveMovieRating(movieRaingDto);
        }

        public bool AddActorRating(ActorRatingDto actorRatingDto)
        {
            return ctx.AddActorRating(actorRatingDto);
        }

        public bool RemoveActorRating(ActorRatingDto actorRatingDto)
        {
            return ctx.RemoveActorRating(actorRatingDto);
        }

    }
}
