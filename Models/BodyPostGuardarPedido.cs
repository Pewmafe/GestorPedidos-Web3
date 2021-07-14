using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Models
{
    public class BodyPostGuardarPedido
    {

        public int IdUsuario { get; set; }

        public int IdCliente { get; set; }

        public List<PedidoArticulo> pedidosArticulos { get; set; }
    }
}
