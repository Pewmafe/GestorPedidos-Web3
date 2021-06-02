using Models.ValidationCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User : IAuditable
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [EmailAddress(ErrorMessage ="Por favor ingrese un formato de email valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [CustomOnlyString(ErrorMessage ="Por favor no ingrese caracteres especiales.")]
        public string Name { get; set; }

        [CustomOnlyString(ErrorMessage = "Por favor no ingrese caracteres especiales.")]
        public string Surname { get; set; }

        [CustomFecha(ErrorMessage ="La fecha no debe ser mayor al dia de hoy")]
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
