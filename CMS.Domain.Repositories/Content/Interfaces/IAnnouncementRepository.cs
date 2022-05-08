using CMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content.Interfaces
{
    public interface IAnnouncementRepository : IRepositoryBase<Announcement>
    {
        new Task<IEnumerable<Announcement>> GetPageAsync(int pageNumber, int pageSize);

        Task<Announcement> GetByPathAsync(string announcementPath);
    }
}
