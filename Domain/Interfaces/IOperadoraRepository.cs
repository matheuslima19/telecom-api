using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOperadoraRepository
    {
      Task<IEnumerable<Operadora>> ObterTodasAsync();
      Task<Operadora?> ObterPorIdAsync(int id);
      Task AdicionarAsync(Operadora operadora);
      Task AtualizarAsync(Operadora operadora);
      Task RemoverAsync(int id);
    }
}