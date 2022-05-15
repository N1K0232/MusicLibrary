using Microsoft.AspNetCore.Mvc;
using MusicLibraryApi.BusinessLayer.Services;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class RecordLabelsController : ControllerBase
{
    private readonly IRecordLabelService recordLabelService;

    public RecordLabelsController(IRecordLabelService recordLabelService)
    {
        this.recordLabelService = recordLabelService;
    }

    [HttpDelete("DeleteLabel")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public async Task<IActionResult> DeleteLabel(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid label");
        }

        await recordLabelService.DeleteAsync(id);
        return Ok("label successfully deleted");
    }

    [HttpGet("GetLabel/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecordLabel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetLabel(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid label");
        }

        var label = await recordLabelService.GetAsync(id);
        return label != null ? Ok(label) : NotFound("no label found");
    }

    [HttpGet("GetLabel/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecordLabel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetLabel(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("not valid label");
        }

        var label = await recordLabelService.GetAsync(name);
        return label != null ? Ok(label) : NotFound("no label found");
    }

    [HttpPost("SaveLabel")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecordLabel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IActionResult> SaveLabel([FromBody] SaveRecordLabelRequest request)
    {
        var savedLabel = await recordLabelService.SaveAsync(request);
        return Ok(savedLabel);
    }
}