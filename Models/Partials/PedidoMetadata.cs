using Models.Constants;
using Models.ValidationCustom;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class PedidoMetadata
    {
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [CustomOnlyNumber(ErrorMessage = ValidationConstants.OnlyNumber)]
        public int Code { get; set; }
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public string Description { get; set; }
    }
}
