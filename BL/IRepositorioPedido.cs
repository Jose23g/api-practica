using Modelo;

namespace BL
{
    public interface IRepositorioPedido
    {
        Task<Pedido> crearPedido(List<Detalle_pedido> listaproductos);
        List<Pedido> obtenerPedidosProcesados();
        List<Pedido> obtenerPedidosEntregados();
        List<Detalle_pedido> recuperarDetallePedido(int id);
        Pedido buscarPedido(int id_pedido);
        string getUserId();
        Pedido cambiaraEntregado(int id);
        Entrada recibirPedido(int id, List<Detalle__entrada> detalle_entrada);
    }
}
