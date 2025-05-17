namespace DTOs;

public class CreateContratoDto
{
    public string NomeFilial { get; set; } = null!;
    public int OperadoraId { get; set; }
    public string PlanoContratado { get; set; } = null!;
    public DateTime DataInicio { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal ValorMensal { get; set; }
    public string Status { get; set; } = null!;
}
