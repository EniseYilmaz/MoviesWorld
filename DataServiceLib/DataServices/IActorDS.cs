using DataServiceLib.Models;
using System.Collections.Generic;

namespace DataServiceLib.DataServices
{
    public interface IActorDS
    {
        IList<PopularActors> GetPopularActors();
    }
}