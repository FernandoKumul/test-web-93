using Domain.DTOs;
using Domain.Entities;

namespace WebApi93.Services.IServices
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> Crear(AutorInDTO i);


    }
}
