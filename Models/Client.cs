using Models.ValidationCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : IAuditable
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [CustomOnlyString(ErrorMessage = "Por favor no ingrese caracteres especiales.")]
        public string Name { get; set; }

        [CustomOnlyNumber(ErrorMessage ="Por favor ingrese solo numeros")]
        public int Number { get; set; }

        [CustomOnlyNumber(ErrorMessage = "Por favor ingrese solo numeros")]
        [MinLength(8, ErrorMessage = "Por favor ingrese al menos 8 digitos")]
        [MaxLength(10, ErrorMessage = "Por favor ingrese como mucho 10 digitos")]
        public int PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Por favor ingrese un formato de email valido.")]
        public string Email { get; set; }
        public string Direccion { get; set; }

        [CustomOnlyNumber(ErrorMessage = "Por favor ingrese solo numeros")]
        public int Cuit { get; set; }
        public int CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UpdateBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
