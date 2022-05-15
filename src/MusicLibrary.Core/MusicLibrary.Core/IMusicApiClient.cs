using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibrary.Core;

public interface IMusicApiClient : IDisposable
{
    Task<Album> SaveAlbumRequest(SaveAlbumRequest request);
    Task<Artist> SaveArtistAsync(SaveArtistRequest request);
    Task<RecordLabel> SaveRecordLabelAsync(SaveRecordLabelRequest request);
    Task<Song> SaveSongAsync(SaveSongRequest request);
}