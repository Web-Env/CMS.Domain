using CMS.Domain.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly CMSRepositoryContext _CMSContext;
        public RepositoryBase(CMSRepositoryContext context)
        {
            _CMSContext = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _CMSContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _CMSContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetManyByIdAsync(IEnumerable<Guid> ids)
        {
            return await _CMSContext.Set<T>().Where(x => ids.Contains(EF.Property<Guid>(x, "Id"))).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPageAsync(int pageNumber, int pageSize)
        {
            var offset = pageSize * (pageNumber - 1);

            return await _CMSContext.Set<T>()
                .Skip(offset)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _CMSContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _CMSContext.Set<T>().Add(entity);
            await _CMSContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            _CMSContext.Set<T>().AddRange(entities);
            await _CMSContext.SaveChangesAsync();
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _CMSContext.Set<T>().Update(entity);
            await _CMSContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _CMSContext.Set<T>().UpdateRange(entities);
            await _CMSContext.SaveChangesAsync();
            return entities;
        }

        public async Task RemoveAsync(T entity)
        {
            _CMSContext.Set<T>().Remove(entity);
            await _CMSContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id).ConfigureAwait(false);
            await RemoveAsync(entity).ConfigureAwait(false);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _CMSContext.RemoveRange(entities);
            await _CMSContext.SaveChangesAsync();
        }

        public async Task RemoveRangeByIdAsync(IEnumerable<Guid> ids)
        {
            var entities = await GetManyByIdAsync(ids).ConfigureAwait(false);
            await RemoveRangeAsync(entities).ConfigureAwait(false);
        }
    }
}
