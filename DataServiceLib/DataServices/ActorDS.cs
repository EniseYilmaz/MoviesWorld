using DataServiceLib.Models;
using System.Collections.Generic;

namespace DataServiceLib.DataServices
{
    public class ActorDS : IActorDS
    {
        private readonly MoviesContext ctx = new MoviesContext();
        public IList<PopularActors> GetPopularActors()
        {
            return ctx.getPopularActors();
        }

        public IList<Title_Principals> GetPersonal(string id)
        {
            return ctx.GetPersonal(id);
        }
    }
}
