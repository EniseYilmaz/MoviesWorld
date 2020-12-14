using DataServiceLib.Models;
using System.Collections.Generic;

namespace DataServiceLib.DataServices
{
    public class ActorDS : IActorDS
    {
        public IList<PopularActors> GetPopularActors()
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.getPopularActors();
            }
        }

        public IList<Title_Principals> GetPersonal(string id)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.GetPersonal(id);
            }
        }
    }
}
