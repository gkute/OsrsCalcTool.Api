using Microsoft.AspNetCore.Mvc;
using OsrsCalcTool.Api.Services;

namespace OsrsCalcTool.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PricesController(OsrsGrandExchangeService geService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<Dictionary<int, int>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPrices(CancellationToken cancellationToken)
    {
        var prices = await geService.GetAllPricesAsync(cancellationToken);
        return Ok(prices);
    }

    [HttpGet("{itemId:int}")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPrice(int itemId, CancellationToken cancellationToken)
    {
        var price = await geService.GetPriceAsync(itemId, cancellationToken);
        if (price is null)
            return NotFound($"Price not found for item {itemId}.");
        return Ok(price);
    }

    [HttpPost("batch")]
    [ProducesResponseType<Dictionary<int, int>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPricesBatch([FromBody] int[] itemIds, CancellationToken cancellationToken)
    {
        var prices = await geService.GetPricesAsync(itemIds, cancellationToken);
        return Ok(prices);
    }
}
