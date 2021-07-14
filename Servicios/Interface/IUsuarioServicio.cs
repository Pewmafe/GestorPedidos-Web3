using Models.DTO;
using Models.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IUsuarioServicio : IBaseServicio<Usuario>
    {
        public List<UsuarioDTO> mapearListaUsuariosAListaUsuariosDTO(List<Usuario> usuarios);
        public List<UsuarioDatatableDTO> mapearListaUsuariosAListaUsuariosDatatableDTO(List<Usuario> usuarios);
    }
}
