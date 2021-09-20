using CMS.Domain.Entities;
using CMS.Domain.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CMS.Domain.Repositories.Tests
{
    public abstract class RepositoryTestBase : IClassFixture<RepositoryDatabaseFixture>
    {
        private readonly RepositoryDatabaseFixture _repositoryDatabaseFixture;
        public IRepositoryManager RepositoryManager { get; private set; }

        protected RepositoryTestBase(RepositoryDatabaseFixture fixture)
        {
            _repositoryDatabaseFixture = fixture;
            RepositoryManager = new RepositoryManager(CreateTestRepositoryContext());
        }

        public CMSRepositoryContext CreateTestRepositoryContext()
        {
            var options = new DbContextOptionsBuilder<CMSRepositoryContext>()
                .UseSqlite(_repositoryDatabaseFixture.GetConnection())
                .Options;
            CMSRepositoryContext context = new CMSRepositoryContext(options);

            return context;
        }

        public CMSContext GetContext()
        {
            return _repositoryDatabaseFixture.GetContext();
        }

        public CMSContext NewContext()
        {
            var context = _repositoryDatabaseFixture.NewContext();
            RepositoryManager = new RepositoryManager(CreateTestRepositoryContext());
            return context;
        }
    }
}
