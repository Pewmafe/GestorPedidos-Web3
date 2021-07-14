using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ClienteServicio : IClienteServicio
    {

        private _20211CTPContext _dbContext;

        public ClienteServicio(_20211CTPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Crear(Cliente entity, int idUsuario)
        {
            if (entity != null) { 
            entity.CreadoPor = idUsuario;
            _dbContext.Clientes.Add(entity);
            _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("No se puede crear el cliente");
            }
        }

        public void Borrar(Cliente entity, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void BorrarPorId(int idCliente, int idUsuario)
        {

            Cliente objActual = ObtenerPorId(idCliente);
            if (objActual != null) { 
            objActual.FechaBorrado = DateTime.Now;
            objActual.BorradoPor = idUsuario;
            _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("No se puede eliminar el cliente. Cliente Inexistente");
            }
        }

        public List<Cliente> ListarTodos()
        {
            return _dbContext.Clientes.ToList();
        }

        public Cliente ObtenerPorId(int id)
        {
            Cliente cliente=  _dbContext.Clientes
                .FirstOrDefault(o => o.IdCliente == id);
            if (cliente != null)
            {
                return cliente;
            }
            else
            {
                throw new Exception("Cliente Inexistente");
            }
        }

        public void Modificar(Cliente entity, int idUsuario)
        {
            Cliente objActual = ObtenerPorId(entity.IdCliente);

            if (objActual != null) { 
            objActual.Nombre = entity.Nombre;
            objActual.Numero = entity.Numero;
            objActual.Telefono = entity.Telefono;
            objActual.Cuit = entity.Cuit;
            objActual.Email = entity.Email;
            objActual.Direccion = entity.Direccion;
            objActual.FechaModificacion = DateTime.Now;
            objActual.ModificadoPor = idUsuario;

            _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("No es posible modificar el cliente. Cliente Inexistente");
            }
        }

        public List<Cliente> ListarNoEliminados()
        {
            var clientes = from a in _dbContext.Clientes
                           where a.FechaBorrado == null
                           select a;

            return clientes.ToList();
        }

        public List<Cliente> listarClientesSinPedidosActivos()
        {
            List<Cliente> clientesSinPedidosActivos = new List<Cliente>();
            ListarNoEliminados().ForEach(a =>
            {
                if (!validarSiExistePedidoAbiertoDeUnClientePorIdCliente(a.IdCliente)) clientesSinPedidosActivos.Add(a);
            });

            return clientesSinPedidosActivos;

        }
        public List<ClienteDTO> mapearListaClienteAListaClienteDTO(List<Cliente> clientes)
        {
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
            foreach (Cliente cliente in clientes)
            {
                ClienteDTO clienteDTO = new ClienteDTO();

                clienteDTO.IdCliente = cliente.IdCliente;
                clienteDTO.Nombre = cliente.Nombre;
                clienteDTO.Numero = cliente.Numero;
                clienteDTO.Telefono = cliente.Telefono;
                clienteDTO.Direccion = cliente.Direccion;

                clientesDTO.Add(clienteDTO);
            }
            return clientesDTO;
        }

        public List<Cliente> ListarPorFiltro(string Filtro)
        {
            return _dbContext.Clientes
                .Where(p => p.Nombre.Contains(Filtro))
                .ToList();
        }
        public bool validarSiExistePedidoAbiertoDeUnClientePorIdCliente(int idCliente)
        {
            return _dbContext.Pedidos.Where(p => p.IdCliente == idCliente && p.IdEstado == 1 && p.FechaBorrado == null).Count() > 0;
        }
        public bool emailExistente(string email)
        {
            Cliente clienteExistente = _dbContext.Clientes.Where(o => o.Email == email).FirstOrDefault();
            if (clienteExistente == null)
            {
                return false;
            }

            return true;
        }
    }
}
