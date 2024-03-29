﻿using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Pedido
    {
        [Key]
        public int id_pedido { get; set; }
        public string id_usuario { get; set; }
        public int id_estado { get; set; }
        public DateTime fecha { get; set; }
        public int total { get; set; }
        public virtual ICollection<Detalle_pedido> Detalle_pedido { get; set; }

    }
}
