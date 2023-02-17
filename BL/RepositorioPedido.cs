using DA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            var userId = httpContext.HttpContext.User.Identity.Name;
            var id = ElContextoBD.user.Where(x => x.UserName == userId).Select(x => x.Id).FirstOrDefault();

            return id;
        }

        public Pedido crearPedido(List<Detalle_pedido> listaproductos)
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
                double total = 0;
                
                foreach (Detalle_pedido detalle in listaproductos)
                {
                    double subtotal = 0;
                    subtotal = (detalle.cantidad * detalle.precio_compra);
                    total = subtotal + total;
                    nuevoPedido.Detalle_Pedidos.Add(detalle);
                }
                nuevoPedido.total = total;

                return nuevoPedido;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
