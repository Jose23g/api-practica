using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Entrada
    {
        [Key]
        public int id_entrada { get; set; }
        public int id_pedido { get; set; }
        public string id_usuario { get; set; }
        public DateTime fecha { get; set; }
        public virtual ICollection<Detalle__entrada>? detalle_entrada { get; set; }
    }
}
