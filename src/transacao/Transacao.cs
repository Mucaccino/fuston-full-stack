using fuston.contas;

namespace fuston.transacao;

public class Transacao
{
    public int TransacaoId { get; set; }
    public TipoEnum Tipo { get; set; }
    public float Valor { get; set; }
    public int ContaId { get; set; }
    public Conta? Conta { get; set; }
}