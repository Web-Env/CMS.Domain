using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(CMSRepositoryContext context) : base(context) { }

        public async new Task<IEnumerable<Section>> GetPageAsync(int pageNumber, int pageSize)
        {
            var offset = pageSize * (pageNumber - 1);

            return await _CMSContext.Set<Section>()
                .Include(c => c.CreatedByNavigation)
                .Skip(offset)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
