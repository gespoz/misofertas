using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Lote
    {
        public int IdLote { get; set; }
        public short Cantidad { get; set; }
        public DateTime FechaLimite { get; set; }
        public long IdProducto { get; set; }
    }
}
