using SIGO.Objects.Models;

namespace SIGO.Data.Interfaces
{
    public interface IVeiculoRepository : IGenericRepository<Veiculo>
    {
        Task<Veiculo?> GetByPlaca(string placa);
        Task<IEnumerable<Veiculo>> GetByTipo(string tipo);
        Task UpdateVeiculo(Veiculo veiculo);
    }
}
