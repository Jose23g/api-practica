using DA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace BL
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<user> userManager;
        private ContextoDeBasedeDatos ElContextoBD;

        public RepositorioPedido(IHttpContextAccessor httpContext, UserManager<user> userManager, ContextoDeBasedeDatos contextoDeBasedeDatos)
        {
            this.httpContext = httpContext;
            this.userManager = userManager;
            this.ElContextoBD = contextoDeBasedeDatos;
        }

        public string getUserId()
        {
            try
            {
                var userId = httpContext.HttpContext.User.Identity.Name;

                if (userId == null)
                {
                    throw new Exception("problemas de autenticacion de usario");
                }
                var id = ElContextoBD.user.Where(x => x.UserName == userId).Select(x => x.Id).FirstOrDefault();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Pedido buscarPedido(int id_pedido)
        {
            try
            {

                Pedido resultado = ElContextoBD.Pedido.Find(id_pedido);
                if (resultado == null)
                {
                    throw new Exception("No se encontró pedido");
                }

                return resultado;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public List<Detalle_pedido> recuperarDetallePedido(int id)
        {
            List<Detalle_pedido> detalle_Pedido = ElContextoBD.Detalle_pedido.Where(x => x.id_pedido == id).ToList();
            return detalle_Pedido;
        }

        public async Task<Pedido> crearPedido(List<Detalle_pedido> listaproductos)
        {
            try
            {

                if (listaproductos.Count == 0)
                {
                    throw new Exception("No se puede crear un pedido sin productos");
                }
                Pedido nuevoPedido = new Pedido();
                nuevoPedido.id_usuario = getUserId();
                nuevoPedido.id_estado = 1;
                nuevoPedido.Detalle_pedido = new List<Detalle_pedido>();
                double total = 0;

                foreach (Detalle_pedido detalle in listaproductos)
                {
                    double subtotal = 0;
                    subtotal = (detalle.cantidad * detalle.precio_compra);
                    total = subtotal + total;
                    nuevoPedido.Detalle_pedido.Add(detalle);
                }
                nuevoPedido.total = (int)total;
                await ElContextoBD.Pedido.AddAsync(nuevoPedido);
                ElContextoBD.SaveChanges();
                return nuevoPedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> obtenerPedidosProcesados()
        {
            List<Pedido> lista = ElContextoBD.Pedido.AsSingleQuery().Include("Detalle_pedido").Where(x => x.id_estado == 1).ToList();
            return lista;
        }

        public List<Pedido> obtenerPedidosEntregados()
        {
            List<Pedido> lista = ElContextoBD.Pedido.AsSingleQuery().Include("Detalle_pedido").Where(x => x.id_estado == 2).ToList();
            return lista;
        }

        public Pedido cambiaraEntregado(int id_pedido)
        {
            try
            {
                Pedido pedido = buscarPedido(id_pedido);
                pedido.id_estado = 2;
                ElContextoBD.Update(pedido);
                ElContextoBD.SaveChanges();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entrada recibirPedido(int id_pedido, List<Detalle__entrada> detalle_entrada)
        {
            try
            {

                Pedido pedido = cambiaraEntregado(id_pedido);
                pedido.Detalle_pedido = recuperarDetallePedido(id_pedido);

                Entrada nueva = new Entrada();
                nueva.id_pedido = pedido.id_pedido;
                nueva.id_usuario = getUserId();
                nueva.detalle_entrada = detalle_entrada;
                ElContextoBD.Entrada.Add(nueva);
                ElContextoBD.SaveChanges();

                foreach (Detalle__entrada detalle in detalle_entrada)
                {
                    actualizarInventario(detalle.id_producto, detalle.cantidad);
                }

                return nueva;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }

        public Inventario actualizarInventario(int id_producto, int cantidad)
        {

            Inventario inventario = ElContextoBD.Inventario.Where(x => x.id_producto == id_producto).FirstOrDefault();
            if (inventario == null)
            {
                return nuevoInventario(id_producto, cantidad);
            }
            int actual = inventario.total;
            inventario.total = cantidad + actual;
            ElContextoBD.Inventario.Update(inventario);
            ElContextoBD.SaveChanges();

            return inventario;
        }

        public Inventario nuevoInventario(int id_producto, int cantidad)

        {
            try
            {
                Inventario nuevoInventario = new Inventario();
                nuevoInventario.total = cantidad;
                nuevoInventario.id_producto = id_producto;
                ElContextoBD.Inventario.Add(nuevoInventario);
                ElContextoBD.SaveChanges();

                return nuevoInventario;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}


