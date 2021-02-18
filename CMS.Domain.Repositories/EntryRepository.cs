using CMS.Domain.Entities;
using CMS.Domain.Repositories.Interfaces;

namespace CMS.Domain.Repositories
{
    public class EntryRepository : RepositoryBase<Entry>, IEntryRepository
    {
        public EntryRepository(CMSContext context) : base(context) { }
    }
}
