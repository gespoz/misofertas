using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Cqrs.Exceptions
{
    public class BusinessException : System.Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
