using CMS.Domain.Repositories.Audit;
using CMS.Domain.Repositories.Audit.Interfaces;
using CMS.Domain.Repositories.Content;
using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.Contexts;
using CMS.Domain.Repositories.User;
using CMS.Domain.Repositories.User.Interfaces;

namespace CMS.Domain.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CMSRepositoryContext _CMSContext;

        public IAuditLogRepository AuditLogRepository { get; private set; }
        public IEntryRepository EntryRepository { get; private set; }
        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public ISectionRepository SectionRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IUserVerificationRepository UserVerificationRepository { get; private set; }

        public RepositoryManager(CMSRepositoryContext context)
        {
            _CMSContext = context;

            AuditLogRepository = new AuditLogRepository(_CMSContext);
            EntryRepository = new EntryRepository(_CMSContext);
            PasswordResetRepository = new PasswordResetRepository(_CMSContext);
            SectionRepository = new SectionRepository(_CMSContext);
            UserRepository = new UserRepository(_CMSContext);
            UserVerificationRepository = new UserVerificationRepository(_CMSContext);
        }

        public void Dispose()
        {
            _CMSContext.Dispose();
        }
    }
}
