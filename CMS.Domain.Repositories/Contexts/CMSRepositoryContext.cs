using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Domain.Repositories.Contexts
{
    public class CMSRepositoryContext : DbContext
    {
        public CMSRepositoryContext(DbContextOptions<CMSRepositoryContext> options) : base(options) { }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<Entities.Content> Contents { get; set; }

        public DbSet<PasswordReset> PasswordResets { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Entities.User> Users { get; set; }

        public DbSet<UserVerification> UserVerifications { get; set; }
    }
}
