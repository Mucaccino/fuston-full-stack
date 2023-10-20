using Microsoft.AspNetCore.Mvc;
using fuston.cliente;

namespace api.Controllers;

[ApiController]
[Route("/api/v1")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/cliente")]
    public IEnumerable<Cliente> GetClientes()
    {
        using (var context = new ClienteContext())
        {
            var clientes = context.Clientes
                .OrderBy(c => c.Nome)
                .ToList();

            return clientes;
        }
    }

    [HttpGet]
    [Route("/cliente/documento/{documento}")]
    public Cliente GetClienteByDocumento(float documento)
    {
        using (var context = new ClienteContext())
        {
            var cliente = context.Clientes
                .Single(c => c.Documento == documento);

            return cliente;
        }
    }

    [HttpGet]
    [Route("/cliente/{id}")]
    public Cliente GetCliente(int id)
    {
        using (var context = new ClienteContext())
        {
            var cliente = context.Clientes
                .Single(c => c.ClienteId == id);

            return cliente;
        }
    }
}
