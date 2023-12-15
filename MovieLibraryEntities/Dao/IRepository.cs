using MovieLibraryEntities.Models;

namespace MovieLibraryEntities.Dao;

public interface IRepository
{
    public IEnumerable<Movie> GetAll();

    public IEnumerable<Movie> Search(string searchString);

    public string CreateMovie();

    public Movie UpdateMovie(long id);

    public string DeleteMovie(long id);

    public IEnumerable<Movie> ListMovies();
    public string AddUser();
    public string UserRating();
    //public IEnumerable<UserMovie> TopRated();

}