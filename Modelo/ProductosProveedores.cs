using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProductosProveedores
    {
        [ForeignKey("id_producto")]
        public Producto Producto { get; set; }

        [ForeignKey("id_proveedor")]
        public Proveedores Proveedor { get; set; }

        public float Precio { get; set; }

    }
}
