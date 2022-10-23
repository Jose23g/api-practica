﻿using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_practica.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {

        private readonly IRepositorio Repositorio;

        public PruebaController(IRepositorio repositorio)
        {
            Repositorio = repositorio;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            List<Album> losAlbums;
            losAlbums = Repositorio.Obtenertodo();
            return losAlbums;
        }

        [HttpPost("ingresar")]
        public IActionResult Post([FromBody] Album album)
        {
            try
            {
                Repositorio.ingresar(album);
                return Ok(album);
            }
            catch (Exception e)
            {
                return Ok(e);
            }


        }

    }
}
