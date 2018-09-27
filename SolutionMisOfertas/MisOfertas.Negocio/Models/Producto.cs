using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Producto
    {
        public long IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FecIngreso { get; set; }
        public string Estado { get; set; }
        public int StkSeguro { get; set; }
        public string Rubro { get; set; }
        public string DescRubro { get; set; }
        public int Valor { get; set; }
    }
}
