using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int id_producto { get; set; }
        public int codigo_producto { get; set; }
        public string nombre { get; set; }
        public float precio_venta { get; set; }
        public int id_presentacion { get; set; }

        [ForeignKey("id_presentacion")]
        public virtual Presentacion Presentacion { get; set; }
        public int id_unidad { get; set; }

        [ForeignKey("id_unidad")]
        public virtual Unidad_Medida Unidad_Medida { get; set; }

        public virtual ICollection<Proveedores>? Proveedores { get; set;}
    }
}
