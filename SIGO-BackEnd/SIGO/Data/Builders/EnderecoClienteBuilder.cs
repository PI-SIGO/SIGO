using Microsoft.EntityFrameworkCore;
using SIGO.Objects.Models;

namespace SIGO.Data.Builders
{
    public static class EnderecoClienteBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnderecoCliente>()
                .HasKey(ec => new { ec.ClienteId, ec.EnderecoId });
            modelBuilder.Entity<EnderecoCliente>().Property(ec => ec.Complemento).IsRequired().HasMaxLength(100);  
        }
    }
}
