using movieListingApp.FileService.DataManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieLibraryEntities;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;

namespace movieListingApp.FileService.FileServiceFactory
{
    public static class Factory
    {
        public static IDataManager CreateDataManager(ITextReader read, ITextWriter write, MovieContext context)
        {
            return new DataManager.DataManager(read, write, context);
        }


        public static MovieContext CreateContext()
        {
            return new MovieContext();
        }

        
        public static IRepository CreateRepository(MovieContext context)
        {
            return new Repository(context);
        }





    }
}
