using CMS.Domain.Entities;
using CMS.Domain.Repositories.Interfaces;

namespace CMS.Domain.Repositories
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(CMSContext context) : base(context) { }
    }
}
