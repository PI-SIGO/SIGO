using Microsoft.EntityFrameworkCore;
using SIGO.Data.Interfaces;
using SIGO.Objects.Models;

namespace SIGO.Data.Repositories
{
    public class ServicoRepository : GenericRepository<Servico>, IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Servico>> Get()
        {
            return await _context.Servicos.ToListAsync();
        }


        public async Task<Servico?> GetByIdWithDetails(int id)
        {
            return await _context.Servicos
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Servico>> GetByNameWithDetails(string nome)
        {
            return await _context.Servicos
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task<Servico?> GetById(int id)
        {
            return await _context.Servicos
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Servico> Add(Servico servicos)
        {
            await _context.Servicos.AddAsync(servicos);
            await _context.SaveChangesAsync();
            return servicos;
        }
    }
}
