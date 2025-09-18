using SIGO.Objects.Models;
using SIGO.Objects.Dtos.Entities;

namespace SIGO.Services.Interfaces
{
    public interface IMarcaService : IGenericService<Marca, MarcaDTO>
    {
        Task<IEnumerable<MarcaDTO>> GetByName(string nomeMarca);
        Task<MarcaDTO?> GetById(int idMarca);
    }
}