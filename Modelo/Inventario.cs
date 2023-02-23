using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Inventario
    {
        [Key]
        public int id { get; set; }
        public int id_producto { get; set; }
        public DateTime vencimiento { get; set; }
        public int total { get; set; }
    }
}
