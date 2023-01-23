using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Presentacion
    {
        [Key]
        public int id_presentacion { get; set; }
        public string Nombre { get; set; }
    }
}
 