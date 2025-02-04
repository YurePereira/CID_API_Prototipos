using CidApi.Domain.Interfaces;
using CidApi.Domain.Models;

namespace CidApi.Application.Services;

public class CidService
{
    private readonly ICidRepository _cidRepository;

    public CidService(ICidRepository cidRepository)
    {
        _cidRepository = cidRepository;
    }

    public List<Cid> GetAll() => _cidRepository.GetAll();

    public Cid? GetByCodigo(string codigo) => _cidRepository.GetByCodigo(codigo);
}
