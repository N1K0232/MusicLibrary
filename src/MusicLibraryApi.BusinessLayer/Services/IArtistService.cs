using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.BusinessLayer.Services;

public interface IArtistService
{
    Task DeleteAsync(Guid id);
    Task<Artist> GetAsync(string artName);
    Task<Artist> GetAsync(Guid id);
    Task<Artist> SaveAsync(SaveArtistRequest request);
}