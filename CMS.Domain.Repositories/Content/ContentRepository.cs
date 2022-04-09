using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.Contexts;

namespace CMS.Domain.Repositories.Content
{
    public class ContentRepository : RepositoryBase<Entities.Content>, IContentRepository
    {
        public ContentRepository(CMSRepositoryContext context) : base(context) { }
    }
}
