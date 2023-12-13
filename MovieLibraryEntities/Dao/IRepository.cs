using MovieLibraryEntities.Models;

namespace MovieLibraryEntities.Dao;

public interface IRepository
{
    IEnumerable<Movie> GetAll();
    IEnumerable<Movie> Search(string searchString); 
    string CreateMovie();
    IEnumerable<Movie> ListMovies();
    IEnumerable<Movie> UpdateMovie();
    IEnumerable<Movie> DeleteMovie();
}