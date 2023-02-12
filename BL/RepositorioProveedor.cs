using DA;
using Modelo;


namespace BL
{
    public class RepositorioProveedor : IRepositorioProveedor
    {
        private ContextoDeBasedeDatos ElContextoBD;

        public RepositorioProveedor(ContextoDeBasedeDatos elContextoBD)
        {
            ElContextoBD = elContextoBD;
        }

        public Proveedores buscarProveedor(int id)
        {
            try
            {
                var proveedor = ElContextoBD.Proveedores.Find(id);
                if (proveedor != null)
                {
                    return proveedor;
                }
                throw new Exception("Problema al encontrar al proveedor, revisa o intentalo más tarde");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Proveedores> listaProveedor()
        {
            try
            {
                return ElContextoBD.Proveedores.ToList();
            }
            catch (Exception ex)
            {
                return new List<Proveedores>();
            }
        }

        public Proveedores modificarProveedor(Proveedores proveedor)
        {
            try
            {
                ElContextoBD.Proveedores.Update(proveedor);
                ElContextoBD.SaveChanges();
                return proveedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Proveedores nuevoProveedor(Proveedores proveedor)
        {
            ElContextoBD.Proveedores.Add(proveedor);
            ElContextoBD.SaveChanges();
            return proveedor;
        }

        Proveedores asociarProveedorProducto(int id, List<Producto> productos)
        {
            try
            {
                Proveedores nuevo = new Proveedores();
                nuevo = buscarProveedor(id);
                nuevo.Producto = new List<Producto>();

                foreach (Producto proveedores in producto)
                {
                    nuevo.Producto.Add(proveedores);
                }
                ElContextoBD.SaveChanges();
                return nuevo;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
