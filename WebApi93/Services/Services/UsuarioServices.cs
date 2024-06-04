using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi93.Context;
using WebApi93.Services.IServices;

namespace WebApi93.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context) 
        {
            _context = context;
        }


        // Listar usuarios
        public async Task<Response<List<Usuario>>> GetAllUsers ()
        {
            try
            {
                var users = await _context.usuarios
                    .Include(x => x.Roles)
                    .ToListAsync();
                var response = new Response<List<Usuario>>(users, "Usuarios obtenidos correctamente");
                return response;
            } catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> GetUserById(int userId)
        {
            try
            {
                var users = await _context.usuarios.FirstOrDefaultAsync(x => x.PkUsuario == userId);
                if(users is null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                var response = new Response<Usuario>(users, "Usuarios obtenidos correctamente");
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        //Crear usuario
        public async Task<Response<Usuario>> Crear(UsuarioInDTO request)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                   Name = request.Name,
                   User = request.User,
                   Password = request.Password,
                   FkRol = request.FkRol
                };

                await _context.usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(usuario);

            } catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<int>> DeleteById(int userId)
        {
            try
            {
                var user = await _context.usuarios.FirstOrDefaultAsync(x => x.PkUsuario == userId);
                if(user is null)
                {
                    throw new Exception("Usuario no encontrado");
                }


                _context.usuarios.Remove(user);
                await _context.SaveChangesAsync();
                return new Response<int>(userId, "Usuario borrado correctamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }

        }

        //Crear usuario
        public async Task<Response<Usuario>> Update(UsuarioInDTO request, int userId)
        {
            try
            {
                var user = await _context.usuarios.FirstOrDefaultAsync(x => x.PkUsuario == userId);
                
                if (user is null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                user.User = request.User;
                user.Password = request.Password;
                user.Name = request.Name;
                user.FkRol = request.FkRol;

                await _context.SaveChangesAsync();
                return new Response<Usuario>(user);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

    }
}
