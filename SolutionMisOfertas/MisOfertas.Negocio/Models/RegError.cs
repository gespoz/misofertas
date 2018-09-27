using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class RegError
    {
        public int IdError { get; set; }
        public string Descripcion { get; set; }
        public long IdMensaje { get; set; }
    }
}
