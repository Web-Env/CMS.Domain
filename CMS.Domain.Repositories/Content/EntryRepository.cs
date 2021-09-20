using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.Contexts;

namespace CMS.Domain.Repositories.Content
{
    public class EntryRepository : RepositoryBase<Entry>, IEntryRepository
    {
        public EntryRepository(CMSRepositoryContext context) : base(context) { }
    }
}
