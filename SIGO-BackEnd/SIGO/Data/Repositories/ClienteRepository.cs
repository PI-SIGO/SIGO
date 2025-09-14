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
                .Include(c => c.EnderecoClientes)
                    .ThenInclude(ec => ec.Endereco)
                .Include(c => c.Telefones)
                .ToListAsync();
        }


    }
}
