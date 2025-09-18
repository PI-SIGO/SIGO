using SIGO.Objects.Models;

namespace SIGO.Data.Interfaces
{
    public interface IVeiculoRepository : IGenericRepository<Veiculo>
    {
        Task<Veiculo?> GetByIdWithDetails(int id);
        Task<Veiculo?> GetByPlaca(string placa);
        Task<IEnumerable<Veiculo>> GetByTipo(string tipo);
    }
}
