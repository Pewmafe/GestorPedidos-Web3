using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBaseServicio<TEntity>
    {
        TEntity ObtenerPorId(int id);
        List<TEntity> ListarTodos();
        void Crear(TEntity entity);
        void Modificar(TEntity entity);
        void Borrar(TEntity entity);
        void DeleteByid(int id);

    }
}