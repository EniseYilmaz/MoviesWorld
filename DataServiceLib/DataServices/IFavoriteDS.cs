using System.Collections.Generic;
using DataServiceLib.Models;
namespace DataServiceLib.DataServices
{
    public interface IFavoriteDS
    {
        bool AddMovieFavorite(string userName, string movieId);
        bool RemoveMovieFavorite(string userName, string movieId);
        IList<UsersFavorite> GetUsersFavorites(string username ,int page, int pagesize);
    }
}