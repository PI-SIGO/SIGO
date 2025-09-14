using Microsoft.EntityFrameworkCore;
using SIGO.Objects.Models;

namespace SIGO.Data.Builders
{
    public class EnderecoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>().Property(e => e.Id).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Numero).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Rua).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Endereco>().Property(e => e.Cidade).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Endereco>().Property(e => e.Cep).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Endereco>().Property(e => e.Bairro).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Endereco>().Property(e => e.Estado).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Endereco>().Property(e => e.Pais).IsRequired().HasMaxLength(100);






        }
    }
}
