using DataServiceLib.Models;

namespace DataServiceLib.DataServices
{
    public interface IRatingDS
    {
        bool AddActorRating(ActorRatingDto actorRatingDto);
        bool AddMovieRating(MovieRatingDto movieRaingDto);
        bool RemoveActorRating(ActorRatingDto actorRatingDto);
        bool RemoveMovieRating(MovieRatingDto movieRaingDto);
        double GetRating(string id);
        RatingHistories getRatingByUser(string userName, string movieId);
    }
}