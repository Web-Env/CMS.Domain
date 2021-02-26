using CMS.Domain.Entities;
using CMS.Domain.Enums;
using CMS.Domain.Tests.Consts;
using System;
using System.Collections.Generic;

namespace CMS.Domain.Tests.Helpers
{
    public static class AuditLogHelper
    {
        public static AuditLog CreateOneAuditLogObject(Guid userId) {

            return new AuditLog
            {
                Id = Guid.NewGuid(),
                ActionCategory = (short)UserActionCategory.Entry,
                Action = (short)UserAction.Create,
                UserId = userId,
                UserAddress = UserConsts.DefaultUserAddress,
                OccurredOn = DateTime.Now
            };
        }

        public static List<AuditLog> CreateManyAuditLogObject(Guid userId)
        {
            var auditLogs = new List<AuditLog>();

            for (var i=0; i < 10; i++)
            {
                auditLogs.Add(CreateOneAuditLogObject(userId));
            }

            return auditLogs;
        }

        public static List<AuditLog> CreateAuditLogPageObjects()
        {
            var auditLogs = new List<AuditLog>();
            var users = UserHelper.CreateUserPageObjects();

            foreach (User user in users)
            {
                for (var i = 0; i < 25; i++)
                {
                    auditLogs.Add(CreateOneAuditLogObject(user.Id));
                }
            }

            return auditLogs;
        }

    }
}
