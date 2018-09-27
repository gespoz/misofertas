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
}
