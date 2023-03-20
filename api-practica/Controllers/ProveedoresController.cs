using BL;
using Microsoft.AspNetCore.Mvc;
using Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        readonly IRepositorioProveedores RepositorioProveedores;

        public ProveedoresController(IRepositorioProveedores repositorioproveedores)
        {
            RepositorioProveedores = repositorioproveedores;

        }

        [HttpGet]
        public IEnumerable<Proveedores> ObtenerProveedores()
        {
            List<Proveedores> proveedores = RepositorioProveedores.listarconproductos();
            return (proveedores);
        }

        [HttpGet]
        [Route("conproductos")]
        public IEnumerable<Proveedores> ObtenerProveedoresconproductos()
        {
            List<Proveedores> proveedores = RepositorioProveedores.listarconproductos();
            return (proveedores);
        }

        // GET api/<ProveedoresController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProveedoresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProveedoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProveedoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
