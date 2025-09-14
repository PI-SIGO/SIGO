using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIGO.Objects.Models
{
    public class EnderecoCliente
    {
        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("clienteid")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Column("enderecoid")]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public EnderecoCliente() { }
        public EnderecoCliente (string complemento, int clienteid, int enderecoid)
        {
            Complemento = complemento;
            ClienteId = clienteid;
            EnderecoId = enderecoid;
        }
    }
}
