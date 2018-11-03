using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MisOfertas.Web.Models
{
    public class HomeView
    {
        public int Valoracion { get; set; }
        public DateTime FechaValoracion { get; set; }

        public RubroIndex RubroReg { get; set; }
    }

    public enum RubroIndex
    {
        Alimentos,
        Electronica,
        Linea,
        Ropa
    }
}