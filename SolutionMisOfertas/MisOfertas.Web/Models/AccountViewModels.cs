using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisOfertas.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }

        public string LoginErrorMessage { get; set; }
    }

    public class RegistroLogin
    {
        [Required]
        public string Run { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Paterno { get; set; }
        public string Materno { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecnac { get; set; }

        [Required]
        public string User { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }

        public string LoginErrorMessage { get; set; }

        public int Puntos { get; set; }
    }
}
