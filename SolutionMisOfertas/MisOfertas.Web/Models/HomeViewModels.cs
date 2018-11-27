using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace MisOfertas.Web.Models
{
    public class HomeView
    {
        [Range(1,5,ErrorMessage ="El rango de valoracion es entre 1 y 5.")]
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
        public string Descripcion { get; set; }
        public int Valor { get; set; }
        public int Id { get; set; }
    }

    public class MoreInfo
    {
        public OfertasHome Ofertas { get; set; }
        public int Valora { get; set; }
        [Required]
        public HttpPostedFileBase Img { get; set; }
        public byte[] Imagen { get; set; }
    }

    public class Certificado
    {
        public int Porcentaje { get; set; }
        public int Puntos { get; set; }
        public int Tope { get; set; }
        public string Rut { get; set; }

        public string RunC { get; set; }
        public string UserC { get; set; }
    }

    public enum RubroIndex
    {
        Todos,
        Alimento,
        Electronica,
        [Display(Name="Linea Blanca")]
        LineaBlanca,
        Ropa
    }
}