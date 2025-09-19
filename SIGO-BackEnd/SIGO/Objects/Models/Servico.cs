using SIGO.Objects.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Objects.Models
{
    [Table("servico")]
    public class Servico
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("valor")]
        public double Valor { get; set; }

        [Column("garantia")]
        public DateOnly Garantia { get; set; }
        public Servico(int id, string nome, string descricao, double valor, DateOnly garantia)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Garantia = garantia;
        }
    }
}
