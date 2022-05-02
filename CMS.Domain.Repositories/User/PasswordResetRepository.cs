using CMS.Domain.Entities;
using CMS.Domain.Repositories.User.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.User
{
    public class PasswordResetRepository : RepositoryBase<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(CMSContext context) : base(context) { }

        public async Task<PasswordReset> FindByIdentifierAsync(string resetIdentifier)
        {
            var passwordReset = await _CMSContext.PasswordResets.Where(pr =>
                pr.Identifier == resetIdentifier).FirstOrDefaultAsync();

            return passwordReset;
        }
    }
}
