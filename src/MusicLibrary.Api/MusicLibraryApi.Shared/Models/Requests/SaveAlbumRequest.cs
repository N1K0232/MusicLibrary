using MusicLibraryApi.Shared.Models.Common;

namespace MusicLibraryApi.Shared.Models.Requests;

public class SaveAlbumRequest : BaseRequestObject
{
    public Guid IdArtist { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
}