using SIGO.Objects.Models;

namespace SIGO.Objects.Dtos.Entities
{
    public class EnderecoDTO
    {

        public int Id { get; set; }
        public int Numero { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public ICollection<EnderecoCliente> enderecoclientes { get; set; } = new List<EnderecoCliente>();
    }
}
