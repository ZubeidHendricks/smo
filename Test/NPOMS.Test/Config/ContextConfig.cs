using Microsoft.EntityFrameworkCore;
using NPOMS.Repository;

namespace NPOMS.Test.Config
{
    public static class ContextConfig
    {
        public static RepositoryContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseSqlServer(@"Data Source=.;Initial Catalog=NPOMS-Mixed;Integrated Security=True");
            DbContextOptions<RepositoryContext> options = builder.Options;
            return new RepositoryContext(options);
        }
    }
}
