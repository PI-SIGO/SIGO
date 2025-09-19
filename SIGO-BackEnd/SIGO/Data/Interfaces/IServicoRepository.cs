using SIGO.Objects.Models;

namespace SIGO.Data.Interfaces
{
    public interface IServicoRepository : IGenericRepository<Servico>
    {
        Task<IEnumerable<Servico>> GetByNameWithDetails(string nome);
        Task<Servico?> GetByIdWithDetails(int id);
        Task<Servico> Add(Servico servico);
    }
}
