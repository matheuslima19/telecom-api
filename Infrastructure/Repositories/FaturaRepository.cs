using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class FaturaRepository : IFaturaRepository
{
    private readonly TelecomDbContext _context;

    public FaturaRepository(TelecomDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Fatura>> ObterTodasAsync()
    {
        return await _context.Faturas.Include(f => f.Contrato).ToListAsync();
    }

    public async Task<Fatura?> ObterPorIdAsync(int id)
    {
        return await _context.Faturas.Include(f => f.Contrato)
                                     .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AdicionarAsync(Fatura fatura)
    {
        _context.Faturas.Add(fatura);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Fatura fatura)
    {
        _context.Faturas.Update(fatura);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var fatura = await _context.Faturas.FindAsync(id);
        if (fatura != null)
        {
            _context.Faturas.Remove(fatura);
            await _context.SaveChangesAsync();
        }
    }
}
