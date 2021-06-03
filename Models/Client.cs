using Models.ValidationCustom;
using Models.Constants;
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
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [CustomOnlyString(ErrorMessage = ValidationConstants.OnlyString)]
        public string Name { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        public string Number { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        [MinLength(8, ErrorMessage = ValidationConstants.MinLengthEightDigits)]
        [MaxLength(10, ErrorMessage = ValidationConstants.MaxLengthTenDigits)]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = ValidationConstants.InvalidEmailFormat)]
        public string Email { get; set; }
        public string Address { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        public string Cuit { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
