using CMS.Domain.Entities;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.User.Interfaces
{
    public interface IPasswordResetRepository : IRepositoryBase<PasswordReset>
    {
        Task<PasswordReset> FindByIdentifierAsync(string resetIdentifier);
    }
}
