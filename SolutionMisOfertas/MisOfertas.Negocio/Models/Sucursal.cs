using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Fono { get; set; }
        public string Comuna { get; set; }
        public string RutEmpresa { get; set; }
    }
}
