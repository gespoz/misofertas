using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class CertificadoEmitido
    {
        public int Idemitido { get; set; }
        public decimal Descuento { get; set; }
        public int Ptsusados { get; set; }
        public string Username { get; set; }
        public string Run { get; set; }
        public int Idcert { get; set; }
    }
}
