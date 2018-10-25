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
    
    public partial class PRODUCTO
    {
        public PRODUCTO()
        {
            this.LOTE = new HashSet<LOTE>();
            this.OFERTA = new HashSet<OFERTA>();
            this.REG_PRODUCTO = new HashSet<REG_PRODUCTO>();
        }
    
        public long ID_PROD { get; set; }
        public string NOMBRE { get; set; }
        public string DESC_PROD { get; set; }
        public System.DateTime FEC_INGRESO { get; set; }
        public string ESTADO { get; set; }
        public int STK_SEGURO { get; set; }
        public int STK_SUCUR { get; set; }
        public string RUBRO { get; set; }
        public string DESC_RUBRO { get; set; }
        public int VALOR { get; set; }
        public int SUCURSAL_ID_SUCUR { get; set; }
    
        public virtual ICollection<LOTE> LOTE { get; set; }
        public virtual ICollection<OFERTA> OFERTA { get; set; }
        public virtual SUCURSAL SUCURSAL { get; set; }
        public virtual ICollection<REG_PRODUCTO> REG_PRODUCTO { get; set; }
    }
}
