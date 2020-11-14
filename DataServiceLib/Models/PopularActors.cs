using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceLib.Models
{
    public class PopularActors
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float? Rating { get; set; }
        public int? NumOfVotes { get; set; }
    }
}
