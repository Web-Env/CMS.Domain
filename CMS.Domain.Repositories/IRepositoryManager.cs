using CMS.Domain.Repositories.Audit.Interfaces;
using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.User.Interfaces;
using System;

namespace CMS.Domain.Repositories
{
    public interface IRepositoryManager : IDisposable
    {
        IAuditLogRepository AuditLogRepository { get; }

        IEntryRepository EntryRepository { get; }

        IPasswordResetRepository PasswordResetRepository { get; }

        ISectionRepository SectionRepository { get; }

        IUserRepository UserRepository { get; }

        IUserVerificationRepository UserVerificationRepository { get; }
    }
}
