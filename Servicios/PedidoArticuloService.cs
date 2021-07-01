using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PedidoArticuloService : IPedidoArticuloService
    {
        private _20211CTPContext _dbContext;

        public PedidoArticuloService(_20211CTPContext dbContext)
        {

            _dbContext = dbContext;
        }
        public void Borrar(PedidoArticulo entity)
        {
            throw new NotImplementedException();
        }

        public void BorrarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Crear(PedidoArticulo entity)
        {
            _dbContext.PedidoArticulos.Add(entity);
            _dbContext.SaveChanges();
        }

        public List<PedidoArticulo> ListarNoEliminados()
        {
            throw new NotImplementedException();
        }

        public List<PedidoArticulo> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Modificar(PedidoArticulo entity)
        {
            throw new NotImplementedException();
        }

        public PedidoArticulo ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
