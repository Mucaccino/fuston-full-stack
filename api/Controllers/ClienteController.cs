using Microsoft.AspNetCore.Mvc;
using fuston.cliente;
using Microsoft.AspNetCore.Identity;
using fuston.utils;

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
        using var context = new ClienteContext();
        var clientes = context.Clientes
            .OrderBy(c => c.Nome)
            .ToList();

        return clientes;
    }

    [HttpGet]
    [Route("/cliente/documento/{documento}")]
    public Cliente GetClienteByDocumento(string documento)
    {
        using var context = new ClienteContext();

        var cliente = context.Clientes
            .Single(c => c.Documento == documento);

        return cliente;
    }

    [HttpGet]
    [Route("/cliente/{id}")]
    public Cliente GetCliente(int id)
    {
        using var context = new ClienteContext();

        var cliente = context.Clientes
            .Single(c => c.ClienteId == id);

        return cliente;
    }

    [HttpPost]
    [Route("/cliente")]
    public IActionResult CreateCliente([FromBody]Cliente body)
    {
        try
        {
            using var context = new ClienteContext();
 
            // validate
            if (context.Clientes.Any(x => x.Documento == body.Documento))
                throw new Exception("Documento '" + body.Documento + "' já está cadastrado.");

            // get password hashed
            body.Password = PasswordUtil.GetHashedPassword(body.Password);

            var cliente = context.Clientes
                .Add(body);

            context.SaveChanges();

            return new ObjectResult(cliente.Entity);
        }
        catch (System.Exception e)
        {
            return new ObjectResult( new { error = e.Message } );
        }
    }

    [HttpGet]
    [Route("/cliente/login")]
    public IActionResult AuthenticateCliente(string documento, string password)
    {
        try
        {
            using var context = new ClienteContext();

            var cliente = context.Clientes
                .Single(c => c.Documento == documento);

            // validate password
            if (!PasswordUtil.VerifyHashedPassword(password, cliente.Password))
            {
                throw new Exception("Sua senha não confere.");
            }

            return new ObjectResult(cliente);
        }
        catch (System.Exception e)
        {
            return new ObjectResult(new { error = e.Message });
        }
        
    }
}
