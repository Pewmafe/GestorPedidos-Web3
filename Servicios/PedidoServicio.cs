using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PedidoServicio : IPedidoServicio, IBaseServicio<Pedido>
    {
        private _20211CTPContext _dbContext;

        public PedidoServicio(_20211CTPContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Crear(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public void Borrar(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Pedido ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Pedido entity)
        {
            throw new NotImplementedException();
        }
    }
}
