using Microsoft.EntityFrameworkCore;
using SorteioRetornar.Domain.Entities;
using SorteioRetornar.Infra.Data.Repositories;
using SorteioRetornar.Interfaces.Services;
using SorteioRetornar.Utils;
using SorteioRetornar.ViewModels.Clients;
using SorteioRetornar.ViewModels.Numbers;

namespace SorteioRetornar.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository _repository;

        public ClientService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClientResponseViewModel> RegisterClient(ClientRequestViewModel clientViewModel)
        {
            try
            {
                var client = new Client
                {
                    Name = clientViewModel.Name,
                    PhoneNumber = clientViewModel.PhoneNumber,
                    Cpf = clientViewModel.Cpf,
                    Email = clientViewModel.Email,
                };

                var insertedClient = await _repository.AddClientAsync(client);
                var insertedClientResponse = new ClientResponseViewModel
                {
                    Id = insertedClient.Id,
                    Name = insertedClient.Name,
                    PhoneNumber = insertedClient.PhoneNumber,
                    Cpf = insertedClient.Cpf,
                    Email = insertedClient.Email,
                };

                return insertedClientResponse;
            }
            catch
            {
                return null;
            }
        }

        public async Task<GeneratedNumberResponseViewModel> GenerateRandomNumber(Guid id)
        {
            try
            {
                var client = await _repository.GetByIdAsync(id);
                int randomNumber = GenerateRandomNumber();

                var generatedNumber = new GeneratedNumber
                {
                    RandomNumber = randomNumber,
                    Client = client
                };

                var numberRepository = await _repository.AddRandomNumber(generatedNumber);

                var numberResponse = new GeneratedNumberResponseViewModel
                {
                    Name = numberRepository.Client.Name,
                    PhoneNumber = numberRepository.Client.PhoneNumber,
                    Cpf = numberRepository.Client.Cpf,
                    Email = numberRepository.Client.Email,
                    GeneratedNumber = numberRepository.RandomNumber
                };
                FileUtils.AddNumberToFile(numberResponse.GeneratedNumber);

                return numberResponse;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ClientNumbersResponseViewModel> GetNumbersByClientId(Guid id)
        {
            try
            {
                var allNumbers = await _repository.GetNumbersByClientId(id);

                return allNumbers;
            }
            catch
            {
                return null;
            }
        }


        private static int GenerateRandomNumber()
        {
            bool generatedNumberExists;
            int randomNumber;
            do
            {
                randomNumber = new Random().Next(0, 99999);
                generatedNumberExists = FileUtils.NumberExists(randomNumber);
            } while (generatedNumberExists);

            return randomNumber;
        }
    }
}
