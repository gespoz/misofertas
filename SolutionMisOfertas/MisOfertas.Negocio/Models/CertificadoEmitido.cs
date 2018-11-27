using Oracle.ManagedDataAccess.Client;
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

        public CertificadoEmitido()
        {
            this.Inix();
        }

        private void Inix()
        {
            this.Idemitido = 0;
            this.Descuento = 0;
            this.Ptsusados = 0;
            this.Run = string.Empty;
            this.Username = string.Empty;
            this.Idcert = 0;
        }

        public bool Agregar()
        {
            MisOfertas.Datos.CERTIFICADO_EMITIDO certificado = new MisOfertas.Datos.CERTIFICADO_EMITIDO();
            using (OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=MISOFERTAS;Password=mos;"))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand();

                cmd.Connection = con;

                cmd.CommandText = "INSERT INTO CERTIFICADO_EMITIDO (DESCUENTO,PTS_USADOS,CONSUMIDOR_USERNAME,CONSUMIDOR_RUN,CERTIFICADO_ID_CERT) VALUES(:1,:2,:3,:4,:5)";

                cmd.Parameters.Add(new OracleParameter("1", this.Descuento));
                cmd.Parameters.Add(new OracleParameter("2", this.Ptsusados));
                cmd.Parameters.Add(new OracleParameter("3", this.Username));
                cmd.Parameters.Add(new OracleParameter("4", this.Run));
                cmd.Parameters.Add(new OracleParameter("5", this.Idcert));

                int row = cmd.ExecuteNonQuery();

                con.Dispose();
            }
            return true;
        }
    }
}
