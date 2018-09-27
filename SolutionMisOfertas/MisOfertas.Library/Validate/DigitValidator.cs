using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Library.Validate
{
    public static class DigitValidator
    {
        public static Boolean Validate(string text)
        {
            int numAux;
            if (!(int.TryParse(text.Substring(0, text.Length - 1), out numAux)))
                return false;

            if (numAux < 10000)
                return false;

            char dv = char.Parse(text.Substring(text.Length - 1, 1));

            int m = 0, s = 1;
            for (; numAux != 0; numAux /= 10)
            {
                s = (s + numAux % 10 * (9 - m++ % 6)) % 11;
            }
            return (dv == (char)(s != 0 ? s + 47 : 75));
        }

        public static char GetDigitVerificationForNumber(string text)
        {
            int numAux;
            if (!(int.TryParse(text, out numAux)))
                throw new InvalidOperationException();

            int m = 0, s = 1;
            for (; numAux != 0; numAux /= 10)
            {
                s = (s + numAux % 10 * (9 - m++ % 6)) % 11;
            }
            return (char)(s != 0 ? s + 47 : 75);
        }
    }
}
