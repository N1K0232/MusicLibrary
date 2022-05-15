using MusicLibraryApi.Shared.Models.Common;

namespace MusicLibraryApi.Shared.Models.Requests;

public class SaveArtistRequest : BaseRequestObject
{
    public Guid IdLabel { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string ArtName { get; set; }
}