using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;
using Voluncare.Core.Models;
using Voluncare.Core.Specification;
using Voluncare.EntityFramework.Context;
using Voluncare.Infrastructure.Pagination;

namespace Voluncare.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDbEntity
    {
        protected readonly VoluncareDbContext context;
        protected readonly DbSet<TEntity> entities;

        public Repository(VoluncareDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.entities.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await this.entities.AddAsync(entity, cancellationToken).AsTask();
        }

        public async Task AddAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        {
            await this.entities.AddRangeAsync(entities, cancellationToken);
        }

        public async Task<TEntity> FindAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await this.entities.FirstOrDefaultAsync(specification.Expression, cancellationToken);
        }

        public async Task<TEntity> GetEntityAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await this.entities.Where(specification.Expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await this.entities.Where(specification.Expression).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemPage<TEntity>> GetAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await this.entities.ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<ItemPage<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await this.entities.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync();
        }

        public async Task<TEntity> GetWithIncludeAsync(Specification<TEntity> specification, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return await query.Where(specification.Expression).FirstOrDefaultAsync();
        }

        public async Task<ItemPage<TEntity>> GetListWithIncludeAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return await query.Where(entity => entity == entity).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<ItemPage<TEntity>> GetListWithIncludeAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return await query.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.entities.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        {
            this.entities.RemoveRange(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.entities.Update(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        {
            this.entities.UpdateRange(entity);
            await Task.CompletedTask;
        }

        public async Task<int> CountAsync(Specification<TEntity> specification)
        {
            return await this.entities.CountAsync(specification.Expression);
        }
    }
}
