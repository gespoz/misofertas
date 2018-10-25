using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Datos.Interfaces
{
    public interface IMoContext
    {
        //Agrega propiedades y metodos del modelo.
        DbSet<CERTIFICADO> Certificado { get; set; }
        DbSet<CONSUMIDOR> Consumidor { get; set; }
        DbSet<DETALLE_OFERTA> DetalleOferta { get; set; }
        DbSet<CERTIFICADO_EMITIDO> CertificadoEmitido { get; set; }
        DbSet<EMPLEADO> Empleado { get; set; }
        DbSet<EMPRESA> Empresa { get; set; }
        DbSet<LOTE> Lote { get; set; }
        DbSet<MENSAJERIA> Mensajeria { get; set; }
        DbSet<OFERTA> Oferta { get; set; }
        DbSet<PERSONA> Persona { get; set; }
        DbSet<PRODUCTO> Producto { get; set; }
        DbSet<REG_ERROR> RegError { get; set; }
        DbSet<REG_PRODUCTO> RegProducto { get; set; }
        DbSet<SUCURSAL> Sucursal { get; set; }
        DbSet<USUARIO> Usuario { get; set; }

        int SaveChanges();
    }
}
