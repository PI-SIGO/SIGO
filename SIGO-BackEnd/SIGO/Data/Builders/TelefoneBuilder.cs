using Microsoft.EntityFrameworkCore;
using SIGO.Objects.Models;

namespace SIGO.Data.Builders
{
    public class TelefoneBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<Telefone>().Property(t => t.Numero).IsRequired().HasMaxLength(9);
            modelBuilder.Entity<Telefone>().Property(t => t.DDD).IsRequired().HasMaxLength(3);
            modelBuilder.Entity<Telefone>().Property(t => t.ClienteId).IsRequired();
        }
    }
}
