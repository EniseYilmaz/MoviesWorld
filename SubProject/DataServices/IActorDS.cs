using SubProject.Models;
using System.Collections.Generic;

namespace SubProject.DataServices
{
    public interface IActorDS
    {
        IList<PopularActors> GetPopularActors();
    }
}