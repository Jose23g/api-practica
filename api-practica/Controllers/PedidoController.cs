﻿using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        readonly IRepositorioPedido repositorioPedido;

        public PedidoController(IRepositorioPedido repositorio)
        {
            repositorioPedido = repositorio;
        }

        [HttpGet]
        [Route("procedados")]
        public IEnumerable<Pedido> obtenerProcesados()
        {
            List<Pedido> lista = repositorioPedido.obtenerPedidosProcesados();
            return lista;
        }

        [HttpGet]
        [Route("entregados")]
        public IEnumerable<Pedido> obtenerEntregados()
        {
            return repositorioPedido.obtenerPedidosEntregados();
        }

        [HttpPost]
        public async Task<IActionResult> nuevoPedido([FromBody] List<Detalle_pedido> value)
        {
            try
            {
                Pedido nuevo = await repositorioPedido.crearPedido(value);
                return Ok(nuevo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult buscarPedido(int id)
        {
            try
            {
                return Ok(repositorioPedido.buscarPedido(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id_pedido}")]
        public IActionResult recibirPedido(int id_pedido, [FromBody] List<Detalle__entrada> value)
        {
            try
            {
                return Ok(repositorioPedido.recibirPedido(id_pedido, value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
