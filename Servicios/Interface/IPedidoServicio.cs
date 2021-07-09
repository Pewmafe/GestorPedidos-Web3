using Models.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IPedidoServicio : IBaseServicio<Pedido>
    {
        int CrearPedido(Pedido pedido);
        bool validarSiExistePedidoAbiertoDeUnClientePorIdCliente(int idCliente);
        void CrearPedidoArticulo(PedidoArticulo entity);
        List<PedidoArticulo> listarPedidoArticuloPorIdPedido(int idPedido);
        Dictionary<Articulo, int> listarArticulosConCantidadesDeUnPedidoPorPedidoId(int idPedido);
        void EliminarArticuloAlPedido(PedidoArticulo pedidoArticulo);
        PedidoArticulo BuscarPedidoArticuloPorIdPedidoYIdArticulo(int idPedido, int idArticulo);
        List<Articulo> listarArticulosNoSeleccionadosDeUnPedidoPorIdPedido(int idPedido);
        void MarcarPedidoComoCerrado(int idPedido, int idUsuario);
        void MarcarPedidoComoEntregado(int idPedido, int idUsuario);
    }
}
