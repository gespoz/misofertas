using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Mensajeria
    {
        public long IdMensaje { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public byte[] Cupon { get; set; }
        public byte[] ImgOferta { get; set; }
        public int IdConsumidor { get; set; }
        public int IdSucursal { get; set; }
        public int IdOferta { get; set; }
    }
}
