using Microsoft.AspNetCore.Mvc;
using MusicLibraryApi.BusinessLayer.Services;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AlbumsController : ControllerBase
{
    private readonly IAlbumService albumService;

    public AlbumsController(IAlbumService albumService)
    {
        this.albumService = albumService;
    }

    [HttpDelete("DeleteAlbum")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAlbum(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid album");
        }

        await albumService.DeleteAsync(id);
        return Ok("album sucessfully deleted");
    }

    [HttpGet("GetAlbum/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Artist))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetArtist(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid album");
        }

        var album = await albumService.GetAsync(id);
        return album != null ? Ok(album) : NotFound("no album found");
    }

    [HttpGet("GetAlbum/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Artist))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetArtist(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("not valid album");
        }

        var album = await albumService.GetAsync(name);
        return album != null ? Ok(album) : NotFound("no album found");
    }

    [HttpPost("SaveAlbum")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Album))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SaveAlbum([FromBody] SaveAlbumRequest request)
    {
        var savedAlbum = await albumService.SaveAsync(request);
        return Ok(savedAlbum);
    }
}