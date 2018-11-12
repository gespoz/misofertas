using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MisOfertas.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Formato ingresado no corresponde.")]
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
        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo se admiten caracteres en nombre.")]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo se admiten caracteres en apellido paterno.")]
        public string Paterno { get; set; }

        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo se admiten caracteres en apellido materno.")]
        public string Materno { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecnac { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z \.]*$",
        ErrorMessage = "Formato de usuario solo admite caracteres")]
        public string User { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }

        public string LoginErrorMessage { get; set; }

        public string Perfil { get; set; }
        public int Puntos { get; set; }
        public string SexoValida { get; set; }

        [Range(1, int.MaxValue)]
        [EnumDataType(typeof(SexoRegistro))]
        public SexoRegistro SexoReg { get; set; }
    }

    public enum SexoRegistro
    {
        Seleccione,
        Mujer,
        Hombre
    }
}
