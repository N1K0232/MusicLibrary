using MusicLibraryApi.DataAccessLayer.Entities.Common;

namespace MusicLibraryApi.DataAccessLayer.Entities;

public class Artist : BaseEntity
{
    public Guid IdLabel { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public string ArtName { get; set; }

    public RecordLabel RecordLabel { get; set; }

    public List<Song> Songs { get; set; }
}