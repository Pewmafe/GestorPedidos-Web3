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
            entity.FechaBorrado = fecha;
            //falta borrado por
            dbContexto.SaveChanges();
        }

        public void Crear(Articulo entity)
        {
            var fecha = DateTime.Now;
            entity.FechaCreacion = fecha;
            //falta el creado por
            dbContexto.Articulos.Add(entity);
            dbContexto.SaveChanges();

        }

        public void DeleteByid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Articulo> ListarNoEliminados()
        {
            var articulos = from a in dbContexto.Articulos
                            where a.FechaBorrado==null && a.BorradoPor == null
                            select a;

            return articulos.ToList();
        }

        public List<Articulo> ListarTodos()
        {
            var articulos = from a in dbContexto.Articulos select a;

            return articulos.ToList();
        }

        public void Modificar(Articulo entity)
        {
            var fecha = DateTime.Now;
            Articulo articulo = ObtenerPorId(entity.IdArticulo);
            articulo.Codigo = entity.Codigo;
            articulo.Descripcion = entity.Descripcion;
            articulo.FechaModificacion = fecha;
            //falta modificado por

            dbContexto.SaveChanges();
        }

        public Articulo ObtenerPorId(int id)
        {
            var articulos = from a in dbContexto.Articulos where a.IdArticulo == id select a;

            Articulo articulo = articulos.FirstOrDefault();

            return articulo;
        }
    }
}
