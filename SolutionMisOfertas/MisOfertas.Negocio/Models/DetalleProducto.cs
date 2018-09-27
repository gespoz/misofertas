using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class DetalleProducto
    {
        public long IdProducto { get; set; }
        public int IdSucursal { get; set; }
        public int StkSucursal { get; set; }
    }
}
