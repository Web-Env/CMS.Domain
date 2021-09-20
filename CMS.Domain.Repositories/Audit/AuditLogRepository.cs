using CMS.Domain.Entities;
using CMS.Domain.Repositories.Audit.Interfaces;
using CMS.Domain.Repositories.Contexts;

namespace CMS.Domain.Repositories.Audit
{
    public class AuditLogRepository : RepositoryBase<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(CMSRepositoryContext context) : base(context) { }
    }
}
