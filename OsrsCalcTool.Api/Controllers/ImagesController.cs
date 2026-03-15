using Microsoft.AspNetCore.Mvc;
using OsrsCalcTool.Api.Services;

namespace OsrsCalcTool.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController(ItemImageService itemImageService, SkillIconService skillIconService) : ControllerBase
{
    [HttpGet("item/{itemId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetItemImage(int itemId, CancellationToken cancellationToken)
    {
        var uri = await itemImageService.GetOrFetchImageUriAsync(itemId, cancellationToken);
        if (uri is null)
            return NotFound($"Image not found for item {itemId}.");
        return Ok(new { dataUri = uri });
    }

    [HttpGet("skill/{skillName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSkillIcon(string skillName, CancellationToken cancellationToken)
    {
        var uri = await skillIconService.GetOrFetchIconUriAsync(skillName, cancellationToken);
        if (uri is null)
            return NotFound($"Icon not found for skill '{skillName}'.");
        return Ok(new { dataUri = uri });
    }
}
