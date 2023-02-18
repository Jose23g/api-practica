using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepositorioPedido
    {
        Task<Pedido> crearPedido(List<Detalle_pedido> listaproductos);
        List<Pedido> obtenerPedidosProcesados();
        string getUserId();
    }
}
