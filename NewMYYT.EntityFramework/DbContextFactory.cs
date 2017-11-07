using Microsoft.EntityFrameworkCore;

namespace NewMYYT.EntityFramework
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext dbContext;
        public DbContextFactory()
        {
            dbContext = new Db(new DbContextOptions<Db>());
        }

        public DbContext GetContext()
        {
            return dbContext;
        }

    }
}