using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CodeWarKata
{
    public class BingoCard
    {
        public static string[] GetCard()
        {
            var BNumbers = NumberGenerator(count: 5);
            var INumbers = NumberGenerator(count: 5);
            var NNumbers = NumberGenerator(count: 4);
            var GNumbers = NumberGenerator(count: 5);
            var ONumbers = NumberGenerator(count: 5);
            return BNumbers.Select(x => "B" + x.ToString()).Concat(
                   INumbers.Select(x => "I" + x.ToString()).Concat(
                   NNumbers.Select(x => "N" + x.ToString()).Concat(
                   GNumbers.Select(x => "G" + x.ToString()).Concat(
                   ONumbers.Select(x => "O" + x.ToString()))))).ToArray();
        }

        private static List<int> NumberGenerator(int count)
        {
            var numbers = new List<int>();
            var random = new Random();
            while (numbers.Count < count)
            {
                var number = random.Next(1, 15);
                if (!numbers.Contains(number))
                    numbers.Add(number);
            }

            return numbers;
        }
    }
}
