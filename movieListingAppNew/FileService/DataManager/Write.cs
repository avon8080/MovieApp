using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movieListingApp.FileService.FileServiceFactory;

namespace movieListingApp.FileService.DataManager
{
    public class WriteFile : ITextWriter



    {
        private string FileName { get; set; }
        private bool writeFile { get; set; }
        private bool writeAgain = true;

        public WriteFile(string file, bool write)
        {
            FileName = file;
            writeFile = write;
        }

        public void WriteToFile()
        {
            while (writeAgain)
            {
                Console.WriteLine("Enter Movie title: ");
                var title = Console.ReadLine();
                if (checkTitle(title))
                {
                    continue;
                }
                Console.WriteLine("Enter genre: ");
                var genre = Console.ReadLine();
                Console.WriteLine("Multiple genres? if yes enter y : else any key");
                while (Console.ReadLine() == "y")
                {
                    Console.WriteLine("Enter genre: ");
                    genre.Split('|');
                    genre += Console.ReadLine();


                    Console.WriteLine("Would you like to continue? enter y : else any key");
                    if (Console.ReadLine() != "y")
                    {
                        break;
                    }
                }

                int id = GetId();
                StreamWriter sw = FileFactory.CreateStreamWriter(FileName, writeFile);
                sw.WriteLine($"{id}, {title}, {genre}");
                Console.WriteLine("Would you like to write again-- y for yes : n for no");
                if (Console.ReadLine().ToLower() == "y")
                    writeAgain = true;

                else
                {
                    sw.Flush();
                    sw.Close();
                    break;
                }
                sw.Flush();
                sw.Close();
            }
        }

        private bool checkTitle(string title)
        {
            //https://learn.microsoft.com/en-us/dotnet/csharp/how-to/compare-strings
            var listFile = FileFactory.CreateStreamReader(FileName);
            while (!listFile.EndOfStream)
            {
                var item = listFile.ReadLine();
                string[] itemStrings = item.Split(',');
                bool areEqual = string.Equals(title, itemStrings[1], StringComparison.OrdinalIgnoreCase);
                if (areEqual)
                {
                    Console.WriteLine("This item already exists -- Please try a different movie");
                    listFile.Close();
                    return true;
                }

            }

            listFile.Close();
            return false;
        }
        private int GetId()
        {
            var listFile = FileFactory.CreateStreamReader(FileName);
            int id = 0;
            while (!listFile.EndOfStream)
            {
                var item = listFile.ReadLine();

                string[] itemStrings = item.Split(',');
                int idInt = 0;
                try
                {
                    idInt = int.Parse(itemStrings[0]);
                }
                catch (FormatException e)
                {
                    continue;
                }

                if (idInt > id)
                {
                    id = idInt;

                }
            }
            listFile.Close();
            return id += 1;
        }

    }
}
