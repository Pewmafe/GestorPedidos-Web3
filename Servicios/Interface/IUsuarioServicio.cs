using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUsuarioServicio : IBaseServicio<Usuario>
    {
        public void Modificar(int IdUsuario, String Email, String Password, bool EsAdmin, String Nombre, String Apellido, DateTime FechaNacimiento);

    }

}
