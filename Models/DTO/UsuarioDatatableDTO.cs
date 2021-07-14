using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
   public class UsuarioDatatableDTO
    {

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int FechaBorrado { get; set; }

    }
}
