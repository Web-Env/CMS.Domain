using Microsoft.EntityFrameworkCore;

namespace CMS.Domain.Repositories.Tests
{
    public class RepositoryTestBase
    {
        public Repositories.CMSContext CreateTestContext()
        {
            DbContextOptions<Repositories.CMSContext> options;
            var builder = new DbContextOptionsBuilder<Repositories.CMSContext>();
            builder.UseInMemoryDatabase(nameof(Repositories.CMSContext));
            options = builder.Options;
            Repositories.CMSContext context = new Repositories.CMSContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }
}
