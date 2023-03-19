using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProductoProveedores
    {
        [Key]
        public int id_producto { get; set; }
        [Key]
        public int id_proveedor { get; set; }
        public float Precio { get; set; }

        /*[ForeignKey("id_producto")]
        public Producto Producto { get; set; }

        [ForeignKey("id_proveedor")]
        public Proveedores Proveedor { get; set; }*/

    }
}
