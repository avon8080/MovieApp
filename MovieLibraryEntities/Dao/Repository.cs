using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;

namespace MovieLibraryEntities.Dao;

public class Repository : IRepository
{

   // private readonly IDbContextFactory<MovieContext> _contextFactory; //Before class could you explain to me how I could Have implemented this. I ran into some troubles with instantiating a repo
    private readonly MovieContext _context;
    private User user;

    public Repository(IContext context)
    {
        _context = (MovieContext)context;
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
        }


        _context.Movies.Add(new Movie
        {
            Title = title,
            ReleaseDate = utcDate,
        });
        _context.SaveChanges();
        return "Movie Successfully added";
    }

    public Movie UpdateMovie(long id)
    {
        
        Movie userMovie = _context.Movies.FirstOrDefault(x => x.Id.Equals(id));
        ;
        switch (UpdateMenu(userMovie))
        {
            case "1":
                Console.WriteLine("Enter new movie title: ");
                userMovie.Title = Console.ReadLine();
                break;
            case "2":
                Console.WriteLine("Enter the release date(mm/dd/yyyy): ");
                string releaseDate = Console.ReadLine();
                DateTime utcDate;
                try
                {

                    utcDate = DateTime.Parse(releaseDate + " 12:00am");
                    userMovie.ReleaseDate = utcDate;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                break;
        }

        _context.SaveChanges();
        return userMovie;
    }

    public string DeleteMovie(long id)
    {
        Movie userMovie = _context.Movies.FirstOrDefault(x => x.Id.Equals(id));
        _context.Movies.Remove(userMovie);
        _context.SaveChanges();
        return "Movie successfully removed";
    }

    public IEnumerable<Movie> ListMovies()
    {
        return  _context.Movies.ToList<Movie>();
    }

    public string AddUser()
    {
        Console.WriteLine("Enter age: ");
        var isValid = long.TryParse(Console.ReadLine(), out long ageResult);
        
        Console.WriteLine("Enter gender: ");
        var gender = Console.ReadLine();
        Console.WriteLine("Enter zip code: ");
        var zipCode = Console.ReadLine();
        Console.WriteLine("Enter occupation: ");
        var occupation = Console.ReadLine();
       var job = new Occupation()
        {
            Name = occupation
        };
       _context.Occupations.Add(job);
        user = new User()
        {
            Age = ageResult,
            Gender = gender,
            ZipCode = zipCode,
            Occupation = job
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return "User successfully added";

    }


    private string UpdateMenu(Movie movie)
    {
        Console.WriteLine($"Enter the corresponding number to update {movie.Title}\n\t1. Update title\n\t2. Update release date");
        var updateResult = Console.ReadLine();
        return updateResult;
    }

    public string UserRating()
    {
        Console.WriteLine("Enter the movie: ");
        Movie movie = Search(Console.ReadLine()).First();
        Console.WriteLine("Enter rating (1-5): ");
        var isValid = long.TryParse(Console.ReadLine(), out long rating);
        DateTime ratingDate = DateTime.Now.ToUniversalTime();
        _context.UserMovies.Add(new UserMovie()
        {
            Rating = rating,
            RatedAt = ratingDate,
            User = user,
            Movie = movie

        }); 
        _context.SaveChanges();
        return $"Successfully added:\n\tUser Id - {user.Id}\n\trating - {rating}\n\tDate - {ratingDate}\n\tMovie - {movie.Title}";

    }

    //public IEnumerable<Users> TopRated()
    //{
    //    //List top rated movie by age bracket or occupation
    //    // 
    //    // Sort alphabetically and by rating and display just the first movie
    //    // 
        
    //    return _context.UserMovies.Where(x => x.Rating.Equals(5)).GroupBy(x => x.User.Occupation.Id.Equals(1)).FirstOrDefault().ToList();
    //}
}