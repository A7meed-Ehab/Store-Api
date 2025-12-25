using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Repository_interfaces
{
    public interface IGenericRepository<Tkey,TEntity> where TEntity:BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAll(bool changeTracker = false);
        Task<TEntity?> GetById(Tkey Tkey);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);    
    }
}
