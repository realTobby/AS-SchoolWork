using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyClean
{
    public class DirtyCode
    {
        public static int LOOP_START = 100;
        public static int LOOP_END = 200;
        public static int LOOP_MATH_RESULT = 100;
        public static void main(string[] args)
        {
            float result = 0;
            for(int iterate = LOOP_START; iterate <= LOOP_END; iterate++)
            {
                result += iterate - LOOP_MATH_RESULT;
                Console.WriteLine(result);
            }
        }
    }
}
