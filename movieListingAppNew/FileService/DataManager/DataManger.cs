using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using MovieLibraryEntities.Dao;
using movieListingApp.FileService;
using movieListingApp.FileService.DataManager;
using MovieLibraryEntities;
using MovieLibraryEntities.Context;
using movieListingApp.FileService.FileServiceFactory;

namespace movieListingApp.FileService.DataManager
{
    public class DataManager : IDataManager
    {
        private ITextReader _read;
        private ITextWriter _write;
        private IRepository _repository;


        public DataManager(ITextReader read, ITextWriter write, MovieContext context)
        {
            _read = read;
            _write = write;
            _repository = Factory.CreateRepository(context); // I know this a dependency. This is where I ran into some trouble.
        }

        public void AddMovieDB()
        {
            _repository.CreateMovie();
        }

        public void Search()
        {
            Console.WriteLine("Enter a movie to search: ");
            var userMovieLine = Console.ReadLine();
            Console.WriteLine("Movies: ");
            foreach (var movie in _repository.Search(userMovieLine))
            {
                Console.WriteLine($"\n{movie.Title}");
                
            }
        }

        public void RemoveMovieDB()
        {
            _repository.DeleteMovie();
        }

        public void TextReader()
        {
            _read.ReadFile();
        }

        public void TextWriter()
        {
            _write.WriteToFile();
        }

        public void ListMovies()
        {
            throw new NotImplementedException();
        }
    }
}
