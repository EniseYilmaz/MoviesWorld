namespace SubProject.DataServices
{
    public interface IFavoriteDS
    {
        bool AddMovieFavorite(string userName, string movieId);
        bool RemoveMovieFavorite(string userName, string movieId);
    }
}