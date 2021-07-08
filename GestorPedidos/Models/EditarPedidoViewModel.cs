using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorPedidos.Models
{
    public class EditarPedidoViewModel
    {
        public Pedido Pedido { get; set; }
        public Dictionary<Articulo, int> ArticulosYCantidadesDelPedido { get; set; }
        public List<Articulo> ArticulosNoSeleccionados { get; set; }
    }
}
