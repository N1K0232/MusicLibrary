using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.BusinessLayer.Services;

public interface IAlbumService
{
    Task DeleteAsync(Guid id);
    Task<Album> GetAsync(string name);
    Task<Album> GetAsync(Guid id);
    Task<Album> SaveAsync(SaveAlbumRequest request);
}