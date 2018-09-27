using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Certificado
    {
        public int IdCertificado { get; set; }
        public int Ptsminimos { get; set; }
        public int Ptsmaximos { get; set; }
        public decimal Descuento { get; set; }
        public int Tope { get; set; }
        public string Rubro { get; set; }
        public int IdConsumidor { get; set; }
    }
}
