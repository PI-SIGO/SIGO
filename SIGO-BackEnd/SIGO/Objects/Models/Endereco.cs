using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Objects.Models
{
    [Table("endereco")]
    public class Endereco
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("numero")]
        public int Numero { get; set; }

        [Column("rua")]
        public string Rua { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("cep")]
        public int Cep { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("pais")]
        public string Pais { get; set; }

        public ICollection<EnderecoCliente> EnderecoClientes { get; set; } = new List<EnderecoCliente>();

        public Endereco() { }
        public Endereco(int id, int numero, string rua, string cidade, int cep, string bairro, string estado, string pais)
        {
            Id = id;
            Numero = numero;
            Rua = rua;
            Cidade = cidade;
            Cep = cep;
            Bairro = bairro;
            Estado = estado;
            Pais = pais;
        }
    }
}
