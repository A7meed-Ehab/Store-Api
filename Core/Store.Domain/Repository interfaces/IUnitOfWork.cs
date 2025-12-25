using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Repository_interfaces
{
    public interface IUnitOfWork//: IDisposable
    {
        IGenericRepository<TKey, TEntity> GetGenericRepository<TKey, TEntity>() where TEntity : BaseEntity<TKey>;
        Task<int> SaveChangesAsync();

    }
}
