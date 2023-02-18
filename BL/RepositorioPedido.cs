using DA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> obtenerPedidosProcesados()
        {
            List<Pedido> lista = ElContextoBD.Pedido.Include("Detalle_pedido").Where(x => x.id_estado == 1).ToList();
            return lista;
        }
    }
}
