using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClienteServicio : IClienteServicio, IBaseServicio<Cliente>
    {
        public void Crear(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Borrar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Cliente ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
