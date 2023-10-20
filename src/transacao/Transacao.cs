namespace fuston.transacao;

public class Transacao
{
    public int TransacaoId { get; set; }
    public TipoEnum Tipo { get; set; }
    public float Valor { get; set; }
}