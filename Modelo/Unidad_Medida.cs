using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Unidad_Medida
    {
        [Key]
        public int id_unidad { get; set; }
        public string Nombre { get; set; }
    }
}
