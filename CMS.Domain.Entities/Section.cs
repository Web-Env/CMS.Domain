using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CMS.Domain.Entities
{
    [Table(nameof(Section))]
    public partial class Section
    {
        public Section()
        {
            Contents = new HashSet<Content>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        [NotMapped]
        public virtual User CreatedByNavigation { get; set; }
        [NotMapped]
        public virtual User LastUpdatedByNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<Content> Contents { get; set; }
    }
}
