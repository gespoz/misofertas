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
        public string Username { get; set; }
        public string Run { get; set; }

        public DetalleOferta()
        {
            this.Init();
        }

        private void Init()
        {
            this.Username = string.Empty;
            this.Run = string.Empty;
            this.IdDetalle = 0;
            this.IdOferta = 0;
            this.ImgBoleta = new byte[0];
            this.Valoracion = 0;
            this.FecValoracion = new DateTime();
        }

        public bool Agregar()
        {
            MisOfertas.Datos.DETALLE_OFERTA detalle = new MisOfertas.Datos.DETALLE_OFERTA();
            try
            {
                using (var db = new MisOfertas.Datos.MisOfertasEntities())
                {
                    detalle.CONSUMIDOR_RUN = this.Run;
                    detalle.CONSUMIDOR_USERNAME = this.Username;
                    detalle.FEC_VALORACION = this.FecValoracion;
                    detalle.IMG_BOLETA = this.ImgBoleta;
                    detalle.VALORACION = this.Valoracion;
                    detalle.ID_DET = this.IdDetalle;
                    detalle.OFERTA_ID_OFERTA = this.IdOferta;

                    db.DETALLE_OFERTA.Add(detalle);
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
