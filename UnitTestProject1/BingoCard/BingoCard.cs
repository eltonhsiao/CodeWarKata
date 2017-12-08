using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeWarKata
{
    public class BingoCard
    {
        public static string[] GetCard()
        {
            return new string[24]
            {
                "B1", "B2", "B3", "B4", "B5",
                "I6", "I7", "I8", "I9", "I10",
                "N11", "N12", "N13", "N14",
                "G15", "G16", "G17", "G18", "G19",
                "O20", "O21", "O22", "O23", "O24"
            };
        }
    }
}
