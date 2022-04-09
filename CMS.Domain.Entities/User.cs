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
            ContentCreatedByNavigations = new HashSet<Content>();
            ContentLastUpdatedByNavigations = new HashSet<Content>();
            SectionCreatedByNavigations = new HashSet<Section>();
            SectionLastUpdatedByNavigations = new HashSet<Section>();
            UserVerifications = new HashSet<UserVerification>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserSecret { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        [NotMapped]
        public virtual ICollection<Content> ContentCreatedByNavigations { get; set; }
        [NotMapped]
        public virtual ICollection<Content> ContentLastUpdatedByNavigations { get; set; }
        [NotMapped]
        public virtual ICollection<Section> SectionCreatedByNavigations { get; set; }
        [NotMapped]
        public virtual ICollection<Section> SectionLastUpdatedByNavigations { get; set; }
        [NotMapped]
        public virtual ICollection<UserVerification> UserVerifications { get; set; }
    }
}
