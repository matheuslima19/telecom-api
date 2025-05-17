namespace DTOs
{
    public class CreateOperadoraDTO
    {
        public string Nome { get; set; } = null!;
        public string TipoServico { get; set; } = null!;
        public string? ContatoSuporte { get; set; }
    }
}