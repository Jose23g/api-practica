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
        public float precio_venta { get; set; }
        /*public int id_presentacion { get; set; }*/
        [ForeignKey("id_presentacion")]
        public Presentacion presentacion { get; set; }
       /* public int id_unidad { get; set; }*/
        [ForeignKey("id_unidad")]
        public Unidad_Medida Unidad_Medida { get; set; }
       
    }
}
