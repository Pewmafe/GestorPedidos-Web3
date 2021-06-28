using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IArticuloServicio : IBaseServicio<Articulo>
    {

        List<Articulo> listarPorCodigo(string codigo);
        List<Articulo> listarPorDescripcion(string descripcion);
        List<Articulo> listarPorCodigoYDescripcion(string codigo, string descripcion);
    }
}
