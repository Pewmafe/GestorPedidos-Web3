using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enum;
using Models.Models;

namespace Models.DTO
{
   public class PedidoDTO
    {

        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public String Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public UsuarioDTO ModificadoPor { get; set; }
        public List<ArticuloDTO> Articulos { get; set; }



    }
}
