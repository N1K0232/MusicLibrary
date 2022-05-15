using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibrary.Core;

public class MusicApiClient : IMusicApiClient
{
    private readonly HttpClient httpClient;

    public MusicApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task<Album> SaveAlbumRequest(SaveAlbumRequest request)
    {
        return Task.FromResult(new Album());
    }
    public Task<Artist> SaveArtistAsync(SaveArtistRequest request)
    {
        return Task.FromResult(new Artist());
    }
    public Task<RecordLabel> SaveRecordLabelAsync(SaveRecordLabelRequest request)
    {
        return Task.FromResult(new RecordLabel());
    }
    public Task<Song> SaveSongAsync(SaveSongRequest request)
    {
        return Task.FromResult(new Song());
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            httpClient.Dispose();
        }
    }
}