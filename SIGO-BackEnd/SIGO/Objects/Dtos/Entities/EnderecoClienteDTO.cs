using SIGO.Objects.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Objects.Dtos.Entities
{
    public class EnderecoClienteDTO
    {
        public string Complemento { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
