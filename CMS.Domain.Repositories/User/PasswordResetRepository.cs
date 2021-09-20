using CMS.Domain.Entities;
using CMS.Domain.Repositories.Contexts;
using CMS.Domain.Repositories.User.Interfaces;

namespace CMS.Domain.Repositories.User
{
    public class PasswordResetRepository : RepositoryBase<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(CMSRepositoryContext context) : base(context) { }
    }
}
