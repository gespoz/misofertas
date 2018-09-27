using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class DetalleOferta
    {
        public int IdDetalle { get; set; }
        public byte[] ImgBoleta { get; set; }
        public DateTime FecValoracion { get; set; }
        public decimal Valoracion { get; set; }
        public int IdOferta { get; set; }
        public int IdConsumidor { get; set; }
    }
}
