using Microsoft.EntityFrameworkCore;
using SIGO.Data.Interfaces;
using SIGO.Objects.Models;

namespace SIGO.Data.Repositories
{
    public class FuncionarioRepository : GenericRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> GetFuncionarioByNome(string nome)
        {
            return await _context.Funcionarios
            .Where(c => c.Nome.Contains(nome))
            .ToListAsync();
        }
    }
}
