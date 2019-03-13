using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekusrivePfade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pfad angeben:");
            string _firstPath = Console.ReadLine();
            GetAllPath(_firstPath);
            Console.WriteLine("Finish");
            Console.ReadKey();
        }

        static void GetAllPath(string pathArg)
        {
            try
            {
                string[] paths = System.IO.Directory.GetDirectories(pathArg);
                foreach (string item in paths)
                {
                    Console.WriteLine(item);
                    GetAllPath(item);
                }
            }catch(Exception ex)
            {
                // do nothing, just jump over it and go on
                Console.WriteLine(ex.Message);
            }
        }


    }
}
