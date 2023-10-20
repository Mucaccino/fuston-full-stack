using Microsoft.AspNetCore.Mvc;
using fuston.transacao;
using fuston.contas;
using Microsoft.EntityFrameworkCore.Storage;

namespace api.Controllers;

[ApiController]
[Route("/api/v1")]
public class TransacaoController : ControllerBase
{
    private readonly ILogger<TransacaoController> _logger;

    public TransacaoController(ILogger<TransacaoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/transacao/{transacaoId}")]
    public Transacao GetTransacaoById(int transacaoId)
    {
        using (var context = new TransacaoContext())
        {
            var transacao = context.Transacoes
                .Single(t => t.TransacaoId == transacaoId);

            return transacao;
        }
    }

    [HttpGet]
    [Route("/transacao/conta/{contaId}")]
    public IEnumerable<Transacao> GetTransacoesByConta(int contaId)
    {
        using (var context = new TransacaoContext())
        {
            var transacoes = context.Transacoes
                .Where(t => t.ContaId == contaId)
                .ToList();

            return transacoes;
        }
    }

    [HttpPost]
    [Route("/transacao/")]
    public virtual IActionResult CreateTransacao([FromBody]Transacao body) {
        try
        {
            using (var context = new TransacaoContext())
            {
                var transacao = context.Transacoes
                    .Add(body);
                
                context.SaveChanges();
                
                return new ObjectResult(transacao.Entity);
            }
        }
        catch (Exception error)
        {
            return new ObjectResult(error);
        }
    }
}
