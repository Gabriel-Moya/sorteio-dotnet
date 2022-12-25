namespace SorteioRetornar.Domain.Entities
{
    public class GeneratedNumber
    {
        public GeneratedNumber()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int RandomNumber { get; set; }
        public Client Client { get; set; }
    }
}
