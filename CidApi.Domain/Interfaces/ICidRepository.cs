using CidApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CidApi.Domain.Interfaces
{
    public interface ICidRepository
    {
        Task<IEnumerable<Cid>> GetAllAsync();
        Task<Cid?> GetByCodigoAsync(string codigo);
        Task AddAsync(Cid cid);
        Task UpdateAsync(Cid cid);
        Task DeleteAsync(string codigo);
    }
}
