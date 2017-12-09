using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MorseCodeDecoder
{
    public class MorseCodeDecoder
    {
        private static Dictionary<string, string> MorseCodesLettersAndNumerals = new Dictionary<string, string>()
        {
            {".-", "A"},
            {"-...", "B"},
            {"-.-.", "C"},
            {"-..", "D"},
            {".", "E"},
            {"..-.", "F"},
            {"--.", "G"},
            {"....", "H"},
            {"..", "I"},
            {".---", "J"},
            {"-.-", "K"},
            {".-..", "L"},
            {"--", "M"},
            {"-.", "N"},
            {"---", "O"},
            {".--.", "P"},
            {"--.-", "Q"},
            {".-.", "R"},
            {"...", "S"},
            {"-", "T"},
            {"..-", "U"},
            {"...-", "V"},
            {".--", "W"},
            {"-..-", "X"},
            {"-.--", "Y"},
            {"--..", "Z"},
            {"-----", "0"},
            {".----", "1"},
            {"..---", "2"},
            {"...--", "3"},
            {"....-", "4"},
            {".....", "5"},
            {"-....", "6"},
            {"--...", "7"},
            {"---..", "8"},
            {"----.", "9"},
            {"...---...", "SOS" },
            {"-.-.--", "!"},
            {".-.-.-", "." }
        };

        public static string Decode(string morseCode)
        {
            var words = Regex.Split(morseCode.Trim(), @"\s\s+");
            string pureText = string.Empty;
            foreach (var word in words)
            {
                foreach (var morse in word.Split(' '))
                {
                    pureText += MorseCodesLettersAndNumerals[morse];
                }

                pureText += " ";
            }
            
            return pureText.Trim();
        }
    }
}
