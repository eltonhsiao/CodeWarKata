using System;
using System.Collections.Generic;

namespace BingoCard
{
    public class BingoCard
    {
        public static string[] GetCard()
        {
            var bingoCard = new List<string>();
            bingoCard.AddRange(BingoNumberGenerator(column: "B", start: 1, end: 16, count: 5));
            bingoCard.AddRange(BingoNumberGenerator(column: "I", start: 16, end: 31, count: 5));
            bingoCard.AddRange(BingoNumberGenerator(column: "N", start: 31, end: 46, count: 4));
            bingoCard.AddRange(BingoNumberGenerator(column: "G", start: 46, end: 61, count: 5));
            bingoCard.AddRange(BingoNumberGenerator(column: "O", start: 61, end: 76, count: 5));

            return bingoCard.ToArray();
        }

        private static IEnumerable<string> BingoNumberGenerator(string column, int start, int end, int count)
        {
            var randomNumbers = new List<int>();
            var random = new Random();
            while (randomNumbers.Count < count)
            {
                var number = random.Next(start, end);
                if (!randomNumbers.Contains(number))
                {
                    randomNumbers.Add(number);
                    yield return column + number;
                }
            }
        }
    }
}
