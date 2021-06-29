using System.ComponentModel.DataAnnotations;
using Models.Constants;

namespace Models.Models
{
    class ArticuloMetadata
    {
        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [StringLength(50, ErrorMessage = ValidationConstants.TextMax50Characters)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Descripcion { get; set; }
    }
}
