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
        public void Borrar(Articulo entity)
        {
            var fecha = DateTime.Now;
            if (entity != null)
            {
                entity.FechaBorrado = fecha;
                //falta borrado por
                dbContexto.SaveChanges();
            }
        }

        public void Crear(Articulo entity)
        {
            var fecha = DateTime.Now;
            if (entity != null)
            {
                entity.FechaCreacion = fecha;
                //falta el creado por
                dbContexto.Articulos.Add(entity);
                dbContexto.SaveChanges();
            }
        }

        public void BorrarPorId(int id)
        {

            var articulos = from a in dbContexto.Articulos where a.IdArticulo == id select a;

            Articulo articulo = articulos.FirstOrDefault();
            var fecha = DateTime.Now;

            if (articulo != null)
            {
                articulo.FechaBorrado = fecha;
                //falta borrado por
                dbContexto.SaveChanges();
            }
        }

        public List<Articulo> ListarNoEliminados()
        {
            var articulos = from a in dbContexto.Articulos
                            where a.FechaBorrado == null
                            orderby a.Codigo ascending
                            select a;

            return articulos.ToList();
        }

        public List<Articulo> listarPorCodigo(string codigo)
        {
            var articulos = from a in dbContexto.Articulos
                            where a.Codigo == codigo
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

        public List<Articulo> listarPorDescripcion(string descripcion)
        {
            var articulos = from a in dbContexto.Articulos
                            where a.Descripcion == descripcion
                            orderby a.Codigo ascending
                            select a;

            return articulos.ToList();
        }

        public List<Articulo> ListarTodos()
        {
            var articulos = from a in dbContexto.Articulos orderby a.Codigo ascending select a;

            return articulos.ToList();
        }

        public void Modificar(Articulo entity)
        {
            var fecha = DateTime.Now;

            Articulo articulo = ObtenerPorId(entity.IdArticulo);
            if (articulo != null)
            {
                articulo.Codigo = entity.Codigo;
                articulo.Descripcion = entity.Descripcion;
                articulo.FechaModificacion = fecha;
                //falta modificado por

                dbContexto.SaveChanges();
            }
        }

        public Articulo ObtenerPorId(int id)
        {
            /*var articulos = from a in dbContexto.Articulos where a.IdArticulo == id select a;

            Articulo articulo = articulos.FirstOrDefault();
            return articulo;*/

            return dbContexto.Articulos.FirstOrDefault(a => a.IdArticulo == id);
        }
    }
}
