using CMS.Domain.Entities;
using CMS.Domain.Repositories.User.Interfaces;

namespace CMS.Domain.Repositories.User
{
    public class UserRepository : RepositoryBase<Entities.User>, IUserRepository
    {
        public UserRepository(CMSContext context) : base(context) { }
    }
}
