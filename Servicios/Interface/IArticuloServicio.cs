using Models.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IArticuloServicio : IBaseServicio<Articulo>
    {
        List<Articulo> listarPorCodigo(string codigo);
        List<Articulo> listarPorDescripcion(string descripcion);
        List<Articulo> listarPorCodigoYDescripcion(string codigo, string descripcion);
    }
}
