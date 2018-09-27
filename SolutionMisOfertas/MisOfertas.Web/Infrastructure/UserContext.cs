using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MisOfertas.Negocio.Infrastructure;

namespace MisOfertas.Web.Infrastructure
{
    public class UserContext : IUserContext
    {
        public string GetName()
        {
            return "admin";
        }
    }
}