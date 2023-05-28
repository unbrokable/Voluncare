using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Models;
using Voluncare.Core.Specification;

namespace Voluncare.Core.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : IDbEntity
    {
        Task<TEntity> FindAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<TEntity> GetEntityAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<ItemPage<TEntity>> GetAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        Task<ItemPage<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task RemoveAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> GetWithIncludeAsync(Specification<TEntity> specification, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<ItemPage<TEntity>> GetListWithIncludeAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties);

        Task SaveChanges();
    }
}
