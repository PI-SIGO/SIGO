using Microsoft.EntityFrameworkCore;
using SIGO.Data.Builders;
using SIGO.Objects.Models;

namespace SIGO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cor> Cores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ClienteBuilder.Build(modelBuilder);
            TelefoneBuilder.Build(modelBuilder);
            ServicoBuilder.Build(modelBuilder);
            MarcaBuilder.Build(modelBuilder);

            VeiculoBuilder.Build(modelBuilder);
            CorBuilder.Build(modelBuilder);
        }
    }
}
