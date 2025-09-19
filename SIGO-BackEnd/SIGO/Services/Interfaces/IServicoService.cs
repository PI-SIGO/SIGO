using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;

namespace SIGO.Services.Interfaces
{
    public interface IServicoService : IGenericService<Servico, ServicoDTO>
    {
        Task<IEnumerable<ServicoDTO>> GetByNameWithDetails(string nome);
        Task<ServicoDTO?> GetByIdWithDetails(int id);
    }
}