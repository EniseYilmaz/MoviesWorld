namespace SubProject.DataServices
{
    public interface IBookMarkDS
    {
        bool AddMovieBookMark(string userName, string movieId);
        bool RemoveMovieBookMark(string userName, string movieId);
        bool AddNameBookMark(string userName, string personId);
        bool RemoveNameBookMark(string userName, string personId);
    }
}