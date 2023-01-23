using DA;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private ContextoDeBasedeDatos ElContextoBD;

        public RepositorioProductos(ContextoDeBasedeDatos _elContextoBD)
        {
            ElContextoBD= _elContextoBD;
        }

        public List<Producto> listaProductos()
        {
           return ElContextoBD.Producto.ToList();
        }

        public Producto nuevoProducto(Producto producto)
        {
            try
            {
                ElContextoBD.Producto.Add(producto);
                ElContextoBD.SaveChanges();
                return producto;
            }catch(Exception ex)
            {
                return producto;
            }
        }
    }
}
