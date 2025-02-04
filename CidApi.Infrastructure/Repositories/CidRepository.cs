using CidApi.Domain.Interfaces;
using CidApi.Domain.Models;

namespace CidApi.Infrastructure.Repositories;

public class CidRepository : ICidRepository
{
    private static readonly List<Cid> Cids = new()
    {
        new Cid { Codigo = "A00", Descricao = "Cólera" },
        new Cid { Codigo = "A01", Descricao = "Febre tifóide e paratifóide" },
        new Cid { Codigo = "B01", Descricao = "Varicela" },
        new Cid { Codigo = "J18", Descricao = "Pneumonia não especificada" }
    };

    public List<Cid> GetAll() => Cids;

    public Cid? GetByCodigo(string codigo) =>
        Cids.FirstOrDefault(c => c.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
}
