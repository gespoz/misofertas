using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace MisOfertas.Web.Models
{
    public class HomeView
    {
        public int Valoracion { get; set; }
        public DateTime FechaValoracion { get; set; }
        public RubroIndex RubroReg { get; set; }
        public List<OfertasHome> OfertasTabla { get; set; }
    }

    public class OfertasHome
    {
        public byte[] Imagen { get; set; }
        public string Disponible { get; set; }
        public decimal Valoracion { get; set; }
        public string Nombre { get; set; }
    }

    public enum RubroIndex
    {
        Alimentos,
        Electronica,
        Linea,
        Ropa
    }
}