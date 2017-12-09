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
        public static string Decode(string morseCode)
        {
            var morseCodesLettersAndNumerals = new Dictionary<string, string>()
            {
                {"....", "H"},
                {".", "E"},
                {"-.--", "Y"},
                {".---", "J"},
                {"..-", "U"},
                {"-..", "D"}
            };

            var words = Regex.Split(morseCode, @"\s{2,}");
            string pureText = string.Empty;
            foreach (var word in words)
            {
                foreach (var morse in word.Split(' '))
                {
                    pureText += morseCodesLettersAndNumerals[morse];
                }
                
                pureText += " ";
            }
            
            return pureText.Trim();
        }
    }
}
