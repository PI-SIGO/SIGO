using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;

namespace SIGO.Services.Interfaces
{
    public interface IVeiculoService : IGenericService<Veiculo, VeiculoDTO>
    {
        Task<VeiculoDTO?> GetByIdWithDetails(int id);
        Task<VeiculoDTO?> GetByPlaca(string placa);
        Task<IEnumerable<VeiculoDTO>> GetByTipo(string tipo);
    }
}
