using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi93.Services.IServices;

namespace WebApi93.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController: ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _usuarioServices.GetAllUsers();
                return Ok(users);
            } catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var users = await _usuarioServices.GetUserById(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsuarioInDTO usuario)
        {
            try
            {
                var users = await _usuarioServices.Crear(usuario);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpPut("{userId:int}")]
        public async Task<IActionResult> UpdateUser([FromBody] UsuarioInDTO usuario, int userId)
        {
            try
            {
                var users = await _usuarioServices.Update(usuario, userId);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> DeleteUser( int userId)
        {
            try
            {
                var users = await _usuarioServices.DeleteById(userId);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }
    }
}
