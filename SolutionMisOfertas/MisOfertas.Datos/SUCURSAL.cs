//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MisOfertas.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUCURSAL
    {
        public SUCURSAL()
        {
            this.MENSAJERIA = new HashSet<MENSAJERIA>();
            this.OFERTA = new HashSet<OFERTA>();
            this.PRODUCTO = new HashSet<PRODUCTO>();
        }
    
        public int ID_SUCUR { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string FONO { get; set; }
        public string COMUNA { get; set; }
        public string EMPRESA_RUT { get; set; }
    
        public virtual EMPRESA EMPRESA { get; set; }
        public virtual ICollection<MENSAJERIA> MENSAJERIA { get; set; }
        public virtual ICollection<OFERTA> OFERTA { get; set; }
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }
    }
}
