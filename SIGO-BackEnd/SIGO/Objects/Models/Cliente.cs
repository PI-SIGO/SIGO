using SIGO.Objects.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Objects.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("data")]
        public DateOnly Data { get; set; }

        [Column("cpf_cnpj")]
        public string Cpf_Cnpj { get; set; }

        [Column("obs")]
        public string Obs { get; set; }

        [Column("razao")]
        public string Razao { get; set; }

        [Column("situacao")]
        public Situacao Situacao { get; set; }

        [Column("sexo")]
        public Sexo Sexo { get; set; }

        [Column("datanasc")]
        public DateOnly DataNasc { get; set; }

        [Column("TipoCliente")]
        public TipoCliente TipoCliente { get; set; }

        public ICollection<EnderecoCliente> EnderecoClientes { get; set; } = new List<EnderecoCliente>();

        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();


        public Cliente()
        {

        }
        public Cliente(int id, string nome, string email, string senha, DateOnly data, Situacao situacao, string razao, Sexo sexo, TipoCliente tipoCliente)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Data = data;
            Situacao = situacao;
            Razao = razao;
            Sexo = sexo;
            TipoCliente = tipoCliente;
        }
    }
}
