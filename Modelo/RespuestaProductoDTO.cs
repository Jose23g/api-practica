using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RespuestaProductoDTO
    {
        public int id_producto { get; set; }
        public String Nombre { get; set; }
        public int id_unidad { get; set; }
        public int id_presentacion { get; set; }
        public ICollection<Proveedores>? Proveedores { get; set; }
    }
}
