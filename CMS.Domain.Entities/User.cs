﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Contents = new HashSet<Content>();
            Sections = new HashSet<Section>();
            UserVerifications = new HashSet<UserVerification>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserSecret { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<UserVerification> UserVerifications { get; set; }
    }
}
