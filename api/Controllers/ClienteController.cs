using Microsoft.AspNetCore.Mvc;
using fuston.cliente;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetClient")]
    public Cliente Get(float documento)
    {
        using (var context = new ClienteContext())
        {
            var cliente = context.Cliente
                .Single(c => c.Documento == documento);

            return cliente;
        }
    }
}
