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
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [CustomOnlyString(ErrorMessage = ValidationConstants.OnlyString)]
        public string Name { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        public int Number { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        [MinLength(8, ErrorMessage = ValidationConstants.MinLengthEightDigits)]
        [MaxLength(10, ErrorMessage = ValidationConstants.MaxLengthTenDigits)]
        public int PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = ValidationConstants.InvalidEmailFormat)]
        public string Email { get; set; }
        public string Direccion { get; set; }

        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
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
