using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repository_interfaces;
using Store.Persistance.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Repositories
{
    public class GenericRepository<TKey, TEntity>(StoreDbContext _context) : IGenericRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
      
        public async Task AddAsync(TEntity entity)
        {
         await   _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool changeTracker = false)
        {
            return changeTracker ?
                await _context.Set<TEntity>().ToListAsync() :
                await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdsync(TKey key)
        {
            if (key == null) return null;
            return await _context.Set<TEntity>().FindAsync(key);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
