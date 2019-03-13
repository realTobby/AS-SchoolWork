using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public static class Util
    {
        static Random rnd = new Random();
        static string alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public static string getRandomString(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result = result + alpha[rnd.Next(0, alpha.Length)];
            }
            return result;
        }
    }
}
