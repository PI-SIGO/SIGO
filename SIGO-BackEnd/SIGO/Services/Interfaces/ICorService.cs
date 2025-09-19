using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;
using System.Runtime.ConstrainedExecution;

namespace SIGO.Services.Interfaces
{
    public interface ICorService : IGenericService<Cor, CorDTO>
    {
        Task<IEnumerable<CorDTO>> GetByName(string nome);
        Task UpdateCor(CorDTO corDto, int id);

    }
}
