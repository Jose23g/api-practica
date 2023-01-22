using BL;
using Microsoft.AspNetCore.Mvc;
using Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class proveedorController : ControllerBase
    {
        private readonly IRepositorioProveedor repositorio;

        public proveedorController(IRepositorioProveedor repo)
        {
            repositorio= repo;
        }


        [HttpGet]
        public IEnumerable<Proveedores> Get()
        {
            List<Proveedores> lista = repositorio.listaProveedor();
            return lista;
        }

        [HttpGet("{id}")]
        public List<Proveedores> obtenerProveedor(int id)
        {
            List<Proveedores>lista = repositorio.listaProveedor();
            return lista;
        }

        // POST api/<proveedorController>
        [HttpPost]
        public IActionResult nuevoProveedor([FromBody] Proveedores proveedores)
        {
            try
            {
                repositorio.nuevoProveedor(proveedores);
                return Ok();
            }catch(Exception ex)
            {
             return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<proveedorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<proveedorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
