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
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [CustomOnlyString(ErrorMessage = ValidationConstants.OnlyString)]
        public string Name { get; set; }

        [CustomOnlyString(ErrorMessage = ValidationConstants.OnlyString)]
        public string Surname { get; set; }

        [CustomFecha(ErrorMessage = ValidationConstants.InvalidDate)]
        public DateTime FechaNacimiento { get; set; }
    }
}
