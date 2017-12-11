using System;
using System.Collections.Generic;
using System.Linq;

namespace BingoCard
{
    public class BingoCard
    {
        public static string[] GetCard()
        {
            var BNumbers = BingoNumberGenerator(start: 1, end: 16, count: 5);
            var INumbers = BingoNumberGenerator(start: 16, end: 31, count: 5);
            var NNumbers = BingoNumberGenerator(start: 31, end: 46, count: 4);
            var GNumbers = BingoNumberGenerator(start: 46, end: 61, count: 5);
            var ONumbers = BingoNumberGenerator(start: 61, end: 76, count: 5);

            return BNumbers.Select(x => "B" + x.ToString()).Concat(
                   INumbers.Select(x => "I" + x.ToString()).Concat(
                   NNumbers.Select(x => "N" + x.ToString()).Concat(
                   GNumbers.Select(x => "G" + x.ToString()).Concat(
                   ONumbers.Select(x => "O" + x.ToString()))))).ToArray();
        }

        private static List<int> BingoNumberGenerator(int start, int end, int count)
        {
            var randomNumbers = new List<int>();
            var random = new Random();
            while (randomNumbers.Count < count)
            {
                var number = random.Next(start, end);
                if (!randomNumbers.Contains(number))
                    randomNumbers.Add(number);
            }

            return randomNumbers;
        }
    }
}
