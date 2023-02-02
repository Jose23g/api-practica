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
            repositorioProductos= _repositorioProductos;
        }

        
        [HttpGet]
        public IEnumerable<Producto> listaProductos()
        {
            return repositorioProductos.listaProductos();
        }
        
        [Route("list/presentacion")]
        [HttpGet]
        public IEnumerable<Presentacion> listaPresentacion()
        {
            return repositorioProductos.listaPresentaciones();
        }
        
        [Route("list/unidades")]
        [HttpGet]
        public IEnumerable<Unidad_Medida> listaUnidades()
        {
            return repositorioProductos.listaUnidades();
        }

        // GET api/<productoController>/5
        [HttpGet("{id}")]
        public ActionResult buscarPoducto(int id)
        {
            try
            {

                Producto producto = repositorioProductos.buscarProducto(id);
                return Ok(producto);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
        // POST api/<productoController>
        [HttpPost]
        public IActionResult Post([FromBody] Producto nuevoProducto)
        {
            try
            {
                repositorioProductos.nuevoProducto(nuevoProducto);
                return Ok(nuevoProducto);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<productoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<productoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
