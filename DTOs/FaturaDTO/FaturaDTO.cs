namespace DTOs;

public class FaturaDTO
{
    public int Id { get; set; }
    public int ContratoId { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal ValorCobrado { get; set; }
    public string Status { get; set; } = null!;
}