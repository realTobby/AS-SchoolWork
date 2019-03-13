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
            int[] list = { 1, 9, 8, 7, 6, 5, 5, 3, 2, 10 };
            recursiveBubble(list, 0, list.Length);
            Console.ReadLine();
        }

        public static int[] recursiveBubble(int[] args, int startIndex, int endIndex)
        {
            foreach (var item in args)
            {
                Console.Write(item + " ");

            }
            Console.WriteLine("  " + startIndex + "//" + endIndex + " ");


            if(startIndex > endIndex)
            {
                Console.WriteLine("recursiveBubblesort:");
                foreach(int arg in args)
                {
                    Console.WriteLine(arg + " ");
                }
                return args;
            }
            if(startIndex == endIndex -1)
            {
                recursiveBubble(args, 0, endIndex - 1);

            }else if(args[startIndex] > args[startIndex +1])
            {
                int currentNumber = args[startIndex];
                args[startIndex] = args[startIndex+1];
                args[startIndex + 1] = currentNumber;
                recursiveBubble(args, startIndex + 1, endIndex);
            }else{
                recursiveBubble(args, startIndex+1,endIndex);
            
            }

            



            return args;
        }

    }
}
