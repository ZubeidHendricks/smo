using Microsoft.EntityFrameworkCore;
using NPOMS.Repository;

namespace NPOMS.Tests.Config
{
	public static class ContextConfig
    {
        public static RepositoryContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseSqlServer(@"Data Source=NB-R90NMLM3\\LOCALDEV;Initial Catalog=NPOMS;Integrated Security=True");
            DbContextOptions<RepositoryContext> options = builder.Options;
            return new RepositoryContext(options);
        }
    }
}
