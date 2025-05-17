using DTOs;

namespace Application.Interfaces;

public interface IFaturaService
{
    Task<IEnumerable<FaturaDTO>> ListarAsync();
    Task<FaturaDTO?> ObterPorIdAsync(int id);
    Task CriarAsync(FaturaDTO dto);
    Task AtualizarAsync(int id, FaturaDTO dto);
    Task RemoverAsync(int id);
}
