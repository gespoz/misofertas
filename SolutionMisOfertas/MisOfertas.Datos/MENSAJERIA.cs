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
    
    public partial class MENSAJERIA
    {
        public MENSAJERIA()
        {
            this.REG_ERROR = new HashSet<REG_ERROR>();
        }
    
        public long ID_MSJ { get; set; }
        public string ASUNTO { get; set; }
        public string MENSAJE { get; set; }
        public byte[] CUPON { get; set; }
        public byte[] IMG_OFERTA { get; set; }
        public int SUCURSAL_ID_SUCUR { get; set; }
        public int OFERTA_ID_OFERTA { get; set; }
        public string CONSUMIDOR_USERNAME { get; set; }
        public string CONSUMIDOR_RUN { get; set; }
    
        public virtual CONSUMIDOR CONSUMIDOR { get; set; }
        public virtual OFERTA OFERTA { get; set; }
        public virtual SUCURSAL SUCURSAL { get; set; }
        public virtual ICollection<REG_ERROR> REG_ERROR { get; set; }
    }
}
