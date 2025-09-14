using SIGO.Objects.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Objects.Dtos.Entities
{
    public class EnderecoClienteDTO
    {
        public string Complemento { get; set; }
        public int ClienteId { get; set; }
        public ClienteDTO Cliente { get; set; } // <- usar DTO, pq tava dando erro pois não tava enviando de la
        public int EnderecoId { get; set; }
        public EnderecoDTO Endereco { get; set; } // <- usar DTO
    }

}
