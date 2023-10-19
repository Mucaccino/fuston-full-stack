namespace fuston.transacao;

public class Transacao
{
    public required int Id { get; set; }
    public required TipoEnum Tipo { get; set; }
    public required float Valor { get; set; }
}