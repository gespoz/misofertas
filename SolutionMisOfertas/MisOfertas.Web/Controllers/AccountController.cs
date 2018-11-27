using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MisOfertas.Web.Models;
using MisOfertas.Cqrs.Infrastructure;
using MisOfertas.Negocio.Models;
using System.Collections.Generic;
using MisOfertas.Datos;

namespace MisOfertas.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Autherize(MisOfertas.Web.Models.LoginViewModel model)
        {
            Session["userName"] = null;
            Session["rutConsu"] = null;
            Session["ptsConsu"] = null;

            using (var db = new MisOfertas.Datos.MisOfertasEntities())
            {
                var userDetails = db.USUARIO.Where(x => x.USERNAME == model.User && x.PASSWORD == model.Pass).FirstOrDefault();
                
                if (userDetails == null)
                {
                    model.LoginErrorMessage = "Usuario o Contraseña Incorrecta.";
                    return View("Login", model);
                }
                else
                {
                    var consuDetails = db.CONSUMIDOR.Where(x => x.USUARIO_USERNAME == userDetails.USERNAME).FirstOrDefault();
                    Session["userName"] = userDetails.USERNAME;
                    Session["rutConsu"] = consuDetails.PERSONA_RUN;
                    Session["ptsConsu"] = consuDetails.PUNTOS;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Register(MisOfertas.Web.Models.RegistroLogin model)
        {
            if (ModelState.IsValid)
            {
                MisOfertas.Negocio.Models.Persona persona = new MisOfertas.Negocio.Models.Persona()
                {
                    Run = model.Run,
                    Nombre = model.Nombre,
                    Paterno = model.Paterno,
                    Materno = model.Materno,
                    Sexo = model.Sexo,
                    FecNac = model.Fecnac,
                    Email = model.Email
                };
                MisOfertas.Negocio.Models.Usuario usuario = new MisOfertas.Negocio.Models.Usuario()
                {
                    Username = model.User,
                    Password = model.Pass,
                    Perfil = "Consumidor"
                };

                if (persona.Agregar() == true && usuario.Agregar() == true)
                {
                    MisOfertas.Negocio.Models.Consumidor consumidor = new MisOfertas.Negocio.Models.Consumidor()
                    {
                        RunPersona = model.Run,
                        Puntos = 0,
                        Username = model.User
                    };

                    consumidor.Agregar();
                }
                else
                {
                    model.LoginErrorMessage = "No se pudo ingresar al usuario.";
                }

                return RedirectToAction("Login", "Account");
            }
            model.LoginErrorMessage = "Usuario no registrado.";
            return View("Register", model);

        }
        
    }
}