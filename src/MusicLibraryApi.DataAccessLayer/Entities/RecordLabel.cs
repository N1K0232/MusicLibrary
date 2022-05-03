using MusicLibraryApi.DataAccessLayer.Entities.Common;

namespace MusicLibraryApi.DataAccessLayer.Entities;

public class RecordLabel : BaseEntity
{
    public string Name { get; set; }

    public DateTime FoundationDate { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public List<Artist> Artists { get; set; }

    public List<Song> Songs { get; set; }
}