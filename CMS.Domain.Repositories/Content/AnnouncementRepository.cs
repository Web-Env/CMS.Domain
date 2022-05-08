using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content
{
    public class AnnouncementRepository : RepositoryBase<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(CMSContext context) : base(context) { }

        public async new Task<IEnumerable<Announcement>> GetPageAsync(int pageNumber, int pageSize)
        {
            var offset = pageSize * (pageNumber - 1);

            return await _CMSContext.Set<Announcement>()
                .Include(c => c.CreatedByNavigation)
                .Skip(offset)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Announcement> GetByPathAsync(string announcementPath)
        {
            return await _CMSContext.Set<Announcement>()
                .Where(c => c.Path == announcementPath)
                .Include(c => c.CreatedByNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
