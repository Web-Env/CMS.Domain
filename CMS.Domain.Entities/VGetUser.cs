using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.Domain.Entities
{
    public partial class VGetUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public string CreatedByName { get; set; }
    }
}
