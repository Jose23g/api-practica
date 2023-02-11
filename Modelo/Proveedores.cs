using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    [Table("Proveedores")]
    public class Proveedores
    {
        [Key]
        public int id_proveedor { get; set; }
        public string nombre { get; set; }
        public int Cedula_juridica { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [ForeignKey("id_producto")]
        public virtual ICollection<Producto>? Producto { get; set; }
    }
}
