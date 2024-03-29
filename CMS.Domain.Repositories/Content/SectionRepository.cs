﻿using CMS.Domain.Entities;
using CMS.Domain.Repositories.Content.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Domain.Repositories.Content
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(CMSContext context) : base(context) { }

        public async new Task<Section> GetByIdAsync(Guid sectionId)
        {
            return await _CMSContext.Set<Section>()
                .Include(s => s.Contents)
                .Include(c => c.CreatedByNavigation)
                .Where(s => s.Id == sectionId)
                .FirstOrDefaultAsync();
        }

        public async new Task<IEnumerable<Section>> GetPageAsync(int pageNumber, int pageSize)
        {
            var offset = pageSize * (pageNumber - 1);

            return await _CMSContext.Set<Section>()
                .Include(c => c.Contents)
                .Include(c => c.CreatedByNavigation)
                .Skip(offset)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
