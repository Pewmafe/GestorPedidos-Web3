using Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace Models.Partials
{
    public class PedidoMetadata
    {

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public int IdCliente { get; set; }
    }
}
