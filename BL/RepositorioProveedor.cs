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

        public List<Proveedores> listaProveedor()
        {
            try
            {
                return ElContextoBD.Proveedores.ToList();
            }catch (Exception ex)
            {
             return new List<Proveedores>();
            }
        }

        public Proveedores nuevoProveedor(Proveedores proveedor)
        {
            ElContextoBD.Proveedores.Add(proveedor);
            ElContextoBD.SaveChanges();
            return proveedor;
        }
    }
}
