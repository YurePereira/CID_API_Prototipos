using Microsoft.EntityFrameworkCore;
using CidApi.Domain.Models;

namespace CidApi.Infrastructure.Data;

public class CidDbContext : DbContext
{
    public CidDbContext(DbContextOptions<CidDbContext> options) : base(options) { }

    public DbSet<Cid> Cids { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cid>().HasKey(c => c.Codigo);

        modelBuilder.Entity<Cid>().HasData(
            new Cid { Codigo = "A00", Descricao = "Cólera" },
            new Cid { Codigo = "A01", Descricao = "Febre tifóide e paratifóide" },
            new Cid { Codigo = "B01", Descricao = "Varicela" },
            new Cid { Codigo = "B02", Descricao = "Varicela2" },
            new Cid { Codigo = "B03", Descricao = "Varicela3" },
            new Cid { Codigo = "B04", Descricao = "Varicela4" },
            new Cid { Codigo = "J18", Descricao = "Pneumonia não especificada" }
        );
    }
}
