using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.User.Interfaces;
using System;

namespace CMS.Domain.Repositories
{
    public interface IRepositoryManager : IDisposable
    {
        IAnnouncementRepository AnnouncementRepository { get; }

        IContentRepository ContentRepository { get; }

        IContentTimeTrackingRepository ContentTimeTrackingRepository { get; }

        IPasswordResetRepository PasswordResetRepository { get; }

        ISectionRepository SectionRepository { get; }

        IUserRepository UserRepository { get; }
    }
}
