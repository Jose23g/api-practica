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

        
        [HttpGet("{id}")]
        public Proveedores obtenerProveedor(int id)
        {
            Proveedores nuevoproveedor = repositorio.buscarProveedor(id);
            return nuevoproveedor;
        }

        
        [HttpPut("{id}")]
        public IActionResult asociarProducto(int id, [FromBody] List<int> value)
        {
            try
            {
                return Ok(repositorio.asociarProveedorProducto(id, value));
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
    }
}
