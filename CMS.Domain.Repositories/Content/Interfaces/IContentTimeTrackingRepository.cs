using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content.Interfaces
{
    public interface IContentTimeTrackingRepository : IRepositoryBase<ContentTimeTracking>
    {
        Task<IEnumerable<ContentTimeTracking>> GetByContentIdAsync(Guid contentId);

        Task<IEnumerable<ContentTimeTracking>> GetByUserIdAsync(Guid userId);

        Task<ContentTimeTracking> GetByContentIdAndUserIdAsync(Guid contentId, Guid userId);
    }
}