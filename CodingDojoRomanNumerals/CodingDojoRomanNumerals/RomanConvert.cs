using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojoRomanNumerals
{
    public class RomanConvert
    {
        private static int CheckTestData(string roman)
        {
            int resultDecimal = 0;
            switch(roman)
            {
                default:
                    resultDecimal = 0;
                    break;
                case "I":
                    resultDecimal = 1;
                    break;
                case "II":
                    resultDecimal = 2;
                    break;
                case "IV":
                    resultDecimal = 4;
                    break;
                case "V":
                    resultDecimal = 5;
                    break;
                case "IX":
                    resultDecimal = 9;
                    break;
                case "XLII":
                    resultDecimal = 42;
                    break;
                case "XCIX":
                    resultDecimal = 99;
                    break;
                case "MMXIII":
                    resultDecimal = 2013;
                    break;
            }
            return resultDecimal;
        }

        public int Convert(string roman)
        {
            //return CheckTestData(roman);
            return ConvertFromRomanToArabic(roman);
        }

        public static int GetRomanValue(string roman)
        {
            int resultValue = 0;
            switch(roman)
            {
                default:
                    resultValue = 0;
                    break;
                case "I":
                    resultValue = 1;
                    break;
                case "V":
                    resultValue = 5;
                    break;
                case "X":
                    resultValue = 10;
                    break;
                case "L":
                    resultValue = 50;
                    break;
                case "C":
                    resultValue = 100;
                    break;
                case "D":
                    resultValue = 500;
                    break;
                case "M":
                    resultValue = 1000;
                    break;
            }


            return resultValue;
        }

        private static int ConvertFromRomanToArabic(string roman)
        {
            int counter = 0;

            for (int stringIndex = 0; stringIndex < roman.Length; stringIndex++)
            {
                counter = counter + GetRomanValue(roman[stringIndex].ToString());
            }

            return counter;
        }


    }
}
