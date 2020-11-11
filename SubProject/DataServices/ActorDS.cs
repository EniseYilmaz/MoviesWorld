using SubProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.DataServices
{
    public class ActorDS : IActorDS
    {
        public IList<PopularActors> GetPopularActors()
        {
            using var ctx = new MoviesContext("host=rawdata.ruc.dk;db=raw10;uid=raw10;pwd=Y)oCi6U(");
            return ctx.PopularActors();
        }
    }
}
