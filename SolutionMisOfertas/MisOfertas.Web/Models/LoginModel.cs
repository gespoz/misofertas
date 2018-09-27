using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MisOfertas.Web.Models
{
    public class LoginModel
    {
        public int Idlogin { get; set; }
        [Required]
        public string User { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Pass { get; set; }
        public string Perfil { get; set; }
    }
}