using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content
{
    public class ContentRepository : RepositoryBase<Entities.Content>, IContentRepository
    {
        public ContentRepository(CMSRepositoryContext context) : base(context) { }

        public async new Task<IEnumerable<Entities.Content>> GetPageAsync(int pageNumber, int pageSize)
        {
            var offset = pageSize * (pageNumber - 1);

            return await _CMSContext.Set<Entities.Content>()
                .Include(c => c.Section)
                .Include(c => c.CreatedByNavigation)
                .Skip(offset)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
