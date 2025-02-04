using CidApi.Domain.Interfaces;
using CidApi.Domain.Models;
using CidApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CidApi.Infrastructure.Repositories
{
    public class CidRepository : ICidRepository
    {
        private readonly CidDbContext _context;

        public CidRepository(CidDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cid>> GetAllAsync()
        {
            return await _context.Cids.ToListAsync();
        }

        public async Task<Cid?> GetByCodigoAsync(string codigo)
        {
            return await _context.Cids.FindAsync(codigo);
        }

        public async Task AddAsync(Cid cid)
        {
            _context.Cids.Add(cid);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cid cid)
        {
            _context.Cids.Update(cid);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string codigo)
        {
            var cid = await GetByCodigoAsync(codigo);
            if (cid != null)
            {
                _context.Cids.Remove(cid);
                await _context.SaveChangesAsync();
            }
        }
    }
}
