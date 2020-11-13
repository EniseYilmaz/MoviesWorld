using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Models
{
    public class TitleRating
    {
        //Rating movies
        public string Username { get; set; }
        public string movieId { get; set; }
        public int MovieRating { get; set; }

    }

    public class NameRating
    {
        //Rating person (actors)
        public string Username { get; set; }
        public string personId { get; set; }
        public int ActorRating { get; set; }

    }
}