using CMS.Domain.Entities;
using CMS.Domain.Repositories.Contexts;
using CMS.Domain.Repositories.Interfaces;

namespace CMS.Domain.Repositories
{
    public class EntryRepository : RepositoryBase<Entry>, IEntryRepository
    {
        public EntryRepository(CMSRepositoryContext context) : base(context) { }
    }
}
