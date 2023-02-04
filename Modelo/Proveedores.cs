using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    public class Proveedores
    {
        [Key]
        public int id_proveedor { get; set; }
        public string Nombre { get; set; }
        public int Cedula_juridica { get; set; }
        [ForeignKey("id_producto")]
        public virtual List<Producto> Producto { get; set; }
    }
}
