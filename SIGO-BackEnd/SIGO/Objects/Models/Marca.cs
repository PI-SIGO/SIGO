using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Objects.Models
{
    [Table("marca")]
    public class Marca
    {
        [Column("idMarca")]
        public int IdMarca { get; set; }

        [Column("nomeMarca")]
        public string NomeMarca { get; set; }

        [Column("descMarca")]
        public string DescMarca { get; set; }

        [Column("tipoMarca")]
        public string TipoMarca { get; set; }

        public Marca() { }

        public Marca(int idMarca, string nomeMarca, string descMarca, string tipoMarca)
        {
            IdMarca = idMarca;
            NomeMarca = nomeMarca;
            DescMarca = descMarca;
            TipoMarca = tipoMarca;
        }
    }
}