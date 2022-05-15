using MusicLibraryApi.DataAccessLayer.Entities.Common;

namespace MusicLibraryApi.DataAccessLayer.Entities;

public class Album : BaseEntity
{
    public Guid IdArtist { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Artist Artist { get; set; }
}