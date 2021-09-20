using CMS.Domain.Repositories.Contexts;
using CMS.Domain.Repositories.User.Interfaces;

namespace CMS.Domain.Repositories.User
{
    public class UserRepository : RepositoryBase<Entities.User>, IUserRepository
    {
        public UserRepository(CMSRepositoryContext context) : base(context) { }
    }
}
