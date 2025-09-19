using SIGO.Objects.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Objects.Models
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("cpf")]
        public string Cpf { get; set; }
        [Column("cargo")]
        public string Cargo { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("situacao")]
        public Situacao Situacao { get; set; }

        public Funcionario(int id, string nome, string cpf, string cargo, string email, Situacao situacao)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Cargo = cargo;
            Email = email;
            Situacao = situacao;
        }
    }
}
