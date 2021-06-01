using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IBaseService<TEntity>
    {
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteByid(int id, string who);

    }
}