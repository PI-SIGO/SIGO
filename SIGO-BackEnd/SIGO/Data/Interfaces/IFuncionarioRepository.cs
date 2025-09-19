using SIGO.Objects.Models;

namespace SIGO.Data.Interfaces
{
    public interface IFuncionarioRepository : IGenericRepository<Funcionario>
    {
        Task<List<Funcionario>> GetFuncionarioByNome(string nome);
    }
}
