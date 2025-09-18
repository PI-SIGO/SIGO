using Microsoft.EntityFrameworkCore;
using SIGO.Data.Interfaces;
using SIGO.Objects.Models;

namespace SIGO.Data.Repositories
{
    public class CorRepository : GenericRepository<Cor>, ICorRepository
    {
        private readonly AppDbContext _context;

        public CorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Cor>> Get()
        {
            return await _context.Cores.ToListAsync();
        }

        public async Task<IEnumerable<Cor>> GetByNome(string nome)
        {
            return await _context.Cores
                .Where(c => c.NomeCor.Contains(nome))
                .ToListAsync();
        }

        public async Task<Cor?> GetById(int id)
        {
            return await _context.Cores
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
