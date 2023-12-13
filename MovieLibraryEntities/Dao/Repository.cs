using Microsoft.EntityFrameworkCore;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;

namespace MovieLibraryEntities.Dao;

public class Repository : IRepository, IDisposable
{

    private readonly IDbContextFactory<MovieContext> _contextFactory; //Before class could you explain to me how I could Have implemented this. I ran into some troubles with instantiating a repo
    private readonly MovieContext _context;

    public Repository(MovieContext context)
    {
        _context = context;
    }


    public void Dispose()
    {
        _context.Dispose();
    }

    public IEnumerable<Movie> GetAll()
    {
        return _context.Movies.ToList();
    }

    public IEnumerable<Movie> Search(string searchString)
    {
        var allMovies = _context.Movies;
        var listOfMovies = allMovies.ToList();
        var temp = listOfMovies.Where(x => x.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));

        return temp;
    }

    public string CreateMovie()
    {
        Console.WriteLine("Enter movie title: ");
        string title = Console.ReadLine();
        Console.WriteLine(" ");
        Console.WriteLine("Enter the release date(mm/dd/yyyy): ");
        string releaseDate = Console.ReadLine();
        DateTime utcDate;
        try
        {

            utcDate = DateTime.Parse(releaseDate + " 12:00am").ToUniversalTime();

        }
        catch (Exception e)
        {
            return e.Message;
            throw;
        }


        _context.Movies.Add(new Movie
        {
            Title = title,
            ReleaseDate = utcDate,
        });
        _context.SaveChanges();
        return "Movie Successfully added";
    }

       

    public IEnumerable<Movie> UpdateMovie()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Movie> DeleteMovie()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Movie> ListMovies()
    {
        throw new NotImplementedException();
    }
}