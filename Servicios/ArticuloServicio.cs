using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ArticuloServicio : IArticuloServicio
    {

        private _20211CTPContext dbContexto;

        public ArticuloServicio(_20211CTPContext ctx)
        {
            dbContexto = ctx;
        }
        public void Crear(Articulo entity, int idUsuario)
        {

            if (entity != null)
            {
                entity.FechaCreacion = DateTime.Now;
                if (idUsuario != 0) entity.CreadoPor = idUsuario;
                dbContexto.Articulos.Add(entity);
                dbContexto.SaveChanges();
            }
        }

        public void Modificar(Articulo entity, int idUsuario)
        {

            Articulo articulo = ObtenerPorId(entity.IdArticulo);
            if (articulo != null)
            {
                articulo.Codigo = entity.Codigo;
                articulo.Descripcion = entity.Descripcion;
                articulo.FechaModificacion = DateTime.Now;
                if (idUsuario != 0) articulo.ModificadoPor = idUsuario;
                dbContexto.SaveChanges();
            }
        }
        public void Borrar(Articulo entity, int idUsuario)
        {
            var fecha = DateTime.Now;
            if (entity != null)
            {
                entity.FechaBorrado = fecha;
                if (idUsuario != 0) entity.BorradoPor = idUsuario;
                dbContexto.SaveChanges();
            }
        }
        public void BorrarPorId(int idArticulo, int idUsuario)
        {

            var articulos = from a in dbContexto.Articulos where a.IdArticulo == idArticulo select a;

            Articulo articulo = articulos.FirstOrDefault();

            if (articulo != null)
            {
                articulo.FechaBorrado = DateTime.Now;
                if (idUsuario != 0) articulo.BorradoPor = idUsuario;
                dbContexto.SaveChanges();
            }
        }
        public List<Articulo> listarPorCodigo(string codigo)
        {
            var articulos = from a in dbContexto.Articulos
                            where a.Codigo == codigo
                            orderby a.Codigo ascending
                            select a;

            return articulos.ToList();
        }

        public List<Articulo> listarPorDescripcion(string descripcion)
        {
            var articulos = from a in dbContexto.Articulos
                            where a.Descripcion == descripcion
                            orderby a.Codigo ascending
                            select a;

            return articulos.ToList();
        }

        public List<Articulo> listarPorCodigoYDescripcion(string codigo, string descripcion)
        {
            var articulos = from a in dbContexto.Articulos
                            where a.Codigo == codigo && a.Descripcion == descripcion
                            orderby a.Codigo ascending
                            select a;

            return articulos.ToList();
        }

        public Articulo ObtenerPorId(int id)
        {
            var articulos = from a in dbContexto.Articulos where a.IdArticulo == id select a;

            Articulo articulo = articulos.FirstOrDefault();
            if (articulo != null) return articulo;

            return null;
        }

        public List<Articulo> ListarTodos()
        {
            var articulos = from a in dbContexto.Articulos orderby a.Codigo ascending select a;

            return articulos.ToList();
        }

        public List<Articulo> ListarNoEliminados()
        {
            var articulos = from a in dbContexto.Articulos
                            where a.FechaBorrado == null
                            orderby a.Codigo ascending
                            select a;

            return articulos.ToList();
        }
        public List<ArticuloDTO> mapearListaArticuloAListaArticuloDTO(List<Articulo> articulos)
        {
            List<ArticuloDTO> articulosDTO = new List<ArticuloDTO>();
            foreach (Articulo articulo in articulos)
            {
                ArticuloDTO articuloDTO = new ArticuloDTO();

                articuloDTO.IdArticulo =articulo.IdArticulo;
                articuloDTO.Codigo= articulo.Codigo;
                articuloDTO.Descripcion = articulo.Descripcion;
               
                articulosDTO.Add(articuloDTO);
            }
            return articulosDTO;
        }
    }

}


