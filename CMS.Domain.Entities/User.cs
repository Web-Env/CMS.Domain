using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CMS.Domain.Entities
{
    [Table(nameof(User))]
    public partial class User
    {
        public User()
        {
            AuditLogs = new HashSet<AuditLog>();
            EntryCreatedByNavigations = new HashSet<Entry>();
            EntryLastUpdatedByNavigations = new HashSet<Entry>();
            SectionCreatedByNavigations = new HashSet<Section>();
            SectionLastUpdatedByNavigations = new HashSet<Section>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        [NotMapped]
        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        [NotMapped]
        public virtual ICollection<Entry> EntryCreatedByNavigations { get; set; }
        [NotMapped]
        public virtual ICollection<Entry> EntryLastUpdatedByNavigations { get; set; }
        [NotMapped]
        public virtual ICollection<Section> SectionCreatedByNavigations { get; set; }
        [NotMapped]
        public virtual ICollection<Section> SectionLastUpdatedByNavigations { get; set; }
    }
}
