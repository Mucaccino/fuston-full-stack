using fuston.contas;

namespace fuston.transacao;

public class Transacao
{
    public int TransacaoId { get; set; }
    public TransacaoTipoEnum Tipo { get; set; }
    public float Valor { get; set; }
    public int ContaId { get; set; }
    public Conta? Conta { get; set; }
}