using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Objects.Models
{
    public enum Status
    {
        Pendente = 0,
        AguardandoPecas = 1,
        EmAndamento = 2,
        Concluido = 3
    }

    [Table("veiculo")]
    public class Veiculo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string NomeVeiculo { get; set; }

        [Column("tipo")]
        public string TipoVeiculo { get; set; }

        [Column("cor")]
        public string CorVeiculo { get; set; }

        [Column("placa")]
        public string PlacaVeiculo { get; set; }

        [Column("chassi")]
        public string ChassiVeiculo { get; set; }

        [Column("ano")]
        public int AnoFab { get; set; }

        [Column("quilometragem")]
        public int Quilometragem { get; set; }

        [Column("combustivel")]
        public string Combustivel { get; set; }

        [Column("seguro")]
        public string Seguro { get; set; }

        [Column("status")]
        public Status Status { get; set; }
    }
}
