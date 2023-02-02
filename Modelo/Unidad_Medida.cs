using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Unidad_Medida
    {
        [Key]
        public int id_unidad { get; set; }
        public string Nombre { get; set; }

    }
}
