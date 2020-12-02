using DataServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceLib.DataServices
{
    public class ActorDS : IActorDS
    {
        private readonly MoviesContext ctx = new MoviesContext();
        public IList<PopularActors> GetPopularActors()
        {
            return ctx.PopularActors();
        }

        public IList<Title_Principals> GetPersonal(string id)
        {
            return ctx.GetPersonal(id);
        }
    }
}
