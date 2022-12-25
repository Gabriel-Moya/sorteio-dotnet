using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SorteioRetornar.Domain.Entities;
using SorteioRetornar.Interfaces.Services;
using SorteioRetornar.ViewModels;
using SorteioRetornar.ViewModels.Clients;
using SorteioRetornar.ViewModels.Numbers;

namespace SorteioRetornar.Controllers
{
    [ApiController, Route("v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientesController([FromServices] IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient([FromBody] ClientRequestViewModel client)
        {
            var clientResponse = await _clientService.RegisterClient(client);

            if (clientResponse is null)
            {
                return StatusCode(500, new ResultViewModel<Client>("05XE1 - Falha interna no servidor"));
            }

            return Created($"v1/cliente/{clientResponse.Id}", new ResultViewModel<ClientResponseViewModel>(clientResponse));
        }

        [HttpPost("gerar-numero/{id:guid}")]
        public async Task<IActionResult> GenerateRandomNumber([FromRoute] Guid id)
        {
            var numberResponse = await _clientService.GenerateRandomNumber(id);

            if (numberResponse is null)
            {
                return StatusCode(500, new ResultViewModel<GeneratedNumberResponseViewModel>("05XE2 - Falha interna no servidor"));
            }

            return Created($"v1/cliente/gerar-numero", new ResultViewModel<GeneratedNumberResponseViewModel>(numberResponse));
        }

        [HttpGet("obter-numeros/{id:guid}")]
        public async Task<IActionResult> GetNumbersByClientId([FromRoute] Guid id)
        {
            var allNumbers = await _clientService.GetNumbersByClientId(id);

            if (allNumbers is null)
            {
                return StatusCode(500, new ResultViewModel<ClientNumbersResponseViewModel>("05XE3 - Falha interna no servidor"));
            }

            return Ok(new ResultViewModel<ClientNumbersResponseViewModel>(allNumbers));
        }
    }
}
