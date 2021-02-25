using CMS.Domain.Tests.Funcs;
using CMS.Domain.Tests.Helpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CMS.Domain.Repositories.Tests
{
    [Trait("Category", "Unit")]
    public class AuditLogRepositoryTests : RepositoryTestBase
    {
        public AuditLogRepositoryTests(RepositoryDatabaseFixture fixture) : base(fixture) { } 
        
    }
}
