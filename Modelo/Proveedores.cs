using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

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
