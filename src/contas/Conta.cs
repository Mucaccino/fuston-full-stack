namespace fuston.contas;
using fuston.cliente;

public class Conta
{
    public required int Id { get; set; }
    public required Agencia Agencia { get; set; }
    public required float Numero { get; set; }
    public required float Saldo { get; set; }
    public required Cliente Cliente {get; set; }
}
