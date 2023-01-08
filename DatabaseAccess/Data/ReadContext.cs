using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Data
{
    public class ReadContext : DbContextConnection
    {
        public ReadContext()
        {
            
        }
        
        public ReadContext(DbContextOptions<DbContextConnection> options) : base(options)
        {
            
        }

        public override int SaveChanges()
        {
            // Throw if they try to call this
            throw new InvalidOperationException("This context is read-only.");
        }
    }
}
