﻿using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content;
using CMS.Domain.Repositories.Content.Interfaces;
using CMS.Domain.Repositories.User;
using CMS.Domain.Repositories.User.Interfaces;

namespace CMS.Domain.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CMSContext _CMSContext;

        public IAnnouncementRepository AnnouncementRepository { get; private set; }
        public IContentRepository ContentRepository { get; private set; }
        public IContentTimeTrackingRepository ContentTimeTrackingRepository { get; private set; }
        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public ISectionRepository SectionRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public RepositoryManager(CMSContext context)
        {
            _CMSContext = context;

            AnnouncementRepository = new AnnouncementRepository(_CMSContext);
            ContentRepository = new ContentRepository(_CMSContext);
            ContentTimeTrackingRepository = new ContentTimeTrackingRepository(_CMSContext);
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
