using Models.Constants;
using Models.ValidationCustom;
using System;
using System.ComponentModel.DataAnnotations;


namespace Models.Models
{
    public class UsuarioMetadata
    {

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [EmailAddress(ErrorMessage = ValidationConstants.InvalidEmailFormat)]
        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [CustomOnlyString(ErrorMessage = ValidationConstants.OnlyString)]
        [StringLength(100, ErrorMessage = ValidationConstants.TextMax100Characters)]
        public string Name { get; set; }

        [CustomOnlyString(ErrorMessage = ValidationConstants.OnlyString)]
        [StringLength(100, ErrorMessage = ValidationConstants.TextMax100Characters)]
        public string Surname { get; set; }

        [CustomFecha(ErrorMessage = ValidationConstants.InvalidDate)]
        public DateTime FechaNacimiento { get; set; }
    }
}
