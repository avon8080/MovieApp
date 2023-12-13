using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movieListingApp.FileService;
using movieListingApp.FileService.FileServiceFactory;
using MovieLibraryEntities;

namespace movieListingApp
{
    public class Menu
    {
        private IDataManager _dataManager;



        public Menu(IDataManager dataManager)
        {
            _dataManager = dataManager;


        }


        public void Run()
        {
            string choice;
            do
            {
               choice = DisplayMenu();
                switch (choice)
                {
                    case "1":
                        ListMenu();
                        break;
                    case "2":
                        _dataManager.AddMovieDB();
                        break;
                    case "3":
                        _dataManager.ListMovies();
                        break;
                    case "4":
                        _dataManager.Search();
                        break;
                }
            } while (choice != "q") ;
        }

        private string DisplayMenu()
        {
            Console.WriteLine("\t--Menu--\n1. File service (read/write)\n2. Add movie to database\n3. List movies From DB\n4. Q to Quit\n==>");
            return Console.ReadLine().ToLower();

        }
        private string ListMenu()
        {
            Console.WriteLine("\t--Menu--\n Enter 1 to write to file\nEnter 2 to read file\nEnter Q to quit");
            return Console.ReadLine().ToLower();
        }

    }
}
