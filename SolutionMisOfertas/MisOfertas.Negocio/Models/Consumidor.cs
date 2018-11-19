using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Consumidor
    {
        public int Puntos { get; set; }
        public string Username { get; set; }
        public string RunPersona { get; set; }

        public Consumidor()
        {
            this.Init();
        }

        private void Init()
        {
            this.Puntos = 0;
            this.Username = string.Empty;
            this.RunPersona = string.Empty;
        }

        public bool Agregar()
        {
            MisOfertas.Datos.CONSUMIDOR consumidor = new MisOfertas.Datos.CONSUMIDOR();
            try
            {
                using (var db = new MisOfertas.Datos.MisOfertasEntities())
                {
                    consumidor.PUNTOS = this.Puntos;
                    consumidor.PERSONA_RUN = this.RunPersona; 
                    consumidor.USUARIO_USERNAME = this.Username;

                    db.CONSUMIDOR.Add(consumidor);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar()
        {
            try
            {
                using (var db = new MisOfertas.Datos.MisOfertasEntities())
                {
                    var result = from u in db.CONSUMIDOR where (u.USUARIO_USERNAME == this.Username) select u;
                    if (result.Count() != 0)
                    {
                        var dbuser = result.First();
                        dbuser.PUNTOS = dbuser.PUNTOS + this.Puntos;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
