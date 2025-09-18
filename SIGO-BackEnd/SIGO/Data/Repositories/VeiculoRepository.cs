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

        public override async Task<IEnumerable<Veiculo>> Get()
        {
            return await _context.Veiculos
                .Include(v => v.Cor) // inclui cores relacionadas
                .ToListAsync();
        }

        public async Task<Veiculo?> GetByPlaca(string placa)
        {
            return await _context.Veiculos
                .Include(v => v.Cor)
                .FirstOrDefaultAsync(v => v.PlacaVeiculo == placa);
        }

        public async Task<IEnumerable<Veiculo>> GetByTipo(string tipo)
        {
            return await _context.Veiculos
                .Include(v => v.Cor)
                .Where(v => v.TipoVeiculo == tipo)
                .ToListAsync();
        }

        public async Task<Veiculo?> GetById(int id)
        {
            return await _context.Veiculos
                .Include(v => v.Cor)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
