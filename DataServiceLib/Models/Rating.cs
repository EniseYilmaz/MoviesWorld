using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceLib.Models
{
    public class TitleRatingDto
    {
        //Rating movies
        public string Id { get; set; }
        public double AverageRating { get; set; }
        public int NumVotes { get; set; }

    }
    public class NameRatingDto
    {
        public string Id { get; set; }
        public double AverageRating { get; set; }
        public int NumVotes { get; set; }

    }

    public class UserTitleRatingDto
    {
        //Rating movies
        public string UserName { get; set; }
        public string MovieId { get; set; }
        public int MovieRating { get; set; }

    }

    public class UserNameRatingDto
    {
        //Rating person (actors)
        public string UserName { get; set; }
        public string PersonId { get; set; }
        public int ActorRating { get; set; }

    }
}