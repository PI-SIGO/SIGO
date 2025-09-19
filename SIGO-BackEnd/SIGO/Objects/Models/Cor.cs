namespace SIGO.Objects.Models
{
    public class Cor
    {
        public int Id { get; set; }
        public string NomeCor { get; set; }
        public Cor()
        {
        }
        public Cor(int id, string nomeCor)
        {
            Id = id;
            NomeCor = nomeCor;
        }
    }
}
