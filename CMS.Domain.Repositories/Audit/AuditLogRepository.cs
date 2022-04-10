using CMS.Domain.Entities;
using CMS.Domain.Repositories.Audit.Interfaces;

namespace CMS.Domain.Repositories.Audit
{
    public class AuditLogRepository : RepositoryBase<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(CMSContext context) : base(context) { }
    }
}
