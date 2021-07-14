using Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class PedidoArticuloMetadata
    {
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public int IdArticulo { get; set; }
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public int Cantidad { get; set; }
    }
}
