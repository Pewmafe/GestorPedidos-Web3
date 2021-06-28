using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClienteServicio : IClienteServicio
    {

        private _20211CTPContext _dbContext;

        public ClienteServicio(_20211CTPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Crear(Cliente entity)
        {
            _dbContext.Clientes.Add(entity);
            _dbContext.SaveChanges();
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
            return _dbContext.Clientes.ToList();
        }

        public Cliente ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarNoEliminados()
        {
            var clientes = from a in _dbContext.Clientes
                            where a.FechaBorrado == null && a.BorradoPor == null
                            select a;

            return clientes.ToList();
        }
    }
}
