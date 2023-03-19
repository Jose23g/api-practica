using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Proveedores
    {
        [Key]
        public int id_proveedor { get; set; }
        public string Nombre { get; set; }
        public int Cedula_juridica { get; set; }
        
        public ICollection<ProductoProveedores> ProductoProveedores { get; set; }
    }
}
