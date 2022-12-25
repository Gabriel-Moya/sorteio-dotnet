using SorteioRetornar.ViewModels.Clients;
using SorteioRetornar.ViewModels.Numbers;

namespace SorteioRetornar.Interfaces.Services
{
    public interface IClientService
    {
        Task<ClientResponseViewModel> RegisterClient(ClientRequestViewModel clientViewModel);
        Task<GeneratedNumberResponseViewModel> GenerateRandomNumber(Guid id);
        Task<ClientNumbersResponseViewModel> GetNumbersByClientId(Guid id);
    }
}
