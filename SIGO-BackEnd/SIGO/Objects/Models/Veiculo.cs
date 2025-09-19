using SIGO.Objects.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace SIGO.Objects.Models
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string NomeVeiculo { get; set; }

        [Column("tipo")]
        public string TipoVeiculo { get; set; }

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

        [Column("Cliente")]
        public ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

        [Column("cor")]
        public ICollection<Cor> Cor { get; set; } = new List<Cor>();

        public Veiculo()
        {

        }
        public Veiculo(int id, string nomeVeiculo, string tipoVeiculo, string placaVeiculo, string chassiVeiculo, int anoFab, int quilometragem, string combustivel, string seguro, Status status)
        {
            Id = id;
            NomeVeiculo = nomeVeiculo;
            TipoVeiculo = tipoVeiculo;
            PlacaVeiculo = placaVeiculo;
            ChassiVeiculo = chassiVeiculo;
            AnoFab = anoFab;
            Quilometragem = quilometragem;
            Combustivel = combustivel;
            Seguro = seguro;
            Status = status;
        }
    }
}
