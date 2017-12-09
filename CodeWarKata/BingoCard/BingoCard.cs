﻿using NUnit.Framework;
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
            var BNumbers = BingoNumberGenerator(start: 1, end: 15, count: 5);
            var INumbers = BingoNumberGenerator(start: 16, end: 30, count: 5);
            var NNumbers = BingoNumberGenerator(start: 31, end: 45, count: 4);
            var GNumbers = BingoNumberGenerator(start: 46, end: 60, count: 5);
            var ONumbers = BingoNumberGenerator(start: 61, end: 75, count: 5);
            return BNumbers.Select(x => "B" + x.ToString()).Concat(
                   INumbers.Select(x => "I" + x.ToString()).Concat(
                   NNumbers.Select(x => "N" + x.ToString()).Concat(
                   GNumbers.Select(x => "G" + x.ToString()).Concat(
                   ONumbers.Select(x => "O" + x.ToString()))))).ToArray();
        }

        private static List<int> BingoNumberGenerator(int start, int end, int count)
        {
            var numbers = new List<int>();
            var random = new Random();
            while (numbers.Count < count)
            {
                var number = random.Next(start, end);
                if (!numbers.Contains(number))
                    numbers.Add(number);
            }

            return numbers;
        }
    }
}