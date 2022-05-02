using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content.Interfaces
{
    public interface IContentRepository : IRepositoryBase<Entities.Content>
    {
        new Task<IEnumerable<Entities.Content>> GetPageAsync(int pageNumber, int pageSize);

        Task<Entities.Content> GetByPathAsync(string contentPath);
    }
}
