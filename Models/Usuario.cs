using Models.ValidationCustom;
using Models.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Usuario : IAuditable
    {
        public int Id { get; set; }

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

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
   
}
