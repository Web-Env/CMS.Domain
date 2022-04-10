using CMS.Domain.Entities;
using CMS.Domain.Repositories.Contexts;
using CMS.Domain.Repositories.User.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.User
{
    public class UserVerificationRepository : RepositoryBase<UserVerification>, IUserVerificationRepository
    {
        public UserVerificationRepository(CMSContext context) : base(context) { }

        public async Task<UserVerification> FindByIdentifierAsync(string verificationIdentifier)
        {
            var userVerification = await _CMSContext.UserVerifications.Where(uv =>
                uv.Identifier == verificationIdentifier).FirstOrDefaultAsync();

            return userVerification;
        }
    }
}
