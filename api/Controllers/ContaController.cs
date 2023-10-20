using Microsoft.AspNetCore.Mvc;
using fuston.contas;

namespace api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ContaController : ControllerBase
{
    private readonly ILogger<ContaController> _logger;

    public ContaController(ILogger<ContaController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetContas")]
    public IEnumerable<Conta> GetContas(int clienteId)
    {
        using (var context = new ContaContext())
        {
            var contas = context.Conta
                .Where(c => c.ClienteId == clienteId);

            return contas;
        }
    }

    [HttpGet(Name = "GetConta")]
    public Conta GetConta(int contaId)
    {
        using (var context = new ContaContext())
        {
            var conta = context.Conta
                .Single(c => c.ContaId == contaId);

            return conta;
        }
    }
}
