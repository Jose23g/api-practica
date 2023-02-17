using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Detalle_pedido
    {
       public int id_detalle { get; set; }
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public int id_proveedor { get; set; }
        public int cantidad { get; set; }
        public double precio_compra { get; set;  }
    }
}
