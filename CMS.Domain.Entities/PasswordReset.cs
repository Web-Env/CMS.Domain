using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CMS.Domain.Entities
{
    [Table(nameof(PasswordReset))]
    public partial class PasswordReset
    {
        public Guid Id { get; set; }
        public string ResetIdentifier { get; set; }
        public Guid UserId { get; set; }
        public DateTime Expiry { get; set; }
        public string RequesterAddress { get; set; }
        public bool? Active { get; set; }
    }
}
