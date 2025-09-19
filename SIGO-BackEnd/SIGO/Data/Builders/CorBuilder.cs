using Microsoft.EntityFrameworkCore;
using SIGO.Objects.Models;

namespace SIGO.Data.Builders
{
    public class CorBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cor>().Property(c => c.Id).IsRequired();
            modelBuilder.Entity<Cor>().Property(c => c.NomeCor).IsRequired().HasMaxLength(50);
        }
    }
}
