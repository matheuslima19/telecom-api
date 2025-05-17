using Domain.Entities;

namespace Domain.Interfaces;

public interface IFaturaRepository
{
    Task<IEnumerable<Fatura>> ObterTodasAsync();
    Task<Fatura?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Fatura fatura);
    Task AtualizarAsync(Fatura fatura);
    Task RemoverAsync(int id);
}
