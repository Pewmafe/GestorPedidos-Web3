using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UsuarioServicio : IUsuarioServicio, IBaseServicio<Usuario>
    {
        public void Crear(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Borrar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
