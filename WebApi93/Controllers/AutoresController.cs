using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi93.Services.IServices;

namespace WebApi93.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _services;
        public AutoresController(IAutorServices autorServices)
        {
            _services = autorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok(await _services.GetAutores());
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] AutorInDTO autor)
        {
            try
            {
                return Ok(await _services.Crear(autor));
            } catch (Exception ex) 
            { 
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }

    }
}
