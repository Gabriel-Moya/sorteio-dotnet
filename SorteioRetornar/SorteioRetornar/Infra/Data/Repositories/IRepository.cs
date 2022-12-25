using SorteioRetornar.Domain.Entities;
using SorteioRetornar.ViewModels.Numbers;

namespace SorteioRetornar.Infra.Data.Repositories
{
    public interface IRepository
    {
        Task<Client> AddClientAsync(Client client);
        Task<Client> GetByIdAsync(Guid id);
        Task<Client> GetByEmailAsync(string email);

        Task<GeneratedNumber> AddRandomNumber(GeneratedNumber generatedNumber);
        Task<ClientNumbersResponseViewModel> GetNumbersByClientId(Guid id);
    }
}
