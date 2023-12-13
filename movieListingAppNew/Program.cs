using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;
using movieListingApp.FileService.FileServiceFactory;

namespace movieListingApp
{
    public class Program
    {
        
        private static Menu menu = new Menu(Factory.CreateDataManager(FileFactory.CreateRead("movies.txt"), FileFactory.CreateWriteFile("movies.txt", true), Factory.CreateContext()));
        static void Main(string[] args)
        {
            menu.Run();


        }

      
    }
}