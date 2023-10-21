namespace fuston.contas;
using fuston.cliente;

public class Conta
{
    public int ContaId { get; set; }
    public int AgenciaId { get; set; }
    public Agencia? Agencia { get; set; }
    public required string Numero { get; set; }
    public float Saldo { get; set; }
    public int ClienteId {get; set; }
    public Cliente? Cliente {get; set; }
}
