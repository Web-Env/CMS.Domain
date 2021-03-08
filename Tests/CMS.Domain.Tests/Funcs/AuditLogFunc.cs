﻿using CMS.Domain.Entities;
using CMS.Domain.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Tests.Funcs
{
    public static class AuditLogFunc
    {

        public static async Task<AuditLog> CreateOneAuditLog(CMSContext context, Guid userId)
        {
            var auditLog = AuditLogHelper.CreateOneAuditLogObject(userId);

            context.AuditLogs.Add(auditLog);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return auditLog;
        }

        public static async Task<AuditLog> GetAuditLogById(CMSContext context, Guid id)
        {
            return await context.AuditLogs.FindAsync(id);
        }

        public static async Task<List<AuditLog>> CreateManyAuditLogs(CMSContext context)
        {
            var auditLogs = AuditLogHelper.CreateManyAuditLogObject();

            context.AuditLogs.AddRange(auditLogs);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return auditLogs;
        }

    }
}