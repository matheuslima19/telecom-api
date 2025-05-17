using DTOs;

namespace Application.Interfaces;

public interface IContratoService
{
    Task<IEnumerable<ContratoDTO>> ListarAsync();
    Task<ContratoDTO?> ObterPorIdAsync(int id);
    Task CriarAsync(CreateContratoDto dto);
    Task AtualizarAsync(int id, ContratoDTO dto);
    Task RemoverAsync(int id);
}
