using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Constants;

namespace Models.Partials
{
    class ArticuloMetadata
    {
        [Required(ErrorMessage =ValidationConstants.RequiredField)]
        [StringLength(50, ErrorMessage =ValidationConstants.TextMax50Characters)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredField)]
        [StringLength(300, ErrorMessage = ValidationConstants.TextMax300Characters)]
        public string Descripcion { get; set; }
    }
}
