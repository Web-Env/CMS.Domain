using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.Domain.Entities
{
    public partial class PasswordReset
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public string UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RequesterAddress { get; set; }
        public bool? Active { get; set; }
        public DateTime? UsedOn { get; set; }
        public string UsedByAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
