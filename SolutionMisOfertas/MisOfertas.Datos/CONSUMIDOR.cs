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
    
    public partial class CONSUMIDOR
    {
        public CONSUMIDOR()
        {
            this.CERTIFICADO_EMITIDO = new HashSet<CERTIFICADO_EMITIDO>();
            this.DETALLE_OFERTA = new HashSet<DETALLE_OFERTA>();
            this.MENSAJERIA = new HashSet<MENSAJERIA>();
        }
    
        public int PUNTOS { get; set; }
        public string PERSONA_RUN { get; set; }
        public string USUARIO_USERNAME { get; set; }
    
        public virtual ICollection<CERTIFICADO_EMITIDO> CERTIFICADO_EMITIDO { get; set; }
        public virtual PERSONA PERSONA { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual ICollection<DETALLE_OFERTA> DETALLE_OFERTA { get; set; }
        public virtual ICollection<MENSAJERIA> MENSAJERIA { get; set; }
    }
}
