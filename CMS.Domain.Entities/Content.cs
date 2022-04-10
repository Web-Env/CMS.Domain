using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CMS.Domain.Entities
{
    [Table(nameof(Content))]
    public partial class Content
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? SectionId { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public int Views { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        [NotMapped]
        public virtual User CreatedByNavigation { get; set; }
        public virtual Section Section { get; set; }
    }
}
