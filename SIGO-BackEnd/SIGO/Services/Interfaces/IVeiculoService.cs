using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;

namespace SIGO.Services.Interfaces
{
    public interface IVeiculoService : IGenericService<Veiculo, VeiculoDTO>
    {
        Task<IEnumerable<VeiculoDTO>> GetByPlaca(string placa);
        Task<IEnumerable<VeiculoDTO>> GetByTipo(string tipo);
        Task UpdateVeiculo(VeiculoDTO veiculoDto, int id);
    }
}
