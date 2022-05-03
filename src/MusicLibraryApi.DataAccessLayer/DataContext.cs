using Microsoft.EntityFrameworkCore;
using MusicLibraryApi.DataAccessLayer.Entities.Common;
using System.Reflection;

namespace MusicLibraryApi.DataAccessLayer;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public void Delete<T>(T entity) where T : BaseEntity
    {
        Set<T>().Remove(entity);
    }
    public void Delete<T>(IEnumerable<T> entities) where T : BaseEntity
    {
        Set<T>().RemoveRange(entities);
    }
    public ValueTask<T> GetAsync<T>(params object[] keyValues) where T : BaseEntity
    {
        return Set<T>().FindAsync(keyValues);
    }
    public IQueryable<T> GetQuery<T>(bool ignoreQueryFilters = false, bool trackingChanges = false) where T : BaseEntity
    {
        var query = Set<T>().AsQueryable();

        if (ignoreQueryFilters)
        {
            query = query.IgnoreQueryFilters();
        }

        return trackingChanges ?
            query.AsTracking() :
            query.AsNoTrackingWithIdentityResolution();
    }
    public void Insert<T>(T entity) where T : BaseEntity
    {
        Set<T>().Add(entity);
    }

    public Task SaveAsync() => SaveChangesAsync();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity.GetType().IsSubclassOf(typeof(BaseEntity))).ToList();

        foreach (var entry in entries.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            var entity = entry.Entity as BaseEntity;
            if (entry.State == EntityState.Added)
            {
                entity.CreatedDate = DateTime.UtcNow;
                entity.LastModifiedDate = null;
            }
            if (entry.State == EntityState.Modified)
            {
                entity.LastModifiedDate = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}