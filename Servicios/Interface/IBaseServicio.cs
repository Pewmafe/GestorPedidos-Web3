using System.Collections.Generic;

namespace Service
{
    public interface IBaseServicio<TEntity>
    {
        TEntity ObtenerPorId(int id);
        List<TEntity> ListarTodos();
        List<TEntity> ListarNoEliminados();
        void Crear(TEntity entity, int idUsuario);
        void Modificar(TEntity entity, int idUsuario);
        void Borrar(TEntity entity, int idUsuario);
        void BorrarPorId(int id, int idUsuario);
    }
}