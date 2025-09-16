using Microsoft.EntityFrameworkCore;
using SIGO.Data.Interfaces;
using SIGO.Objects.Models;

namespace SIGO.Data.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Cliente>> Get()
        {
            return await _context.Clientes
                .Include(c => c.Telefones)
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdWithDetails(int id)
        {
            return await _context.Clientes
                .Include(c => c.Telefones)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cliente>> GetByNameWithDetails(string nome)
        {
            return await _context.Clientes
                .Include(c => c.Telefones)
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task<Cliente?> GetById(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
