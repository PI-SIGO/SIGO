using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;

namespace SIGO.Services.Interfaces
{
    public interface ICorService : IGenericService<Cor, CorDTO>
    {
        Task<IEnumerable<CorDTO>> GetByName(string nome);
    }
}
