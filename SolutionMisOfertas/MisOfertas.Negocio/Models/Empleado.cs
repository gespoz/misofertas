using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Cargo { get; set; }
        public string RunPersona { get; set; }
        public int IdUsuario { get; set; }
    }
}
