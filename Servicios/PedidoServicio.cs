using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PedidoServicio : IPedidoServicio
    {
        private _20211CTPContext _dbContext;

        public PedidoServicio(_20211CTPContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Crear(Pedido entity, int idUsuario)
        {
            _dbContext.Pedidos.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Borrar(Pedido entity, int idUsuario)
        {
            Pedido pedido = ObtenerPorId(entity.IdPedido);
            //pedido.IdEstadoNavigation.IdEstadoPedido = cerrado;
            //pedido.BorradoPor = "usuario";
            //pedido.ModificadoPor = "usuario";
            pedido.FechaModificacion = DateTime.Today;
            pedido.FechaBorrado = DateTime.Today;

            _dbContext.SaveChanges();
        }

        public void BorrarPorId(int id,int idUsuario)
        {
            Pedido pedido = ObtenerPorId(id);
            //pedido.IdEstadoNavigation.IdEstadoPedido = cerrado;
            //pedido.BorradoPor = "usuario";
            //pedido.ModificadoPor = "usuario";
            pedido.FechaModificacion = DateTime.Today;
            pedido.FechaBorrado = DateTime.Today;

            _dbContext.SaveChanges();

        }

        public List<Pedido> ListarTodos()
        {
            return _dbContext.Pedidos.ToList();
        }

        public Pedido ObtenerPorId(int id)
        {
            return _dbContext.Pedidos.FirstOrDefault(o => o.IdPedido == id);
        }

        public void Modificar(Pedido entity,int idUsuario)
        {
            Pedido pedido = ObtenerPorId(entity.IdPedido);
            pedido.IdCliente = entity.IdCliente;
            pedido.IdEstado = entity.IdEstado;
            //pedido.NroPedido= entity.NroPedido;  ¿numero de pedido se puede cambiar?
            pedido.Comentarios = entity.Comentarios;
            //pedido.ModificadoPor = "usuario";
            pedido.FechaModificacion = DateTime.Today;
            _dbContext.SaveChanges();
        }

        public List<Pedido> ListarNoEliminados()
        {
            return _dbContext.Pedidos.Where(o => o.FechaBorrado != null).ToList();
        }
    }
}
