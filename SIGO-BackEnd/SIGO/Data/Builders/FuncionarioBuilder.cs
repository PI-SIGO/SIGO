using Microsoft.EntityFrameworkCore;
using SIGO.Objects.Models;

namespace SIGO.Data.Builders
{
    public class FuncionarioBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasKey(c => c.Id);
            modelBuilder.Entity<Funcionario>().Property(c => c.Nome).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Funcionario>().Property(c => c.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Funcionario>().Property(c => c.Cpf).IsRequired().HasMaxLength(12);
            modelBuilder.Entity<Funcionario>().Property(c => c.Cargo).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Funcionario>().Property(c => c.Situacao).IsRequired();

        }
    }
}
