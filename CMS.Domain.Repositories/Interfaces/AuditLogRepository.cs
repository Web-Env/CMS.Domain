using CMS.Domain.Entities;
using CMS.Domain.Repositories.Interfaces;

namespace CMS.Domain.Repositories
{
    public class AuditLogRepository : RepositoryBase<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(CMSContext context) : base(context) { }
    }
}
