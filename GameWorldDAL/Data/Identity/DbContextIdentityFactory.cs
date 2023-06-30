using Microsoft.EntityFrameworkCore;

namespace GameWorldDAL.Data.Identity
{
    public class DbContextIdentityFactory
    {
        private readonly DbContextOptions options;

        public DbContextIdentityFactory(DbContextOptions options)
        {
            this.options = options;
        }

        public DbContextIdentity Create()
        {
            return new DbContextIdentity(options);
        }
    }
}