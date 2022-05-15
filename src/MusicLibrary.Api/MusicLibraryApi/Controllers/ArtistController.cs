using Microsoft.AspNetCore.Mvc;
using MusicLibraryApi.BusinessLayer.Services;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ArtistController : ControllerBase
{
    private readonly IArtistService artistService;

    public ArtistController(IArtistService artistService)
    {
        this.artistService = artistService;
    }

    [HttpDelete("DeleteArtist")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public async Task<IActionResult> DeleteArtist(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid artist");
        }

        await artistService.DeleteAsync(id);
        return Ok("artist successfully deleted");
    }

    [HttpGet("GetArtist/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Artist))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetArtist(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid artist");
        }

        var artist = await artistService.GetAsync(id);
        return artist != null ? Ok(artist) : NotFound("no artist found");
    }

    [HttpGet("GetArtist/{artName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Artist))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetArtist(string artName)
    {
        if (string.IsNullOrEmpty(artName))
        {
            return BadRequest("not valid artist");
        }

        var artist = await artistService.GetAsync(artName);
        return artist != null ? Ok(artist) : NotFound("no artist found");
    }

    [HttpPost("SaveArtist")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Artist))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IActionResult> SaveArtist([FromBody] SaveArtistRequest request)
    {
        var savedArtist = await artistService.SaveAsync(request);
        return Ok(savedArtist);
    }
}