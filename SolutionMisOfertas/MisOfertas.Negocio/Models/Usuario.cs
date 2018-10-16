using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Models
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Perfil { get; set; }

        public Usuario()
        {
            this.Init();
        }

        private void Init()
        {
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Perfil = string.Empty;
        }

        public bool Agregar()
        {
            MisOfertas.Datos.USUARIO usuario = new MisOfertas.Datos.USUARIO();
            try
            {
                using (var db = new MisOfertas.Datos.MisOfertasEntities())
                {
                    usuario.USERNAME = this.Username;
                    usuario.PASSWORD = this.Password;
                    usuario.PERFIL = this.Perfil;

                    db.USUARIO.Add(usuario);
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
