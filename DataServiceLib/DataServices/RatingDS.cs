using DataServiceLib.Models;
using System.Linq;

namespace DataServiceLib.DataServices
{
    public class RatingDS : IRatingDS
    {
        public bool AddMovieRating(MovieRatingDto movieRaingDto)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.AddMovieRating(movieRaingDto);
            }
        }

        public bool RemoveMovieRating(MovieRatingDto movieRaingDto)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.RemoveMovieRating(movieRaingDto);
            }
        }

        public bool AddActorRating(ActorRatingDto actorRatingDto)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.AddActorRating(actorRatingDto);
            }
        }

        public bool RemoveActorRating(ActorRatingDto actorRatingDto)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.RemoveActorRating(actorRatingDto);
            }
        }

        public double GetRating(string id)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.GetRating(id);
            }
        }

        public RatingHistories getRatingByUser(string userName, string movieId)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.ratingHistories.Where(x => x.UserName == userName && x.MovieId == movieId).FirstOrDefault();
            }
        }

    }
}
