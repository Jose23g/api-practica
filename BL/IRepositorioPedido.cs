using Modelo;

namespace BL
{
    public interface IRepositorioPedido
    {
        Task<Pedido> crearPedido(List<Detalle_pedido> listaproductos);
        List<Pedido> obtenerPedidosProcesados();
        List<Pedido> obtenerPedidosEntregados();
        List<Detalle_pedido> recuperarDetallePedido(int id_pedido);
        Pedido buscarPedido(int id_pedido);
        string getUserId();
        Pedido cambiaraEntregado(int id_pedido);
        Entrada recibirPedido(int id_pedido, List<Detalle__entrada> detalle_entrada);
        Inventario actualizarInventario(int id_producto, int cantidad);
        Inventario nuevoInventario(int id_producto, int cantidad);
    }
}
