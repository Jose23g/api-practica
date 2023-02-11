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
            repositorio = repo;
        }


        [HttpGet]
        public IEnumerable<Proveedores> Get()
        {
            List<Proveedores> lista = repositorio.listaProveedor();
            return lista;
        }

        [HttpGet("{id}")]
        public Proveedores obtenerProveedor(int id)
        {
            Proveedores nuevoproveedor = new Proveedores();
            return nuevoproveedor;
        }


        [HttpPost]
        public IActionResult nuevoProveedor([FromBody] Proveedores proveedores)
        {
            try
            {
                repositorio.nuevoProveedor(proveedores);
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
