using MusicLibraryApi.DataAccessLayer.Entities.Common;
using MusicLibraryApi.Shared.Models.Enums;

namespace MusicLibraryApi.DataAccessLayer.Entities;

public class Song : BaseEntity
{
    public Guid IdArtist { get; set; }

    public Guid IdLabel { get; set; }

    public string Title { get; set; }

    public DateTime ReleaseDate { get; set; }

    public SongType SongType { get; set; }

    public Artist Artist { get; set; }

    public RecordLabel RecordLabel { get; set; }
}