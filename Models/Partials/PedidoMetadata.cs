using Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class PedidoMetadata
    {
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        public string Comentarios { get; set; }
    }
}
