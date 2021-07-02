using Models.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IArticuloServicio : IBaseServicio<Articulo>
    {
       
        List<Articulo> listarPorCodigo(string codigo);
        List<Articulo> listarPorDescripcion(string descripcion);
        List<Articulo> listarPorCodigoYDescripcion(string codigo, string descripcion);
        void Crear(Articulo entity, int idUsuario);
        void Borrar(Articulo entity, int idUsuario);
        void BorrarPorId(int idArticulo, int idUsuario);
        void Modificar(Articulo entity, int idUsuario);

    }
}
       

