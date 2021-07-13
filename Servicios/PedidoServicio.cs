using Microsoft.EntityFrameworkCore;
using Models.Enum;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PedidoServicio : IPedidoServicio
    {
        private _20211CTPContext _dbContext;
        private IArticuloServicio articuloServicio;
        private IClienteServicio clienteServicio;


        public PedidoServicio(_20211CTPContext dbContext)
        {
            this.articuloServicio = new ArticuloServicio(dbContext);
            this.clienteServicio = new ClienteServicio(dbContext);
            _dbContext = dbContext;
        }
        public void Crear(Pedido entity, int idUsuario)
        { }

        public void Borrar(Pedido entity, int idUsuario)
        {
            Pedido pedido = ObtenerPorId(entity.IdPedido);
            pedido.IdEstadoNavigation.IdEstadoPedido = (int)EstadoPedidoEnum.CERRADO;
            pedido.BorradoPor = idUsuario;
            pedido.ModificadoPor = idUsuario;
            pedido.FechaModificacion = DateTime.Today;
            pedido.FechaBorrado = DateTime.Today;
            _dbContext.SaveChanges();
        }

        public void BorrarPorId(int id, int idUsuario)
        {
            Pedido pedido = ObtenerPorId(id);
            pedido.IdEstadoNavigation.IdEstadoPedido = (int)EstadoPedidoEnum.CERRADO;
            pedido.BorradoPor = idUsuario;
            pedido.ModificadoPor = idUsuario;
            pedido.FechaModificacion = DateTime.Today;
            pedido.FechaBorrado = DateTime.Today;
            _dbContext.SaveChanges();

        }

        public List<Pedido> ListarTodos()
        {
            return _dbContext.Pedidos
                .Include(p => p.PedidoArticulos)
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdEstadoNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .Include(p => p.BorradoPorNavigation)
                .ToList();
        }
        public List<Pedido> ListarNoEliminados()
        {
            return _dbContext.Pedidos.Where(o => o.FechaBorrado != null).ToList();
        }
        public Pedido ObtenerPorId(int id)
        {
            return _dbContext.Pedidos.Include(p => p.IdClienteNavigation).Include(p => p.IdEstadoNavigation).FirstOrDefault(o => o.IdPedido == id);
        }

        public void Modificar(Pedido entity, int idUsuario)
        {
            Pedido pedido = ObtenerPorId(entity.IdPedido);
            pedido.Comentarios = entity.Comentarios;
            pedido.ModificadoPor = idUsuario;
            pedido.FechaModificacion = DateTime.Today;
            _dbContext.SaveChanges();
        }


        public int CrearPedido(Pedido pedido)
        {

            if (!this.clienteServicio.validarSiExistePedidoAbiertoDeUnClientePorIdCliente(pedido.IdCliente))
            {
                pedido.IdEstado = (int)EstadoPedidoEnum.ABIERTO;
                int ultimoIdPedido = ListarTodos().LastOrDefault().IdPedido + 1;
                pedido.NroPedido = ultimoIdPedido * 10;

                _dbContext.Pedidos.Add(pedido);
                _dbContext.SaveChanges();
                return pedido.IdPedido;
            }
            throw new Exception("El cliente ya posee otro pedido abierto, modifique ese pedido");
        }



        public void CrearPedidoArticulo(PedidoArticulo entity)
        {
            if (entity.Cantidad <= 0) entity.Cantidad = 0;
            _dbContext.PedidoArticulos.Add(entity);
            _dbContext.SaveChanges();
        }

        public List<PedidoArticulo> listarPedidoArticuloPorIdPedido(int idPedido)
        {
            return _dbContext.PedidoArticulos.Include(a => a.IdArticuloNavigation).Include(a => a.IdPedidoNavigation).Where(pa => pa.IdPedido == idPedido).ToList();
        }

        public Dictionary<Articulo, int> listarArticulosConCantidadesDeUnPedidoPorPedidoId(int idPedido)
        {
            Dictionary<Articulo, int> diccionario = new();

            listarPedidoArticuloPorIdPedido(idPedido).ForEach(a => diccionario.Add(a.IdArticuloNavigation, a.Cantidad));

            return diccionario;
        }

        public void EliminarArticuloAlPedido(PedidoArticulo pedidoArticulo)
        {
            PedidoArticulo articuloEliminado = BuscarPedidoArticuloPorIdPedidoYIdArticulo(pedidoArticulo.IdPedido, pedidoArticulo.IdArticulo);
            _dbContext.PedidoArticulos.Remove(articuloEliminado);
            _dbContext.SaveChanges();
        }

        public PedidoArticulo BuscarPedidoArticuloPorIdPedidoYIdArticulo(int idPedido, int idArticulo)
        {
            try
            {
                return _dbContext.PedidoArticulos.Where(p => p.IdPedido == idPedido && p.IdArticulo == idArticulo).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("No existe un PedidoArticulo con los idPedido " + idPedido + " y el idArticulo " + idArticulo);
            }

        }

        public List<Articulo> listarArticulosNoSeleccionadosDeUnPedidoPorIdPedido(int idPedido)
        {
            List<Articulo> articulos = this.articuloServicio.ListarNoEliminados();
            List<PedidoArticulo> articulosDeUnPedido = listarPedidoArticuloPorIdPedido(idPedido);
            List<Articulo> articulosNoSeleccionados = new List<Articulo>();
            articulos.ForEach(a =>
            {
                bool aux = false;
                articulosDeUnPedido.ForEach(a2 =>
                {
                    if (a2.IdArticuloNavigation.IdArticulo == a.IdArticulo)
                    {
                        aux = true;
                        return;
                    }
                });
                if (!aux) articulosNoSeleccionados.Add(a);
            });

            return articulosNoSeleccionados;
        }
        public void MarcarPedidoComoCerrado(int idPedido, int idUsuario)
        {
            Pedido pedido = ObtenerPorId(idPedido);
            pedido.IdEstado = (int)EstadoPedidoEnum.CERRADO;
            pedido.BorradoPor = idUsuario;
            pedido.ModificadoPor = idUsuario;
            pedido.FechaModificacion = DateTime.Today;
            pedido.FechaBorrado = DateTime.Today;
            _dbContext.SaveChanges();
        }
        public void MarcarPedidoComoEntregado(int idPedido, int idUsuario)
        {
            Pedido pedido = ObtenerPorId(idPedido);
            pedido.IdEstado = (int)EstadoPedidoEnum.ENTREGADO;
            pedido.BorradoPor = idUsuario;
            pedido.ModificadoPor = idUsuario;
            pedido.FechaModificacion = DateTime.Today;
            pedido.FechaBorrado = DateTime.Today;
            _dbContext.SaveChanges();
        }

        public List<Pedido> ListarPedidosEntregados()
        {
            return _dbContext.Pedidos
                .Include(p => p.PedidoArticulos)
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdEstadoNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .Include(p => p.BorradoPorNavigation)
                .Where(p => p.IdEstado == (int)EstadoPedidoEnum.ENTREGADO).ToList();
        }

        public List<Pedido> ListarPedidosUltimosDosMeses()
        {
            return _dbContext.Pedidos
                .Include(p => p.PedidoArticulos)
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdEstadoNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .Include(p => p.BorradoPorNavigation)
                .Where(p => p.FechaModificacion >= new DateTime(DateTime.Now.Year, DateTime.Now.Month - 2, DateTime.Now.Day))
                .ToList();
        }
    }
}
