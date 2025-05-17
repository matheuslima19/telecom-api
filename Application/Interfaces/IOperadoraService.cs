using DTOs;

namespace Application.Interfaces
{
    public interface IOperadoraService
    {
      Task<IEnumerable<OperadoraDTO>> ListarAsync();
      Task<OperadoraDTO?> ObterPorIdAsync(int id);
      Task CriarAsync(CreateOperadoraDTO dto);
      Task AtualizarAsync(int id, OperadoraDTO dto);
      Task RemoverAsync(int id);
    }
}