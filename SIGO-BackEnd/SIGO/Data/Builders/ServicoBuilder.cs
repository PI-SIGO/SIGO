using Microsoft.EntityFrameworkCore;
using SIGO.Objects.Models;

namespace SIGO.Data.Builders
{
    public class ServicoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servico>().HasKey(c => c.Id);
            modelBuilder.Entity<Servico>().Property(c => c.Nome).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Servico>().Property(c => c.Garantia);
            modelBuilder.Entity<Servico>().Property(c => c.Valor).IsRequired();
            modelBuilder.Entity<Servico>().Property(c => c.Descricao).IsRequired();
        }
    }
}
