using Models.ValidationCustom;
using Models.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Pedido : IAuditable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        public int Code { get; set; }
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
