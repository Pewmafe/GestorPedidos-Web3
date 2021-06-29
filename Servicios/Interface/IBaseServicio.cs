using System.Collections.Generic;

namespace Service
{
    public interface IBaseServicio<TEntity>
    {
        TEntity ObtenerPorId(int id);
        List<TEntity> ListarTodos();
        List<TEntity> ListarNoEliminados();
        void Crear(TEntity entity);
        void Modificar(TEntity entity);
        void Borrar(TEntity entity);
        void BorrarPorId(int id);
    }
}