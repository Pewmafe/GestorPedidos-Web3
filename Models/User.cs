using Models.ValidationCustom;
using Models.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User : IAuditable
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

        public int CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UpdateBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
   
}
