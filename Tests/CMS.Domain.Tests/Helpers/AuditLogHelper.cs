using System;
using System.Collections.Generic;
using CMS.Domain.Entities;
using CMS.Domain.Enums; 

namespace CMS.Domain.Tests.Helpers
{
    public static class AuditLogHelper
    {
        public static AuditLog CreateOneAuditLogObject(User user) {

            return new AuditLog
            {
                Id = Guid.NewGuid(),
                ActionCategory = (short)UserActionCategory.Entry,
                Action = (short)UserAction.Create,
                UserId = user.Id,
                UserAddress = user.Email,
                OccurredOn = DateTime.Now
            };
        
        }

    }
}
