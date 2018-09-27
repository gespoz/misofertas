using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Library.Validate
{
    public static class RUTValidator
    {
        public static Boolean Validate(string rut)
        {
            rut = rut.ToUpper().Replace(".", "").Replace("-", "").Replace(" ", "");
            return DigitValidator.Validate(rut);
        }

        public static string Format(string rut)
        {
            rut = rut.ToUpper().Replace(".", "").Replace("-", "").Replace(" ", "");
            return rut.Substring(0, rut.Length - 1) + "-" + rut.Substring(rut.Length - 1);
        }
    }
}
