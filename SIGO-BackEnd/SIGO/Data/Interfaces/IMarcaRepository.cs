using SIGO.Objects.Models;

namespace SIGO.Data.Interfaces
{
    public interface IMarcaRepository : IGenericRepository<Marca>
    {
        Task<IEnumerable<Marca>> GetByName(string nomeMarca);
        Task<Marca?> GetById(int idMarca);
    }
}