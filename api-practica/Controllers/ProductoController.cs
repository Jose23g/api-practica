using BL;
using Microsoft.AspNetCore.Mvc;
using Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        readonly IRepositorioProductos repositorio;

        public ProductoController(IRepositorioProductos repositorioproductos)
        {
            repositorio = repositorioproductos;

        }


        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        { 
            List<Producto> Productos= new List<Producto>();

            Productos = repositorio.ListarProductos();

            return (Productos);
        }



        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] Producto producto)
        {
            repositorio.IngresarProducto(producto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{codigo_producto}")]
        public IActionResult registrarproovedor(int codigo_producto, int cedulajuridica, float precio)
        {
            try
            {
                return Ok(repositorio.registrarproveedor(codigo_producto, cedulajuridica, precio)); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
