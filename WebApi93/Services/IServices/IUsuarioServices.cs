using Domain.DTOs;
using Domain.Entities;

namespace WebApi93.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> GetAllUsers();
        public Task<Response<Usuario>> GetUserById(int userId);
        public Task<Response<Usuario>> Crear(UsuarioInDTO request);
        public Task<Response<int>> DeleteById(int userId);
        public Task<Response<Usuario>> Update(UsuarioInDTO request, int userId);


    }
}
