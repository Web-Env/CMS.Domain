using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetManyByIdAsync(IEnumerable<string> ids);

        Task<IEnumerable<T>> GetPageAsync(int pageNumber, int pageSize);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        Task<T> AddOrUpdateAsync(T entity);

        Task<IEnumerable<T>> AddOrUpdateRangeAsync(IEnumerable<T> entities);

        Task RemoveAsync(T entity);

        Task RemoveByIdAsync(string id);

        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task RemoveRangeByIdAsync(IEnumerable<string> ids);
    }
}
