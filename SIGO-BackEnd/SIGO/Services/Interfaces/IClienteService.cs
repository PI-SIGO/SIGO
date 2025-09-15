using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;

namespace SIGO.Services.Interfaces
{
    public interface IClienteService : IGenericService<Cliente, ClienteDTO>
    {
        Task<IEnumerable<ClienteDTO>> GetByNameWithDetails(string nome);
        Task<ClienteDTO?> GetByIdWithDetails(int id);
    }
}