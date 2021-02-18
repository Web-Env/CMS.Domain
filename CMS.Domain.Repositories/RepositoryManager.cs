using CMS.Domain.Repositories.Interfaces;

namespace CMS.Domain.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CMSContext _CMSContext;

        public IAuditLogRepository AuditLogRepository { get; private set; }
        public IEntryRepository EntryRepository { get; private set; }
        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public ISectionRepository SectionRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public RepositoryManager(CMSContext context)
        {
            _CMSContext = context;

            AuditLogRepository = new AuditLogRepository(_CMSContext);
            EntryRepository = new EntryRepository(_CMSContext);
            PasswordResetRepository = new PasswordResetRepository(_CMSContext);
            SectionRepository = new SectionRepository(_CMSContext);
            UserRepository = new UserRepository(_CMSContext);
        }

        public void Dispose()
        {
            _CMSContext.Dispose();
        }
    }
}
