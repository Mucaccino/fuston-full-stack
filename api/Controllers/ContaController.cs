using Microsoft.AspNetCore.Mvc;
using fuston.contas;

namespace api.Controllers;

[ApiController]
[Route("/api/v1")]
public class ContaController : ControllerBase
{
    private readonly ILogger<ContaController> _logger;

    public ContaController(ILogger<ContaController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    [Route("/conta/cliente/{clienteId}")]
    public IEnumerable<Conta> GetContas(int clienteId)
    {
        using var context = new ContaContext();
        var contas = context.Contas
            .Where(c => c.ClienteId == clienteId)
            .ToList();

        return contas;
    }

    [HttpGet]
    [Route("/conta/{contaId}")]
    public Conta GetConta(int contaId)
    {
        using var context = new ContaContext();
        var conta = context.Contas
            .Single(c => c.ContaId == contaId);

        return conta;
    }

    [HttpPost]
    [Route("/conta/")]
    public IActionResult CreateConta([FromBody]Conta body)
    {
        try
        {
            using var context = new ContaContext();
            var conta = context.Contas
                .Add(body);

            context.SaveChanges();

            return new ObjectResult(conta.Entity);
        }
        catch (Exception error)
        {
            return new ObjectResult(error);
        }
    }
}
