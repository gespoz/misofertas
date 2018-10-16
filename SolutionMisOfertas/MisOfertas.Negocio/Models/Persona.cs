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

        public Persona()
        {
            this.Init();
        }

        private void Init()
        {
            this.Run = string.Empty;
            this.Nombre = string.Empty;
            this.Paterno = string.Empty;
            this.Materno = string.Empty;
            this.Sexo = string.Empty;
            this.Email = string.Empty;
            this.FecNac = new DateTime();
        }

        public bool Agregar()
        {
            MisOfertas.Datos.PERSONA persona = new MisOfertas.Datos.PERSONA();
            try
            {
                using (var db = new MisOfertas.Datos.MisOfertasEntities())
                {
                    persona.RUN = this.Run;
                    persona.NOMBRE = this.Nombre;
                    persona.PATERNO = this.Paterno;
                    persona.MATERNO = this.Materno;
                    persona.SEXO = this.Sexo;
                    persona.EMAIL = this.Email;
                    persona.FEC_NAC = this.FecNac;

                    db.PERSONA.Add(persona);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
