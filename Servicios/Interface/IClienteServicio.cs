using Models.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IClienteServicio : IBaseServicio<Cliente>
    {
        List<Cliente> listarClientesSinPedidosActivos();
    }
}
