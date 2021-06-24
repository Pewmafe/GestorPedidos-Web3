using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClienteServicio : IClienteServicio
    {
        public void Crear(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Borrar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void BorrarPorId(int id)
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

        Models.Models.Cliente IBaseServicio<Models.Models.Cliente>.ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        List<Models.Models.Cliente> IBaseServicio<Models.Models.Cliente>.ListarTodos()
        {
            throw new NotImplementedException();
        }

        public List<Models.Models.Cliente> ListarNoEliminados()
        {
            throw new NotImplementedException();
        }

        public void Crear(Models.Models.Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Models.Models.Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Borrar(Models.Models.Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
