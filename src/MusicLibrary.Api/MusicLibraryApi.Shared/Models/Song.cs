using MusicLibraryApi.Shared.Models.Common;
using MusicLibraryApi.Shared.Models.Enums;

namespace MusicLibraryApi.Shared.Models;

public class Song : BaseObject
{
    public string Title { get; set; }

    public DateTime ReleaseDate { get; set; }

    public SongType SongType { get; set; }

    public Artist Artist { get; set; }

    public RecordLabel RecordLabel { get; set; }
}