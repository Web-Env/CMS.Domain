using System;

namespace CMS.Domain.Repositories.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        IAuditLogRepository AuditLogRepository { get; }

        IEntryRepository EntryRepository { get; }

        IPasswordResetRepository PasswordResetRepository { get; }

        ISectionRepository SectionRepository { get; }

        IUserRepository UserRepository { get; }
    }
}
