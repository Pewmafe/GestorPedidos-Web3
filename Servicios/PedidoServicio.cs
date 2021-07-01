using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PedidoServicio : IPedidoServicio
    {
        private static List<Articulo> carrito = new List<Articulo>();
        private _20211CTPContext _dbContext;
        private IArticuloServicio articuloServicio;
        private IPedidoArticuloService pedidoArticuloService;

        public PedidoServicio(_20211CTPContext dbContext)
        {
            this.articuloServicio = new ArticuloServicio(dbContext);
            this.pedidoArticuloService = new PedidoArticuloService(dbContext);
            _dbContext = dbContext;
        }
        public void Crear(Pedido entity)
        {
            if (ListarTodos().Count == 0)
            {
                entity.NroPedido = 0;
            }
            else
            {
                /*Obtengo el ultimo id de pedido creado, para setearle un numero de pedido por default*/
                int ultimoIdPedido = ListarTodos().LastOrDefault().IdPedido + 1;
                entity.NroPedido = ultimoIdPedido * 10;
            }
            entity.IdEstado = 1;
            /*Guardamos el pedido sin todavia agregar los articulos*/
            _dbContext.Pedidos.Add(entity);
            _dbContext.SaveChanges();
            /**/
            int ultimoIdPedidoCreadoRecien = ListarTodos().LastOrDefault().IdPedido;
            CrearArticuloPedidoPorIdPedidoConListaActual(ultimoIdPedidoCreadoRecien);
            VaciarCarrito();
        }
        public void Crear(Pedido entity, int IdCliente)
        {
            if (ListarTodos().Count == 0)
            {
                entity.NroPedido = 0;
            }
            else
            {
                /*Obtengo el ultimo id de pedido creado, para setearle un numero de pedido por default*/
                int ultimoIdPedido = ListarTodos().LastOrDefault().IdPedido + 1;
                entity.NroPedido = ultimoIdPedido * 10;
            }
            entity.IdEstado = 1;
            entity.IdCliente = IdCliente;
            /*Guardamos el pedido sin todavia agregar los articulos*/
            _dbContext.Pedidos.Add(entity);
            _dbContext.SaveChanges();
            /**/
            int ultimoIdPedidoCreadoRecien = ListarTodos().LastOrDefault().IdPedido;
            CrearArticuloPedidoPorIdPedidoConListaActual(ultimoIdPedidoCreadoRecien);
            VaciarCarrito();
        }

        public void Borrar(Pedido entity)
        {
            Pedido pedido = ObtenerPorId(entity.IdPedido);
            //pedido.IdEstadoNavigation.IdEstadoPedido = cerrado;
            //pedido.BorradoPor = "usuario";
            //pedido.ModificadoPor = "usuario";
            pedido.FechaModificacion = DateTime.Today;
            pedido.FechaBorrado = DateTime.Today;

            _dbContext.SaveChanges();
        }

        public void BorrarPorId(int id)
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

        public void Modificar(Pedido entity)
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

        public void AgregarArticuloAlCarritoPorIdArticulo(int idArticulo)
        {
            Articulo articulo = this.articuloServicio.ObtenerPorId(idArticulo);
            carrito.Add(articulo);
        }

        public List<Articulo> DevolverCarrito()
        {
            return carrito;
        }

        public void VaciarCarrito()
        {
            carrito.Clear();
        }

        public void CrearArticuloPedidoPorIdPedidoConListaActual(int idPedido)
        {
            carrito.ForEach(a => this.pedidoArticuloService
                .Crear(new PedidoArticulo
                { IdPedido = idPedido, IdArticulo = a.IdArticulo }
            ));
        }
    }
}
