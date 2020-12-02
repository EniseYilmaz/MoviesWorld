using DataServiceLib.Models;
using System.Collections.Generic;

namespace DataServiceLib.DataServices
{
    public interface IActorDS
    {
        IList<PopularActors> GetPopularActors();
        IList<Title_Principals> GetPersonal(string id);
    }
}