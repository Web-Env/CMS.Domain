using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.Domain.Entities
{
    public partial class ContentTimeTracking
    {
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public Guid UserId { get; set; }
        public int TotalTime { get; set; }
        public DateTime LastSeen { get; set; }

        public virtual Content Content { get; set; }
        public virtual User User { get; set; }
    }
}
