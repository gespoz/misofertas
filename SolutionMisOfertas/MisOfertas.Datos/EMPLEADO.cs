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
    
    public partial class EMPLEADO
    {
        public Nullable<int> IDREFERENCIA { get; set; }
        public string CARGO { get; set; }
        public string PERSONA_RUN { get; set; }
        public string USUARIO_USERNAME { get; set; }
    
        public virtual PERSONA PERSONA { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
