using SIGO.Objects.Models;
using SIGO.Objects.Dtos.Entities;

namespace SIGO.Services.Interfaces
{
    public interface IFuncionarioService : IGenericService<Funcionario, FuncionarioDTO>
    {
        Task<IEnumerable<FuncionarioDTO>> GetFuncionarioByNome(string nome);
    }
}
