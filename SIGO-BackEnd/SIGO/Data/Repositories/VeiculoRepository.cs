using Microsoft.EntityFrameworkCore;
using SIGO.Data.Interfaces;
using SIGO.Objects.Models;

namespace SIGO.Data.Repositories
{
    public class VeiculoRepository : GenericRepository<Veiculo>, IVeiculoRepository
    {
        private readonly AppDbContext _context;

        public VeiculoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Veiculo?> GetByIdWithDetails(int id)
        {
            return await _context.Veiculos
                .Include(v => v.Cor) // só traz as cores
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Veiculo?> GetByPlaca(string placa)
        {
            return await _context.Veiculos
                .Include(v => v.Cor) // opcional, se quiser já trazer cores junto
                .FirstOrDefaultAsync(v => v.PlacaVeiculo == placa);
        }

        public async Task<IEnumerable<Veiculo>> GetByTipo(string tipo)
        {
            return await _context.Veiculos
                .Include(v => v.Cor) // opcional também
                .Where(v => v.TipoVeiculo == tipo)
                .ToListAsync();
        }
    }
}
