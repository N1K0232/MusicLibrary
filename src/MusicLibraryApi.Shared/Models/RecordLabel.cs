using MusicLibraryApi.Shared.Models.Common;

namespace MusicLibraryApi.Shared.Models;

public class RecordLabel : BaseObject
{
    public string Name { get; set; }

    public DateTime FoundationDate { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
}