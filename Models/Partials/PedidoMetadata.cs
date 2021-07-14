using Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace Models.Partials
{
    public class PedidoMetadata
    {

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public int IdCliente { get; set; }
        [StringLength(8000, ErrorMessage = ValidationConstants.TextMax8000Characters)]
        public string Comentarios { get; set; }
    }
}
