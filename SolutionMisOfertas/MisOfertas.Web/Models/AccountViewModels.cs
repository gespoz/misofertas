using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
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


        //[Range(1, 2, ErrorMessage = "Debe seleccionar un sexo")]
        //[EnumDataType(typeof(SexoRegistro))]
        //public SexoRegistro SexoReg { get; set; }

        public rutValida RutValido { get; set; }
    }

    public class rutValida
    {
        public static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }
        
        public static bool ValidaRut(string rut, string dv)
        {
            return ValidaRut(rut + "-" + dv);
        }
        
        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }
    }

    public enum SexoRegistro
    {
        Seleccione,
        Mujer,
        Hombre
    }
}
