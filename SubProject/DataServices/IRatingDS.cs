using System;
using System.Collections.Generic;
using SubProject.Models;

namespace SubProject.DataServices
{
    public interface IRatingDS
    {
        //rating for movies
        bool AddMovieRating(TitleRating rating);
        bool RemoveMovieRating(string Username, string movieId, int MovieRating);
        bool UpdateMovieRating(string Username, string movieId, int MovieRating);


        //rating persons (actors)
        bool AddActorRating(NameRating rating);
        bool RemoveActorRating(string Username, string personId, int MovieRating);
        bool UpdateActorRating(string Username, string personId, int MovieRating);
        
    }

}
