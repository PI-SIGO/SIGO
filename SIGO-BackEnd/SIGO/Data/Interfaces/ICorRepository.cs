using SIGO.Objects.Models;

namespace SIGO.Data.Interfaces
{
    public interface ICorRepository : IGenericRepository<Cor>
    {
        Task<IEnumerable<Cor>> GetByNome(string nome);
    }
}
