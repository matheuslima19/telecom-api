using Domain.Entities;

namespace Domain.Interfaces;

public interface IContratoRepository
{
    Task<IEnumerable<Contrato>> ObterTodosAsync();
    Task<Contrato?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Contrato contrato);
    Task AtualizarAsync(Contrato contrato);
    Task RemoverAsync(int id);
}
