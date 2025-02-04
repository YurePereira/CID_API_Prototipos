using CidApi.Domain.Models;

namespace CidApi.Domain.Interfaces;

public interface ICidRepository
{
    List<Cid> GetAll();
    Cid? GetByCodigo(string codigo);
}
