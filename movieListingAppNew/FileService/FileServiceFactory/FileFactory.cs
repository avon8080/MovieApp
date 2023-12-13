using movieListingApp.FileService.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;

namespace movieListingApp.FileService.FileServiceFactory
{
    public static class FileFactory
    {
        public static StreamReader CreateStreamReader(string file)
        {
            return new StreamReader(file);
        }

        public static Read CreateRead(string filename)
        {
            return new Read(filename);
        }

        public static WriteFile CreateWriteFile(string filename, bool write)
        {
            return new WriteFile(filename, write);
        }

        public static StreamWriter CreateStreamWriter(string filename, bool write)
        {
            return new StreamWriter(filename, write);
        }


    }
}
