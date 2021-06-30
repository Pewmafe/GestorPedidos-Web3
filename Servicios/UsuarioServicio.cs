using Models.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private _20211CTPContext _context;

        public UsuarioServicio(_20211CTPContext context)
        {
            _context = context;
        }
        
        public void Crear(Usuario usuario)
        {

            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public void Borrar(Usuario entity)
        {
            
        }

        public void BorrarPorId(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);

            _context.Remove(usuario);

            _context.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {

            return _context.Usuarios.ToList();
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);

            return usuario;
        }

        public void Modificar(Usuario usuario)
        {
           
        }

        public void Modificar(int IdUsuario, String Email, String Password, bool EsAdmin, String Nombre, String Apellido, DateTime FechaNacimiento)
        {
            Usuario usuario = ObtenerPorId(IdUsuario);

            usuario.Email = Email;
            usuario.Password = Password;
            usuario.EsAdmin = EsAdmin;
            usuario.Nombre = Nombre;
            usuario.Apellido = Apellido;
            usuario.FechaNacimiento = FechaNacimiento;
            usuario.FechaModificacion = DateTime.Today;

            _context.SaveChanges();


        }

        public List<Usuario> ListarNoEliminados()
        {
            throw new NotImplementedException();
        }

    }
}
