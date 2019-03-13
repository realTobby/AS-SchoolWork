using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingDojoRomanNumerals;

namespace RomanConvertTest
{
    [TestClass]
    public class RomanConvertTest
    {
        RomanConvert romanConvert = new RomanConvert();

        [TestMethod]
        public void TestConvertFromRomanToArabicI()
        {
            string roman = "I";
            Assert.AreEqual(1, romanConvert.Convert(roman));
        }

        [TestMethod]
        public void TestConvertFromRomanToArabicII()
        {
            string roman = "II";
            Assert.AreEqual(2, romanConvert.Convert(roman));
        }

        [TestMethod]
        public void TestConvertFromRomanToArabicIV()
        {
            string roman = "IV";
            Assert.AreEqual(4, romanConvert.Convert(roman));
        }

        [TestMethod]
        public void TestConvertFromRomanToArabicV()
        {
            string roman = "V";
            Assert.AreEqual(5, romanConvert.Convert(roman));
        }

        [TestMethod]
        public void TestConvertFromRomanToArabicIX()
        {
            string roman = "IX";
            Assert.AreEqual(9, romanConvert.Convert(roman));
        }

        [TestMethod]
        public void TestConvertFromRomanToArabicXLII()
        {
            string roman = "XLII";
            Assert.AreEqual(42, romanConvert.Convert(roman));
        }

        [TestMethod]
        public void TestConvertFromRomanToArabicXCIX()
        {
            string roman = "XCIX";
            Assert.AreEqual(99, romanConvert.Convert(roman));
        }

        [TestMethod]
        public void TestConvertFromRomanToArabicMMXIII()
        {
            string roman = "MMXIII";
            Assert.AreEqual(2013, romanConvert.Convert(roman));
        }




        [TestMethod]
        public void TestGetRomanValueI()
        {
            string roman = "I";
            Assert.AreEqual(1, RomanConvert.GetRomanValue(roman));
        }

        [TestMethod]
        public void TestGetRomanValueV()
        {
            string roman = "V";
            Assert.AreEqual(5, RomanConvert.GetRomanValue(roman));
        }

        [TestMethod]
        public void TestGetRomanValueX()
        {
            string roman = "X";
            Assert.AreEqual(10, RomanConvert.GetRomanValue(roman));
        }

        [TestMethod]
        public void TestGetRomanValueL()
        {
            string roman = "L";
            Assert.AreEqual(50, RomanConvert.GetRomanValue(roman));
        }

        [TestMethod]
        public void TestGetRomanValueC()
        {
            string roman = "C";
            Assert.AreEqual(100, RomanConvert.GetRomanValue(roman));
        }

        [TestMethod]
        public void TestGetRomanValueD()
        {
            string roman = "D";
            Assert.AreEqual(500, RomanConvert.GetRomanValue(roman));
        }

        [TestMethod]
        public void TestGetRomanValueM()
        {
            string roman = "M";
            Assert.AreEqual(1000, RomanConvert.GetRomanValue(roman));
        }



    }
}
