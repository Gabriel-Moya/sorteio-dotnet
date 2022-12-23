namespace SorteioRetornar.Domain.Entities
{
    public class Client
    {
        public Client()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        
        public IList<GeneratedNumber> GeneratedNumbers { get; set; } = new List<GeneratedNumber>();
    }
}
