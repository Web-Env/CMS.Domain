using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.Contexts;

namespace CMS.Domain.Repositories.Content
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(CMSRepositoryContext context) : base(context) { }
    }
}
