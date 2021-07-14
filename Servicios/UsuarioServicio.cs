using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private _20211CTPContext _context;

        public UsuarioServicio(_20211CTPContext context)
        {
            _context = context;
        }

        public void Crear(Usuario usuario, int idUsuario)
        {

            usuario.CreadoPor = idUsuario;

            usuario.ModificadoPor = idUsuario;

            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public void Borrar(Usuario entity, int idUsuario)
        {

        }

        public void BorrarPorId(int id, int idUsuario)
        {
            Usuario usuario = _context.Usuarios.Find(id);

            usuario.FechaModificacion = DateTime.Now;
            usuario.FechaBorrado = DateTime.Now;
            usuario.BorradoPor = idUsuario;

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

        public void Modificar(Usuario usuario, int idUsuario)
        {
            Usuario usuarioActualizado = ObtenerPorId(usuario.IdUsuario);

            usuarioActualizado.Nombre = usuario.Nombre;
            usuarioActualizado.Apellido = usuario.Apellido;
            usuarioActualizado.Email = usuario.Email;
            usuarioActualizado.Password = usuario.Password;
            usuarioActualizado.EsAdmin = usuario.EsAdmin;
            usuarioActualizado.FechaNacimiento = usuario.FechaNacimiento;
            usuarioActualizado.FechaModificacion = DateTime.Now;
            usuarioActualizado.ModificadoPor = idUsuario;

            _context.SaveChanges();


        }

        public List<Usuario> ListarNoEliminados()
        {

            List<Usuario> usuariosNoEliminados = _context.Usuarios.Where(u => u.FechaBorrado == null).ToList();


            return usuariosNoEliminados;

        }

        public List<UsuarioDTO> mapearListaUsuariosAListaUsuariosDTO(List<Usuario> usuarios)
        {
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            foreach (Usuario usuario in usuarios)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO();

                usuarioDTO.Email = usuario.Email;
                usuarioDTO.IdUsuario = usuario.IdUsuario;
                usuarioDTO.Nombre = usuario.Nombre;
                usuarioDTO.Apellido = usuario.Apellido;
                usuarioDTO.FechaNacimiento = (DateTime)usuario.FechaNacimiento;


                usuariosDTO.Add(usuarioDTO);
            }
            return usuariosDTO;
        }
    }
    }

