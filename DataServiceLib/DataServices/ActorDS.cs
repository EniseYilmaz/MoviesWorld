using SubProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.DataServices
{
    public class ActorDS : IActorDS
    {
        private readonly MoviesContext ctx = new MoviesContext();
        public IList<PopularActors> GetPopularActors()
        {
            return ctx.PopularActors();
        }
    }
}
