// 42 Zeilen

using System;

namespace CodingDojoRomanNumerals
{
    public class RomanConvert
    {
        public int Convert(string roman) // <- INTEGRATIONMETHODE EINSTIEG
        {
            return ConvertFromRomanToArabic(roman);
        }

        private static int ConvertFromRomanToArabic(string roman) // <- INTEGRATIONSMETHODE
        {
            int[] romanValues = GetRomanValues(roman);
            int romanDecimal = ConvertRomanValuesToDecimal(romanValues);
            return romanDecimal;
        }

        public static int ConvertRomanValuesToDecimal(int[] roman) // <- OPERATIONSMETHODE 11
        {
            int counter = 0;
            for (int romanIndex = 0; romanIndex < roman.Length; romanIndex++)
            {
                int currentRoman = roman[romanIndex];
                if (romanIndex < roman.Length - 1)
                {
                    int nextRoman = roman[romanIndex + 1];
                    if (currentRoman >= nextRoman)
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

        public static int[] GetRomanValues(string roman) // <- OPERATIONSMETHODE 2 25
        {
            int[] resultValue = new int[roman.Length + 1];
            for (int romanIndex = 0; romanIndex < roman.Length; romanIndex++)
            {
                switch (roman[romanIndex])
                {
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
    }
}
