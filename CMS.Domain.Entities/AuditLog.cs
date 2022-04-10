using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CMS.Domain.Entities
{
    [Table(nameof(AuditLog))]
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
