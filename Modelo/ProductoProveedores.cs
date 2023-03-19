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
        public int id { get; set; }

        public int id_producto { get; set; }

        public int id_proveedor { get; set; }
        public float Precio { get; set; }

        public Producto Producto { get; set; }
        public Proveedores Proveedores { set; get; }


    }
}
