using BL;
using Microsoft.AspNetCore.Mvc;
using Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productoController : ControllerBase
    {
        private readonly IRepositorioProductos repositorioProductos;

        public productoController(IRepositorioProductos _repositorioProductos)
        {
            repositorioProductos = _repositorioProductos;
        }


        [HttpGet]
        public IEnumerable<Producto> listaProductos()
        {
            return repositorioProductos.listaProductos();
        }


        [HttpPost]
        public IActionResult agregarProducto([FromBody] Producto nuevoProducto)
        {
            try
            {
                repositorioProductos.nuevoProducto(nuevoProducto);
                return Ok(nuevoProducto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult asociarProveedor(int id, List<int> proveedores)
        {

            try
            {
               return Ok(repositorioProductos.asociarProductoProveeddor(id, proveedores));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
