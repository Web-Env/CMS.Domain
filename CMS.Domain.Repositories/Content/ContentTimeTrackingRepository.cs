using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content
{
    public class ContentTimeTrackingRepository : RepositoryBase<ContentTimeTracking>, IContentTimeTrackingRepository
    {
        public ContentTimeTrackingRepository(CMSContext context) : base(context) { }

        public async Task<ContentTimeTracking> GetByContentIdAsync(Guid contentId)
        {
            return await _CMSContext.Set<ContentTimeTracking>()
                .Where(c => c.ContentId == contentId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<ContentTimeTracking> GetByUserIdAsync(Guid userId)
        {
            return await _CMSContext.Set<ContentTimeTracking>()
                .Where(c => c.UserId == userId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<ContentTimeTracking> GetByContentIdAndUserIdAsync(Guid contentId, Guid userId)
        {
            return await _CMSContext.Set<ContentTimeTracking>()
                .Where(c => c.ContentId == contentId && c.UserId == userId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
