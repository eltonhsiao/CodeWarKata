using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MorseCodeDecoder
{
    public class MorseCodeDecoder
    {
        

        public static string Decode(string morseCode)
        {
            var words = Regex.Split(morseCode.Trim(), @"\s\s+");
            string pureText = string.Empty;
            foreach (var word in words)
            {
                foreach (var morse in word.Split(' '))
                {
                    pureText += MorseCode.Get(morse);
                }

                pureText += " ";
            }
            
            return pureText.Trim();
        }
    }
}
