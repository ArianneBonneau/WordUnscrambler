using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            //declare a string[] to hold the contents of the file
            string[] lines = new String[0];

            //try catch
            try
                {
                //return file contents, which is a string[]
                lines = File.ReadAllLines(filename);
                //foreach (string line in lines)
                                                                    //{
                                                                    //    Console.Read();
                                                                    //}

            }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            return lines;
        }
    }
}


