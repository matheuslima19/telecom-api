namespace DTOs
{
    public class OperadoraDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string TipoServico { get; set; } = null!;
        public string? ContatoSuporte { get; set; }
    }
}