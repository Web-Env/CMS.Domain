using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;

namespace CMS.Domain.Repositories.Content
{
    public class ContentTimeTrackingRepository : RepositoryBase<ContentTimeTracking>, IContentTimeTrackingRepository
    {
        public ContentTimeTrackingRepository(CMSContext context) : base(context) { }
    }
}
