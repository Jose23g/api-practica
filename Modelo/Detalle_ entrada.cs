﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    public class Detalle__entrada
    {
        [Key]
        public int id_detalleE { get; set; }
        public int id_entrada { get; set; }
        public int id_producto { get; set; }
        public int id_proveedor { get; set; }
        public int id_pedido { get; set; }
        public int cantidad { get; set; }

        [ForeignKey("id_entrada")]
        public virtual Entrada? Entrada { get; set; }
    }
}
