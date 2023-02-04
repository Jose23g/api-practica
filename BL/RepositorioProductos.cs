using DA;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace BL
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private ContextoDeBasedeDatos ElContextoBD;

        public RepositorioProductos(ContextoDeBasedeDatos _elContextoBD)
        {
            ElContextoBD = _elContextoBD;
        }

        public Producto nuevoProducto(Producto producto)
        {
            try
            {
                Producto nuevoProducto = producto;

                nuevoProducto.Presentacion = existePresentacion(producto.Presentacion);
                nuevoProducto.Unidad_Medida = existeUnidad_Medida(producto.Unidad_Medida);

                ElContextoBD.Producto.Add(nuevoProducto);
                ElContextoBD.SaveChanges();
                return producto;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Producto> listaProductos()
        {
            //Para mostrar los datos relacionados
            return ElContextoBD.Producto.Include(x => x.Proveedores).Include(x=> x.Presentacion).Include(x => x.Unidad_Medida).ToList();
        }

        public Producto buscarProducto(int id_producto)
        {
            try
            {
                Producto producto = new Producto();
                producto = ElContextoBD.Producto.Find(id_producto);
                if (producto == null)
                {
                    throw new Exception("Producto no encontrado o no exite");
                }
                return producto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Presentacion> listaPresentaciones()
        {
            return ElContextoBD.Presentacion.ToList();
        }

        public List<Unidad_Medida> listaUnidades()
        {
            return ElContextoBD.Unidad_Medida.ToList();
        }

        public Presentacion existePresentacion(Presentacion presentacion)
        {
            Presentacion resultado = ElContextoBD.Presentacion.Where(x => x.Nombre.Equals(presentacion.Nombre)).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }

            ElContextoBD.Add(presentacion);
            ElContextoBD.SaveChanges();
            return presentacion;
        }

        public Unidad_Medida existeUnidad_Medida(Unidad_Medida unidad_Medida)
        {
            Unidad_Medida resultado = ElContextoBD.Unidad_Medida.Where(x => x.Nombre.Equals(unidad_Medida.Nombre)).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }

            ElContextoBD.Add(unidad_Medida);
            ElContextoBD.SaveChanges();
            return unidad_Medida;
        }


        public Producto asociarProductoProveeddor(int id_producto, Proveedores proveedor)
        {
            try
            {
                Producto producto = buscarProducto(id_producto);
                producto.Proveedores.Add(proveedor);
                ElContextoBD.Producto.Update(producto);
                ElContextoBD.SaveChanges();
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
