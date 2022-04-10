using CMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content.Interfaces
{
    public interface ISectionRepository : IRepositoryBase<Section>
    {
        new Task<IEnumerable<Section>> GetPageAsync(int pageNumber, int pageSize);
    }
}
