using System;
using System.ComponentModel.DataAnnotations;
using Models.Constants;
using Models.ValidationCustom;

namespace Models.Partials
{
   public class UsuarioMetadata
    {

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public bool EsAdmin { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [StringLength(100, ErrorMessage = ValidationConstants.TextMax100Characters)]
        public string Apellido { get; set; }
       
        [CustomFecha(ErrorMessage = ValidationConstants.InvalidDate)]
        public DateTime FechaNacimiento { get; set; }
    }
}
