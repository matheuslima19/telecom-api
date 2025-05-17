using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data;

public class TelecomDbContext : DbContext
{
    public TelecomDbContext(DbContextOptions<TelecomDbContext> options)
        : base(options) { }

    public DbSet<Operadora> Operadoras { get; set; } = null!;
    public DbSet<Contrato> Contratos { get; set; } = null!;
    public DbSet<Fatura> Faturas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.Property(e => e.DataInicio)
                  .HasColumnType("date");

            entity.Property(e => e.DataVencimento)
                  .HasColumnType("date");
        });

        modelBuilder.Entity<Fatura>(entity =>
        {
            entity.Property(e => e.DataEmissao)
                  .HasColumnType("date");

            entity.Property(e => e.DataVencimento)
                  .HasColumnType("date");
        });

        base.OnModelCreating(modelBuilder);
    }
}
