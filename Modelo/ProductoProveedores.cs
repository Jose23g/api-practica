using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public partial class ProductoProveedores
    {
        
        public int id_producto { get; set; }
       
        public int id_proveedores { get; set; }
        public double precio { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Proveedores Proveedores { get; set; }
    }
}
