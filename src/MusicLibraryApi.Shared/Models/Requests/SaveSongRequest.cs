using MusicLibraryApi.Shared.Models.Common;
using MusicLibraryApi.Shared.Models.Enums;

namespace MusicLibraryApi.Shared.Models.Requests;

public class SaveSongRequest : BaseRequestObject
{
    public Guid IdArtist { get; set; }
    public Guid IdLabel { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public SongType SongType { get; set; }
}