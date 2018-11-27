using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


                using (OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=MISOFERTAS;Password=mos;"))
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand();

                    cmd.Connection = con;

                    cmd.CommandText = "INSERT INTO DETALLE_OFERTA (IMG_BOLETA,FEC_VALORACION,VALORACION,OFERTA_ID_OFERTA,CONSUMIDOR_USERNAME,CONSUMIDOR_RUN) VALUES(:1,:2,:3,:4,:5,:6)";

                    cmd.Parameters.Add(new OracleParameter("1",this.ImgBoleta));
                    cmd.Parameters.Add(new OracleParameter("2", this.FecValoracion));
                    cmd.Parameters.Add(new OracleParameter("3", this.Valoracion));
                    cmd.Parameters.Add(new OracleParameter("4", this.IdOferta));
                    cmd.Parameters.Add(new OracleParameter("5", this.Username));
                    cmd.Parameters.Add(new OracleParameter("6", this.Run));

                    int row = cmd.ExecuteNonQuery();

                    con.Dispose();
                }
                return true;
           
        }
    }
}
