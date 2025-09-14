namespace SIGO.Objects.Dtos.Entities
{
    public class ClienteDTO
    {
        private string _email;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }
        public string senha { get; set; }
        public DateOnly Data { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Obs { get; set; }
        public string razao { get; set; }
        public DateOnly DataNasc { get; set; }

        public int Sexo { get; set; }
        public int TipoCliente { get; set; }
        public int Situacao { get; set; }

        public List<TelefoneDTO> Telefones { get; set; } = new();
        public List<EnderecoDTO> Enderecos { get; set; } = new();
    }
}
