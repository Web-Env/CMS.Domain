using CMS.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content.Interfaces
{
    public interface IContentTimeTrackingRepository : IRepositoryBase<ContentTimeTracking>
    {
        Task<ContentTimeTracking> GetByContentIdAsync(Guid contentId);

        Task<ContentTimeTracking> GetByUserIdAsync(Guid userId);

        Task<ContentTimeTracking> GetByContentIdAndUserIdAsync(Guid contentId, Guid userId);
    }
}