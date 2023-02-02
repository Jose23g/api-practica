using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
