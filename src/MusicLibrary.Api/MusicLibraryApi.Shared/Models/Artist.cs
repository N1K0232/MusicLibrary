using MusicLibraryApi.Shared.Models.Common;

namespace MusicLibraryApi.Shared.Models;

public class Artist : BaseObject
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public string ArtName { get; set; }

    public RecordLabel RecordLabel { get; set; }
}