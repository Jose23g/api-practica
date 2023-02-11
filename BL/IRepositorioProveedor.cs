using Modelo;

namespace BL
{
    public interface IRepositorioProveedor
    {
        Proveedores nuevoProveedor(Proveedores proveedor);
        Proveedores buscarProveedor(int id);
        Proveedores modificarProveedor(Proveedores proveedor);
        List<Proveedores> listaProveedor();
    }
}
