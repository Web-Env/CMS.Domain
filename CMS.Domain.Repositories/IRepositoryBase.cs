using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetManyByIdAsync(IEnumerable<Guid> ids);

        Task<IEnumerable<T>> GetPageAsync(int pageNumber, int pageSize);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity);

        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);

        Task RemoveAsync(T entity);

        Task RemoveByIdAsync(Guid id);

        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task RemoveRangeByIdAsync(IEnumerable<Guid> ids);
    }
}
