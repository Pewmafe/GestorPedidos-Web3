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
                if (idUsuario != 0)
                {
                    entity.CreadoPor = idUsuario;
                }
                dbContexto.Articulos.Add(entity);
                dbContexto.SaveChanges();
            }
            else
            {
                throw new Exception("No se puede crear el articulo");
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
            else
            {
                throw new Exception("Articulo Inexistente");
            }
        }
        public void Borrar(Articulo entity, int idUsuario)
        {
            var articulos = from a in dbContexto.Articulos where a.IdArticulo == entity.IdArticulo select a;

            Articulo articulo = articulos.FirstOrDefault();


            if (articulo != null)
            {
                articulo.FechaBorrado = DateTime.Now;
                articulo.FechaModificacion = DateTime.Now;


                if (idUsuario != 0)
                {
                    articulo.BorradoPor = idUsuario;
                    articulo.ModificadoPor = idUsuario;
                }
                dbContexto.SaveChanges();
            }
            else
            {
                throw new Exception("No se puede eliminar el articulo. Articulo Inexistente");
            }

            EliminarArticuloDeLosPedidos(entity.IdArticulo);

        }
        public void BorrarPorId(int idArticulo, int idUsuario)
        {

            var articulos = from a in dbContexto.Articulos where a.IdArticulo == idArticulo select a;

            Articulo articulo = articulos.FirstOrDefault();


            if (articulo != null)
            {
                articulo.FechaBorrado = DateTime.Now;
                articulo.FechaModificacion = DateTime.Now;


                if (idUsuario != 0)
                {
                    articulo.BorradoPor = idUsuario;
                    articulo.ModificadoPor = idUsuario;
                }
                dbContexto.SaveChanges();
            }
            else
            {
                throw new Exception("No se puede eliminar el articulo. Articulo Inexistente");
            }

            EliminarArticuloDeLosPedidos(idArticulo);

        }

        public void EliminarArticuloDeLosPedidos(int idArticulo)
        {
            var articulos = from a in dbContexto.PedidoArticulos where a.IdArticulo == idArticulo select a;

            List<PedidoArticulo> articulosP = articulos.ToList();
            if (articulosP != null || articulosP.Count > 0)
            {
                dbContexto.PedidoArticulos.RemoveRange(articulosP);
                dbContexto.SaveChanges();
            }

        }

        public Articulo ObtenerPorId(int id)
        {
            var articulos = from a in dbContexto.Articulos where a.IdArticulo == id select a;

            Articulo articulo = articulos.FirstOrDefault();
            if (articulo != null)
            {
                return articulo;

            }
            else
            {
                throw new Exception("Articulo Inexistente");

            }


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

                articuloDTO.IdArticulo = articulo.IdArticulo;
                articuloDTO.Codigo = articulo.Codigo;
                articuloDTO.Descripcion = articulo.Descripcion;

                articulosDTO.Add(articuloDTO);
            }
            return articulosDTO;
        }

        public List<Articulo> ListarPorFiltro(string Filtro)
        {
            var articulos = from a in dbContexto.Articulos
                            where a.Descripcion.Contains(Filtro)
                            orderby a.Codigo ascending
                            select a;

            return articulos.ToList();
        }
    }

}


