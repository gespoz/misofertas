using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class RegProducto
    {
        public int IdCaso { get; set; }
        public string Descripcion { get; set; }
        public DateTime FecSalida { get; set; }
        public long IdProducto { get; set; }
    }
}
