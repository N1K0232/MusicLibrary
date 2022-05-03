using MusicLibraryApi.Shared.Models.Common;

namespace MusicLibraryApi.Shared.Models.Requests;

public class SaveRecordLabelRequest : BaseRequestObject
{
    public string Name { get; set; }
    public DateTime FoundationDate { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}