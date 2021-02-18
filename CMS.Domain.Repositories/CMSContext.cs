﻿using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Domain.Repositories
{
    public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base(options) { }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<Entry> Entries { get; set; }

        public DbSet<PasswordReset> PasswordResets { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
