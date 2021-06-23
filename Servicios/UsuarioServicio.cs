using Models.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private _20211CTPContext _dbContext;

        public UsuarioServicio(_20211CTPContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Crear(Usuario entity)
        {
            _dbContext.Usuarios.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Borrar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarNoEliminados()
        {
            throw new NotImplementedException();
        }
    }
}
