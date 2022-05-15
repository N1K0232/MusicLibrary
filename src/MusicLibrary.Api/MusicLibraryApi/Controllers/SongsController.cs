using Microsoft.AspNetCore.Mvc;
using MusicLibraryApi.BusinessLayer.Services;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SongsController : ControllerBase
{
    private readonly ISongService songService;

    public SongsController(ISongService songService)
    {
        this.songService = songService;
    }

    [HttpDelete("DeleteArtist")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public async Task<IActionResult> DeleteSong(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid song");
        }

        await songService.DeleteAsync(id);
        return Ok("song successfully deleted");
    }

    [HttpGet("GetSong")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Song))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetSong(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            return BadRequest("not valid song");
        }

        var song = await songService.GetAsync(title);
        return song != null ? Ok(song) : NotFound("no song found");
    }

    [HttpPost("SaveSong")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Song))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IActionResult> SaveSong([FromBody] SaveSongRequest request)
    {
        var savedArtist = await songService.SaveAsync(request);
        return Ok(savedArtist);
    }
}