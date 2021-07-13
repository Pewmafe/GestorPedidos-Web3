using Models.Models;
using System.Collections.Generic;

namespace GestorPedidos.Models
{
    public class EditarPedidoViewModel
    {
        public Pedido Pedido { get; set; }
        public Dictionary<Articulo, int> ArticulosYCantidadesDelPedido { get; set; }
        public List<Articulo> ArticulosNoSeleccionados { get; set; }
    }
}
