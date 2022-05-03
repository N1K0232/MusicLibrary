using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.BusinessLayer.Services;

public interface ISongService
{
    Task DeleteAsync(Guid id);
    Task<Song> GetAsync(string title);
    Task<Song> SaveAsync(SaveSongRequest request);
}