using Microsoft.EntityFrameworkCore;
using SIGO.Data.Interfaces;
using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;

namespace SIGO.Data.Repositories
{
    public class TelefoneRepository : GenericRepository<Telefone>, ITelefoneRepository
    {
        private readonly AppDbContext _context;

        public TelefoneRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TelefoneDTO>> GetTelefoneByNome(string nome)
        {
            return await _context.Telefones
                .Where(t => t.Clientes.Nome.Contains(nome))
                .Select(t => new TelefoneDTO
                {
                    Id = t.Id,
                    Numero = t.Numero,
                    DDD = t.DDD,
                    ClienteId = t.ClienteId
                })
                .ToListAsync();
        }
    }
}
