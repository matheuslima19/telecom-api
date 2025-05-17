using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ContratoRepository : IContratoRepository
{
    private readonly TelecomDbContext _context;

    public ContratoRepository(TelecomDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contrato>> ObterTodosAsync()
    {
        return await _context.Contratos.Include(c => c.Operadora).ToListAsync();
    }

    public async Task<Contrato?> ObterPorIdAsync(int id)
    {
        return await _context.Contratos.Include(c => c.Operadora)
                                       .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AdicionarAsync(Contrato contrato)
    {
        _context.Contratos.Add(contrato);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Contrato contrato)
    {
        _context.Contratos.Update(contrato);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var contrato = await _context.Contratos.FindAsync(id);
        if (contrato != null)
        {
            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();
        }
    }
}
