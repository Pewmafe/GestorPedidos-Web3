using Models.Constants;
using Models.ValidationCustom;
using System.ComponentModel.DataAnnotations;

namespace Models.Partials
{
    public class ClienteMetadata
    {
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [CustomOnlyString(ErrorMessage = ValidationConstants.OnlyString)]
        [StringLength(200, ErrorMessage = ValidationConstants.TextMax200Characters)]
        public string Nombre { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        public int Numero { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        [MinLength(8, ErrorMessage = ValidationConstants.MinLengthEightDigits)]
        [MaxLength(10, ErrorMessage = ValidationConstants.MaxLengthTenDigits)]
        [StringLength(50, ErrorMessage = ValidationConstants.TextMax50Characters)]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = ValidationConstants.InvalidEmailFormat)]
        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Email { get; set; }

        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Direccion { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        [StringLength(50, ErrorMessage = ValidationConstants.TextMax50Characters)]
        public string Cuit { get; set; }
    }
}
