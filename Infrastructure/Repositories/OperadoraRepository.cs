using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class OperadoraRepository : IOperadoraRepository
{
    private readonly TelecomDbContext _context;

    public OperadoraRepository(TelecomDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Operadora>> ObterTodasAsync()
    {
        return await _context.Operadoras.ToListAsync();
    }

    public async Task<Operadora?> ObterPorIdAsync(int id)
    {
        return await _context.Operadoras.FindAsync(id);
    }

    public async Task AdicionarAsync(Operadora operadora)
    {
        _context.Operadoras.Add(operadora);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Operadora operadora)
    {
        _context.Operadoras.Update(operadora);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var operadora = await _context.Operadoras.FindAsync(id);
        if (operadora != null)
        {
            _context.Operadoras.Remove(operadora);
            await _context.SaveChangesAsync();
        }
    }
}
