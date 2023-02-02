using Modelo;

namespace BL
{
    public interface IRepositorioProductos
    {
        Producto nuevoProducto(Producto producto);
        Producto asociarProductoProveeddor(int id_producto, Proveedores proveedor);
        Producto buscarProducto(int id_producto);
        List<Producto> listaProductos();
        List<Presentacion> listaPresentaciones();
        List<Unidad_Medida> listaUnidades();
        Unidad_Medida existeUnidad_Medida(Unidad_Medida unidad_Medida);
        Presentacion existePresentacion(Presentacion presentacion);


    }
}
