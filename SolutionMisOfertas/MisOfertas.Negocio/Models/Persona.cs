using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Persona
    {
        public string Run { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public DateTime FecNac { get; set; }
    }
}
