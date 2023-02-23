using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventarioController : ControllerBase
    {
        readonly IRepositorioInventario repositorio;

        public InventarioController(IRepositorioInventario repositorioInventario)
        {
            repositorio = repositorioInventario;

        }

        [HttpGet]
        public IEnumerable<Inventario> obtenerinventario()
        {
            return repositorio.listarInventario();
        }

        [HttpGet("{id_producto}")]
        public IActionResult buscarInventario(int id_producto)
        {
            try
            {
                return Ok(repositorio.obtenerInventario(id_producto));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
