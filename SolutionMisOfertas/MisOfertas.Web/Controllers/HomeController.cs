
using MisOfertas.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisOfertas.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Models.HomeView()
            {
                FechaValoracion = DateTime.Now,
                OfertasTabla = new List<Models.OfertasHome>()          
            };

            var tabla = getOfertas();

            foreach (var l in tabla)
            {
                model.OfertasTabla.Add(new Models.OfertasHome
                {
                    Imagen = l.Imagen,
                    Disponible = l.Disponible,
                    Nombre = l.Nombre,
                    Valoracion = l.Valoracion,
                    Descripcion = l.Descripcion,
                    Valor = l.Valor,
                    Id = l.Id
                });
            }

            return View(model);
        }

        private List<OfertasHome> getOfertas()
        {
            using (var db = new MisOfertas.Datos.MisOfertasEntities())
            {
                var lista = db.OFERTA.Join(db.PRODUCTO,x=>x.PRODUCTO_ID_PROD,y=>y.ID_PROD,(x,y)=>new { X = x, Y = y}).Select(item=> new OfertasHome()
                {
                    Imagen = item.X.IMG_OFERTA,
                    Valoracion = item.X.VALORACION_TOTAL,
                    Disponible = item.Y.ESTADO,
                    Nombre = item.Y.NOMBRE,
                    Descripcion = item.X.DESCRIPCION,
                    Valor = item.Y.VALOR,
                    Id = item.X.ID_OFERTA
                }).ToList();
                return lista;
            }           
        }

        private List<OfertasHome> getOfertasFiltroTodos(int valoracion)
        {
            using (var db = new MisOfertas.Datos.MisOfertasEntities())
            {
                var lista = db.OFERTA.Join(db.PRODUCTO, x => x.PRODUCTO_ID_PROD, y => y.ID_PROD, (x, y) => new { X = x, Y = y }).Where(x=>x.X.VALORACION_TOTAL == valoracion).Select(item => new OfertasHome()
                {
                    Imagen = item.X.IMG_OFERTA,
                    Valoracion = item.X.VALORACION_TOTAL,
                    Disponible = item.Y.ESTADO,
                    Nombre = item.Y.NOMBRE,
                    Descripcion = item.X.DESCRIPCION,
                    Valor = item.Y.VALOR,
                    Id = item.X.ID_OFERTA
                }).ToList();
                return lista;
            }
        }

        private List<OfertasHome> getOfertasFiltroTodosRubro(string rubro)
        {
            using (var db = new MisOfertas.Datos.MisOfertasEntities())
            {
                var lista = db.OFERTA.Join(db.PRODUCTO, x => x.PRODUCTO_ID_PROD, y => y.ID_PROD, (x, y) => new { X = x, Y = y }).Where(x => x.Y.RUBRO == rubro).Select(item => new OfertasHome()
                {
                    Imagen = item.X.IMG_OFERTA,
                    Valoracion = item.X.VALORACION_TOTAL,
                    Disponible = item.Y.ESTADO,
                    Nombre = item.Y.NOMBRE,
                    Descripcion = item.X.DESCRIPCION,
                    Valor = item.Y.VALOR,
                    Id = item.X.ID_OFERTA
                }).ToList();
                return lista;
            }
        }

        private List<OfertasHome> getOfertasFiltro(int valoracion, string rubro)
        {
            using (var db = new MisOfertas.Datos.MisOfertasEntities())
            {
                var lista = db.OFERTA.Join(db.PRODUCTO, x => x.PRODUCTO_ID_PROD, y => y.ID_PROD, (x, y) => new { X = x, Y = y }).Where(x => x.X.VALORACION_TOTAL == valoracion && x.Y.RUBRO == rubro).Select(item => new OfertasHome()
                {
                    Imagen = item.X.IMG_OFERTA,
                    Valoracion = item.X.VALORACION_TOTAL,
                    Disponible = item.Y.ESTADO,
                    Nombre = item.Y.NOMBRE,
                    Descripcion = item.X.DESCRIPCION,
                    Valor = item.Y.VALOR,
                    Id = item.X.ID_OFERTA
                }).ToList();
                return lista;
            }
        }

        public static Image ConvertirImagen(object bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            byte[] imgArray = (byte[])bytes;
            MemoryStream mem = new MemoryStream(imgArray);

            return Image.FromStream(mem);
        }
        
        [HttpPost]
        public ActionResult Index(MisOfertas.Web.Models.HomeView model)
        {
            var m = new Models.HomeView()
            {
                FechaValoracion = DateTime.Now,
                OfertasTabla = new List<Models.OfertasHome>()
            };

            if (model.RubroReg == 0)
            {
                if (model.Valoracion == 0)
                {
                    var tabla = getOfertas();

                    foreach (var l in tabla)
                    {
                        m.OfertasTabla.Add(new Models.OfertasHome
                        {
                            Imagen = l.Imagen,
                            Disponible = l.Disponible,
                            Nombre = l.Nombre,
                            Valoracion = l.Valoracion,
                            Descripcion = l.Descripcion,
                            Valor = l.Valor,
                            Id = l.Id
                        });
                    }
                }
                else
                {
                    var tabla = getOfertasFiltroTodos(model.Valoracion);

                    foreach (var l in tabla)
                    {
                        m.OfertasTabla.Add(new Models.OfertasHome
                        {
                            Imagen = l.Imagen,
                            Disponible = l.Disponible,
                            Nombre = l.Nombre,
                            Valoracion = l.Valoracion,
                            Descripcion = l.Descripcion,
                            Valor = l.Valor,
                            Id = l.Id
                        });
                    }
                }
            }
            else if (model.RubroReg != 0)
            {
                if (model.Valoracion == 0)
                {
                    var tabla = getOfertasFiltroTodosRubro(model.RubroReg.ToString());

                    foreach (var l in tabla)
                    {
                        m.OfertasTabla.Add(new Models.OfertasHome
                        {
                            Imagen = l.Imagen,
                            Disponible = l.Disponible,
                            Nombre = l.Nombre,
                            Valoracion = l.Valoracion,
                            Descripcion = l.Descripcion,
                            Valor = l.Valor,
                            Id = l.Id
                        });
                    }
                }
                else
                {
                    var tabla = getOfertasFiltro(model.Valoracion,model.RubroReg.ToString());

                    foreach (var l in tabla)
                    {
                        m.OfertasTabla.Add(new Models.OfertasHome
                        {
                            Imagen = l.Imagen,
                            Disponible = l.Disponible,
                            Nombre = l.Nombre,
                            Valoracion = l.Valoracion,
                            Descripcion = l.Descripcion,
                            Valor = l.Valor,
                            Id = l.Id
                        });
                    }

                    
                }
            }
            return View(m);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult More(int id)
        {
            Session["OfertasId"] = null;
            Models.OfertasHome item = (Models.OfertasHome)Session[""+id+""];

            var model = new MisOfertas.Web.Models.MoreInfo()
            {
                Ofertas = item
            };

            Session["OfertasId"] = item.Id;
            Session["model"] = model;
            return View(model);
        }

        public bool isValidContentType(string contentType)
        {
            return contentType.Equals("image/png") || contentType.Equals("image/jpg") || contentType.Equals("image/jpeg");
        }

        [HttpPost]
        public ActionResult More(Models.MoreInfo model)
        {
            var modeloIn = Session["model"];
            int conta = 0;
            if (model.Img == null)
            {
                ViewBag.Error = "Debe ingresar una imagen.";
                return View(modeloIn);
            }
            if (!isValidContentType(model.Img.ContentType))
            {
                ViewBag.Error = "Solo se permiten archivos JPG, JPEG y PNG.";
                return View(modeloIn);
            }
            if (model.Img.ContentLength<0)
            {
                ViewBag.Error = "Se debe ingresar una imagen.";
                return View(modeloIn);
            }
            var file = model.Img;
            var filename = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data"), filename);
            file.SaveAs(path);

            byte[] fileData = null;
            
            using (FileStream fs = System.IO.File.OpenRead(path))
            {
                var binaryReader = new BinaryReader(fs);
                fileData = binaryReader.ReadBytes((int)fs.Length);
            }

            var modelo = new Models.MoreInfo()
            {
                Valora = model.Valora,
                Imagen = fileData
            };

            MisOfertas.Negocio.Models.DetalleOferta detalle = new MisOfertas.Negocio.Models.DetalleOferta()
            {
                IdDetalle = conta + 3,
                FecValoracion = DateTime.Now,
                IdOferta = int.Parse(Session["OfertasId"].ToString()),
                ImgBoleta = modelo.Imagen, 
                Run = Session["rutConsu"].ToString(),
                Valoracion = modelo.Valora,
                Username = Session["userName"].ToString()
            };

            detalle.Agregar();

            MisOfertas.Negocio.Models.Consumidor consumidor = new MisOfertas.Negocio.Models.Consumidor()
            {
                Puntos = 10,
                RunPersona = Session["rutConsu"].ToString(),
                Username = Session["userName"].ToString()
            };

            consumidor.Modificar();
            ViewBag.Mensaje = "Valoracion Realizada. Se han agregado 10pts a su cuenta.";
            return View(modeloIn);
        }
    }
}