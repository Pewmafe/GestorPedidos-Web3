using Models.DTO;
using Models.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IClienteServicio : IBaseServicio<Cliente>
    {
        List<Cliente> listarClientesSinPedidosActivos();
        List<ClienteDTO> mapearListaClienteAListaClienteDTO(List<Cliente> clientes);
        List<Cliente> ListarPorFiltro(string Filtro);

        bool emailExistente(string email);
    }
}
