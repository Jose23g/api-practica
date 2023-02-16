using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        readonly IRepositorioPedido repositorioPedido;
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<IdentityUser> userManager;

        public PedidoController(IRepositorioPedido repositorio, IHttpContextAccessor httpContext)
        {
            repositorioPedido = repositorio;
            this.httpContext = httpContext;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PedidoController>/5
        [HttpGet("Users/current")]
        public async Task<IActionResult> getloggedinUser()
        {
            try
            {
                string hola = HttpContext.User.FindFirstValue("userID");
                return Ok(new {userID = hola});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

       
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
