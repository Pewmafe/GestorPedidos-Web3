﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class EstadoPedido
    {
        public EstadoPedido()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdEstadoPedido { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
