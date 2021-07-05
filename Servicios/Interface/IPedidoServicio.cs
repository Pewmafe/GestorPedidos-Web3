using Models.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IPedidoServicio : IBaseServicio<Pedido>
    {
        void Crear(Pedido entity, int IdCliente);
        void VaciarCarrito();
        void AgregarArticuloAlCarritoPorIdArticulo(int idArticulo);
        List<Articulo> DevolverCarrito();
        void CrearArticuloPedidoPorIdPedidoConListaActual(int idPedido);
    }
}
