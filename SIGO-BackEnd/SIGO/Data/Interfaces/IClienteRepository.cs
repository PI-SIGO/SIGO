using SIGO.Objects.Models;

namespace SIGO.Data.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetByNameWithDetails(string nome);
        Task<Cliente?> GetByIdWithDetails(int id);
    }
}
