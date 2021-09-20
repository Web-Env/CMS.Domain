using CMS.Domain.Entities;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.User.Interfaces
{
    public interface IUserVerificationRepository : IRepositoryBase<UserVerification>
    {
        Task<UserVerification> FindByIdentifierAsync(string verificationIdentifier);
    }
}
