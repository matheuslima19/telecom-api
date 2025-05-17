namespace DTOs;

public class CreateFaturaDto
{
    public int ContratoId { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = null!;
}
