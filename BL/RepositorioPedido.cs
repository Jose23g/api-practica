using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<user> userManager;

        public RepositorioPedido(IHttpContextAccessor httpContext , UserManager<user> userManager)
        {
            this.httpContext = httpContext;
            this.userManager = userManager;
        }

        public string getUserId()
        {
            var userId = "";

            return userId;
        }

        public Pedido crearPedido(List<Detalle_pedido> listaproductos)
        {
            try
            {

                if (listaproductos.Count == 0)
                {
                    throw new Exception("No se puede crear un pedido sin productos");
                }
                throw new Exception("No se ha implementado");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
