using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public partial class Detalle_pedido
    {
        int id_detalle { get; set; }
        int id_pedido { get; set; }
        int id_producto { get; set; }
        int id_proveedor { get; set; }
        int cantidad { get; set; }
        double precio_compra { get; set;  }
    }
}
