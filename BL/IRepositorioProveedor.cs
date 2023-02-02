using Modelo;

namespace BL
{
    public interface IRepositorioProveedor
    {
        Proveedores nuevoProveedor(Proveedores proveedor);
        List<Proveedores> listaProveedor();
    }
}
