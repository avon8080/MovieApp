using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movieListingApp.FileService.FileServiceFactory;

namespace movieListingApp.FileService.DataManager
{
    public class Read : ITextReader
    {
        public string FileName { get; set; }
        public Read(string file)
        {
            FileName = file;
        }

        public void ReadFile()
        {
            StreamReader sr = FileFactory.CreateStreamReader(FileName);
            if (File.Exists(FileName))
            {
                var count = 0;

                while (!sr.EndOfStream)
                {
                    var lines = sr.ReadLine();

                    Console.WriteLine(lines);

                    if (count == 10)
                    {
                        Console.WriteLine("y to continue reading : n to exit");
                        var input = Console.ReadLine();
                        if (input == "y")
                        {
                            count = 0;
                            continue;
                        }
                        else
                            break;

                    }

                    count++;
                }
                sr.Close();
            }
        }

    }
}




