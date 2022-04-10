using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.Domain.Entities
{
    public partial class AuditLog
    {
        public Guid Id { get; set; }
        public short ActionCategory { get; set; }
        public short Action { get; set; }
        public Guid UserId { get; set; }
        public string UserAddress { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
