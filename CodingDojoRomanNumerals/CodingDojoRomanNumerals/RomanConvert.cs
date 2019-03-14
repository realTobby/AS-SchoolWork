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

        public static int[] GetRomanValues(string roman)
        {
            int[] resultValue = new int[roman.Length + 1];

            for(int romanIndex = 0; romanIndex < roman.Length; romanIndex++)
            {
                switch (roman[romanIndex])
                {
                    default:
                        resultValue[romanIndex] = 0;
                        break;
                    case 'I':
                        resultValue[romanIndex] = 1;
                        break;
                    case 'V':
                        resultValue[romanIndex] = 5;
                        break;
                    case 'X':
                        resultValue[romanIndex] = 10;
                        break;
                    case 'L':
                        resultValue[romanIndex] = 50;
                        break;
                    case 'C':
                        resultValue[romanIndex] = 100;
                        break;
                    case 'D':
                        resultValue[romanIndex] = 500;
                        break;
                    case 'M':
                        resultValue[romanIndex] = 1000;
                        break;
                }
            }
            return resultValue;
        }

        private static int ConvertFromRomanToArabic(string roman)
        {
            int[] romanValues = GetRomanValues(roman);
            return ConvertRomanValuesToDecimal(romanValues);
        }

        public static int ConvertRomanValuesToDecimal(int[] roman)
        {
            int counter = 0;

            for (int romanIndex = 0; romanIndex < roman.Length; romanIndex++)
            {
                int currentRoman = roman[romanIndex];

                if (romanIndex < roman.Length-1)
                {
                    int nextRoman = roman[romanIndex+1];

                    if(currentRoman >= nextRoman)
                    {
                        counter += currentRoman;
                    }
                    else
                    {
                        counter += nextRoman - currentRoman;
                        romanIndex++;
                    }
                }
                else
                {
                    counter += currentRoman;
                    romanIndex++;
                }
            }

            return counter;
        }


    }
}
