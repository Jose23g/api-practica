using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Producto
    {  
        [Key]
        public int id_producto { get; set; } 
        public int codigo_producto { get; set; }
        public string nombre { get; set; }
        public double precio_venta { get; set; }

        [ForeignKey("id_unidad")]
        public Unidad_Medida Unidad_Medida  { get; set; }
       
        [ForeignKey("id_presentacion")]
        public Presentacion Presentacion { get; set; }

        [ForeignKey("id_proveedor")]
        public ICollection<Proveedores>? Proveedores  { get; set; }
    }
}
