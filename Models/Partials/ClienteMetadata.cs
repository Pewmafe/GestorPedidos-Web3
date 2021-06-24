using Models.Constants;
using Models.ValidationCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Partials
{
    public class ClienteMetadata
    {
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [CustomOnlyString(ErrorMessage = ValidationConstants.OnlyString)]
        public string Nombre { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        public int Numero { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        [MinLength(8, ErrorMessage = ValidationConstants.MinLengthEightDigits)]
        [MaxLength(10, ErrorMessage = ValidationConstants.MaxLengthTenDigits)]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = ValidationConstants.InvalidEmailFormat)]
        public string Email { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        public string Cuit { get; set; }
    }
}
