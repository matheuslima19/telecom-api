using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class DashboardService : IDashboardService
{
    private readonly TelecomDbContext _context;

    public DashboardService(TelecomDbContext context)
    {
        _context = context;
    }

    public async Task<object> ObterResumoAsync()
    {
      var hoje = DateTime.UtcNow;
      var hojeMenos12 = hoje.AddMonths(-11);

      var dataMinima = new DateTime(hojeMenos12.Year, hojeMenos12.Month, 1, 0, 0, 0, DateTimeKind.Utc);
      var totalFaturas = await _context.Faturas.CountAsync();

      var totalValor = await _context.Faturas
          .Where(f => f.DataEmissao.Month == hoje.Month && f.DataEmissao.Year == hoje.Year)
          .SumAsync(f => f.ValorCobrado);

      var distribuicaoStatus = await _context.Faturas
          .GroupBy(f => f.Status)
          .Select(g => new { Status = g.Key, Quantidade = g.Count() })
          .ToListAsync();

      var evolucaoBruta = await _context.Faturas
          .Where(f => f.DataEmissao >= dataMinima)
          .GroupBy(f => new { f.DataEmissao.Year, f.DataEmissao.Month })
          .Select(g => new
          {
              Ano = g.Key.Year,
              Mes = g.Key.Month,
              Emitidas = g.Count(),
              Pagas = g.Count(f => f.Status.ToLower() == "paga")
          })
          .ToListAsync();

      var evolucaoMensal = evolucaoBruta
          .OrderBy(e => new DateTime(e.Ano, e.Mes, 1))
          .Select(e => new
          {
              Mes = $"{e.Mes:D2}/{e.Ano}",
              e.Emitidas,
              e.Pagas
          })
          .ToList();

      return new
      {
          TotalFaturas = totalFaturas,
          ValorTotalFaturado = totalValor,
          DistribuicaoPorStatus = distribuicaoStatus,
          EvolucaoMensal = evolucaoMensal
      };
    }
}
