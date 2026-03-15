using Microsoft.AspNetCore.Mvc;
using OsrsCalcTool.Api.Models;
using OsrsCalcTool.Api.Services;

namespace OsrsCalcTool.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController(OsrsHiscoreService hiscoreService) : ControllerBase
{
    [HttpGet("{playerName}")]
    [ProducesResponseType<List<HiscoreEntry>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPlayer(string playerName, CancellationToken cancellationToken)
    {
        try
        {
            var entries = await hiscoreService.GetHiscoresAsync(playerName, cancellationToken);
            if (entries.Count == 0)
                return NotFound($"Player '{playerName}' not found.");
            return Ok(entries);
        }
        catch (HttpRequestException)
        {
            return NotFound($"Player '{playerName}' not found.");
        }
    }
}
