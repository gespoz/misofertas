﻿
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
                    Valoracion = l.Valoracion
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
                    Nombre = item.Y.NOMBRE
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
                    Nombre = item.Y.NOMBRE
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
                    Nombre = item.Y.NOMBRE
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
                    Nombre = item.Y.NOMBRE
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
                            Valoracion = l.Valoracion
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
                            Valoracion = l.Valoracion
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
                            Valoracion = l.Valoracion
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
                            Valoracion = l.Valoracion
                        });
                    }
                }
            }
            return View(m);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}