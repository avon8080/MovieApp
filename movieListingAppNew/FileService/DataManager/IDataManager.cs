namespace movieListingApp.FileService
{
    public interface IDataManager
    {
        void TextReader();
        void TextWriter();
        void AddMovieDB();
        void RemoveMovieDB();
        void Search();
        void ListMovies();

    }
}