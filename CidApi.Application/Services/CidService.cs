using CidApi.Domain.Interfaces;
using CidApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CidApi.Application.Services
{
    public class CidService
    {
        private readonly ICidRepository _repository;

        public CidService(ICidRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cid>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Cid?> GetByCodigoAsync(string codigo) => await _repository.GetByCodigoAsync(codigo);

        public async Task AddAsync(Cid cid) => await _repository.AddAsync(cid);

        public async Task UpdateAsync(Cid cid) => await _repository.UpdateAsync(cid);

        public async Task DeleteAsync(string codigo) => await _repository.DeleteAsync(codigo);
    }
}
