using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Inventario
    {
        public int id { get; set; }
        public int id_producto { get; set; }
        public DateTime vencimiento { get; set; }
        public int cantidad { get; set; }
    }
}
