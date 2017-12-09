using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MorseCodeDecoder
{
    public class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            var words = Regex.Split(morseCode.Trim(), @"\s\s+").Select(x=> x.Split(' ')).Select(x => x.Select(MorseCode.Get)).ToList();
            
            string pureText = string.Empty;

            foreach (var word in words)
            {
                pureText += string.Join("", word);
                pureText += " ";
            }

            return pureText.Trim();
        }
    }
}
