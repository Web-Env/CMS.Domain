using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetManyByIdAsync(IEnumerable<Guid> ids);

        Task<IEnumerable<T>> GetPageAsync(int pageNumber, int pageSize);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        Task<T> AddOrUpdateAsync(T entity);

        Task<IEnumerable<T>> AddOrUpdateRangeAsync(IEnumerable<T> entities);

        Task RemoveAsync(T entity);

        Task RemoveByIdAsync(Guid id);

        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task RemoveRangeByIdAsync(IEnumerable<Guid> ids);
    }
}
