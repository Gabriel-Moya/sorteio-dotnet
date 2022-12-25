using Microsoft.EntityFrameworkCore;
using SorteioRetornar.Domain.Entities;
using SorteioRetornar.ViewModels.Numbers;

namespace SorteioRetornar.Infra.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.Id == id);
            return client;
        }

        public async Task<Client> GetByEmailAsync(string email)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.Email == email);
            return client;
        }


        public async Task<GeneratedNumber> AddRandomNumber(GeneratedNumber generatedNumber)
        {
            await _context.AddAsync(generatedNumber);
            await _context.SaveChangesAsync();

            return generatedNumber;
        }

        public async Task<ClientNumbersResponseViewModel> GetNumbersByClientId(Guid id)
        {
            var numbers = await _context
                .GeneratedNumbers
                .AsNoTracking()
                .Include(x => x.Client)
                .Where(x => x.Client.Id == id)
                .Select(x => x.RandomNumber)
                .ToListAsync();

            var response = new ClientNumbersResponseViewModel
            {
                GeneratedNumbers = numbers
            };

            return response;
        }
    }
}
