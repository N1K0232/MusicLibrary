using MusicLibraryApi.DataAccessLayer.Entities.Common;

namespace MusicLibraryApi.DataAccessLayer;

public interface IDataContext
{
    void Delete<T>(T entity) where T : BaseEntity;
    IQueryable<T> GetQuery<T>(bool ignoreQueryFilters = false, bool trackingChanges = false) where T : BaseEntity;
    ValueTask<T> GetAsync<T>(params object[] keyValues) where T : BaseEntity;
    void Insert<T>(T entity) where T : BaseEntity;
    Task SaveAsync();
}