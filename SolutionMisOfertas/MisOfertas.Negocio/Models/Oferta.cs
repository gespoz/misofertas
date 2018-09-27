using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Oferta
    {
        public int IdOferta { get; set; }
        public string Descripcion { get; set; }
        public DateTime FecInicio { get; set; }
        public DateTime FecTermino { get; set; }
        public byte[] ImgOferta { get; set; }
        public decimal ValoracionTotal { get; set; }
        public decimal Descuento { get; set; }
        public int IdSucursal { get; set; }
        public long IdProducto { get; set; }
    }
}
