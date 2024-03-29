﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.Domain.Entities
{
    public partial class Content
    {
        public Content()
        {
            ContentTimeTrackings = new HashSet<ContentTimeTracking>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? SectionId { get; set; }
        public string Path { get; set; }
        public bool? Active { get; set; }
        public int Views { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<ContentTimeTracking> ContentTimeTrackings { get; set; }
    }
}
