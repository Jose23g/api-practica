using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Presentacion
    {
        [Key]
        public int id_presentacion { get; set; }
        public string Nombre { get; set; }

    }
}
