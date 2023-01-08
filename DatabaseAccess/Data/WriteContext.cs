
using Core.Infrastructure;
using DomainModel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Data
{
    public class WriteContext : DbContextConnection
    {
        private readonly IUserFetcher _userFetcher;

        public WriteContext(IUserFetcher userFetcher)
        {
            _userFetcher = userFetcher;
        }
        
        public WriteContext(DbContextOptions<DbContextConnection> options) : base(options)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AuditChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            AuditChanges();
            return base.SaveChanges();
        }

        private void AuditChanges()
        {
            var insertedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                var auditableEntity = insertedEntry as IAuditable;
                if (auditableEntity != null)
                {
                    auditableEntity.CreatedAt = DateTime.Now;
                    auditableEntity.CreatedBy = _userFetcher.GetCurrentUserName();
                }
            }

            var modifiedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                var auditableEntity = modifiedEntry as IAuditable;
                if (auditableEntity != null)
                {
                    auditableEntity.UpdatedAt = DateTime.Now;
                    auditableEntity.UpdatedBy = _userFetcher.GetCurrentUserName();
                }
            }
        }
    }
}
