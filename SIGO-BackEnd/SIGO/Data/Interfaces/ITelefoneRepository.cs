using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;

namespace SIGO.Data.Interfaces
{
    public interface ITelefoneRepository : IGenericRepository<Telefone>
    {
        Task<IEnumerable<TelefoneDTO>> GetTelefoneByNome(string nome);
    }
}
