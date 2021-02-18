using CMS.Domain.Entities;
using CMS.Domain.Repositories.Interfaces;

namespace CMS.Domain.Repositories
{
    public class PasswordResetRepository : RepositoryBase<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(CMSContext context) : base(context) { }
    }
}
