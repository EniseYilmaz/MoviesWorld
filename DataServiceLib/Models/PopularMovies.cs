using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceLib.Models
{
    public class PopularMovies
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public float? Rating { get; set; }
        public int? NumVotes { get; set; }
        public string Poster { get; set; }

    }
}
