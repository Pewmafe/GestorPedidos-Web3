using Models.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IPedidoServicio : IBaseServicio<Pedido>
    {
        int CrearPedido(Pedido pedido);
        void VaciarCarrito();
        void AgregarArticuloAlCarritoPorIdArticulo(int idArticulo);
        List<Articulo> DevolverCarrito();
        void CrearArticuloPedidoPorIdPedidoConListaActual(int idPedido);



        bool validarSiExistePedidoAbiertoDeUnClientePorIdCliente(int idCliente);

        void CrearPedidoArticulo(PedidoArticulo entity);
        List<PedidoArticulo> listarPedidoArticuloPorIdPedido(int idPedido);

        Dictionary<Articulo, int> listarArticulosConCantidadesDeUnPedidoPorPedidoId(int idPedido);

        void EliminarArticuloAlPedido(PedidoArticulo pedidoArticulo);
        PedidoArticulo BuscarPedidoArticuloPorIdPedidoYIdArticulo(int idPedido, int idArticulo);
    }
}
