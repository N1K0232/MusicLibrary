using MusicLibraryApi.Shared.Models.Common;

namespace MusicLibraryApi.Shared.Models;

public class Album : BaseObject
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Artist Artist { get; set; }
}