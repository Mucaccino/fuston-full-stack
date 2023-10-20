namespace fuston.cliente;

public class Cliente
{
    public int ClienteId { get; set; }
    public required string Nome { get; set; }
    public required float Documento { get; set; }
    public required string Password { get; set; }
}
