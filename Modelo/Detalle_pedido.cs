﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    public class Detalle_pedido
    {
        [Key]
        public int id_detalle { get; set; }
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public int id_proveedor { get; set; }
        public int cantidad { get; set; }
        public double precio_compra { get; set; }
        [ForeignKey("id_pedido")]
        public Pedido? Pedido { get; set; }
    }
}
