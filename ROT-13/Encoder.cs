using System;
using System.Collections.Generic;
using System.Text;

namespace ROT_13
{
    public class Encoder
    {
        public string Rotate(string input)
        {
            var transformedInput = input.ToUpper();
            transformedInput = transformedInput.Replace("Ö", "OE");
            transformedInput = transformedInput.Replace("Ä", "AE");
            transformedInput = transformedInput.Replace("Ü", "UE");
            transformedInput = transformedInput.Replace("ß", "SS");
            var result = "";
            foreach (char c in transformedInput)
            {
                result += RotateCharacter(c).ToString();
            }
            return result;
        }

        private static char RotateCharacter(char c)
        {
            if (Char.IsLetter(c))
            {
                return RotateLetter(c);
            }

            return c;
        }

        private static char RotateLetter(char character)
        {
            var currentAsciValue = character + 13;
            if (currentAsciValue > 'Z')
            {
                currentAsciValue -= 26;
            }
            return (char)currentAsciValue;
        }
    }

}
}
