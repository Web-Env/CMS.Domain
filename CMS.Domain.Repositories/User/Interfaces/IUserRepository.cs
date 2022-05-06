using CMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.User.Interfaces
{
    public interface IUserRepository : IRepositoryBase<Entities.User>
    {
        new Task<IEnumerable<VGetUser>> GetPageAsync(int pageNumber, int pageSize);
    }
}
