using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.BusinessLayer.Services;

public interface IRecordLabelService
{
    Task DeleteAsync(Guid id);
    Task<RecordLabel> GetAsync(string name);
    Task<RecordLabel> GetAsync(Guid id);
    Task<RecordLabel> SaveAsync(SaveRecordLabelRequest request);
}