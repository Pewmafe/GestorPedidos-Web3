using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public class PedidoArticuloServicio : IPedidoArticuloServicio
    {
        private _20211CTPContext _dbContext;

        public PedidoArticuloServicio(_20211CTPContext dbContext)
        {

            _dbContext = dbContext;
        }

        public void Borrar(PedidoArticulo entity, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void BorrarPorId(int id, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Crear(PedidoArticulo entity, int idUsuario)
        {
            if (entity.Cantidad <= 0) entity.Cantidad = 0;
            _dbContext.Add(entity);
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

        public void Modificar(PedidoArticulo entity, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public PedidoArticulo ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
