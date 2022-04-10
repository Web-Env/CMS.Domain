﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CMS.Domain.Entities
{
    [Table(nameof(UserVerification))]
    public partial class UserVerification
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool? Active { get; set; }
        public string RequesterAddress { get; set; }
        public DateTime? UsedOn { get; set; }
        public string UsedByAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public virtual User User { get; set; }
    }
}
