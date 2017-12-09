using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWarKata
{
    [TestClass]
    public class Program
    {
        private static void SwapTwoDigits(ref char a, ref char b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        private static int FindSmallestGreaterThanFirstSmaller(char[] digits, int smallest)
        {
            for (int j = smallest + 1; j < digits.Length; j++)
                if (digits[j] > digits[smallest - 1] && digits[j] < digits[smallest])
                    smallest = j;
            return smallest;
        }

        private static int FindFirstSmallerDigit(char[] digits)
        {
            for (int i = digits.Length - 1; i > 0; i--)
                if (digits[i] > digits[i - 1])
                    return i;
            return 0;
        }

        public static long NextBiggerNumber(long number)
        {
            var digits = number.ToString().ToArray();

            int firstSmaller = FindFirstSmallerDigit(digits);

            if (firstSmaller == 0)
            {
                return -1;
            }

            int benchMark = FindSmallestGreaterThanFirstSmaller(digits, firstSmaller);

            SwapTwoDigits(ref digits[benchMark], ref digits[firstSmaller - 1]);

            Array.Sort(digits, firstSmaller, digits.Length - firstSmaller);

            return long.Parse(new string(digits));
        }

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(-1, NextBiggerNumber(9));

            Assert.AreEqual(-1, NextBiggerNumber(11));

            Assert.AreEqual(21, NextBiggerNumber(12));

            Assert.AreEqual(-1, NextBiggerNumber(111));

            Assert.AreEqual(531, NextBiggerNumber(513));

            Assert.AreEqual(211, NextBiggerNumber(121));

            Assert.AreEqual(3456798, NextBiggerNumber(3456789));

            Assert.AreEqual(5454356792358, NextBiggerNumber(5454356789532));

            /*from codewar*/
            Assert.AreEqual(2071, NextBiggerNumber(2017));
            Assert.AreEqual(441, NextBiggerNumber(414));
            Assert.AreEqual(414, NextBiggerNumber(144));
        }
    }
}
