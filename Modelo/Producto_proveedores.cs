using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Producto_proveedores
    {
        public int id_proveedores { get; set; }
        public int id_producto { get; set; }
        
        
        [ForeignKey("id_producto")]
        public Producto Producto { get; set; }

        [ForeignKey("id_proveedores")]
        public Proveedores Proveedores {get; set;}
    }
}
