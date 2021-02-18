using CMS.Domain.Entities;
using CMS.Domain.Repositories.Interfaces;

namespace CMS.Domain.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CMSContext context) : base(context) { }
    }
}
