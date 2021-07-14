using Models.Models;
using Models.DTO;
using System.Collections.Generic;

namespace Service
{
    public interface IArticuloServicio : IBaseServicio<Articulo>
    {
       
        List<ArticuloDTO> mapearListaArticuloAListaArticuloDTO(List<Articulo> articulos);
        List<Articulo> ListarPorFiltro(string Filtro);
        PedidoArticulo BuscarArticuloEnLosPedidosPorIdArticulo(int idArticulo);
        void EliminarArticuloDeLosPedidos(PedidoArticulo pedidoArticulo);


    }
}
       

