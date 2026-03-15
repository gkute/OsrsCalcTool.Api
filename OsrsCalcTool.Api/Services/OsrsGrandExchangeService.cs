using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace OsrsCalcTool.Api.Services;

public class OsrsGrandExchangeService
{
    private readonly HttpClient _httpClient;
    private Dictionary<int, ItemPrice>? _priceCache;
    private DateTime _lastFetch = DateTime.MinValue;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);

    public OsrsGrandExchangeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://prices.runescape.wiki/api/v1/osrs/");
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("OsrsCalcTool.Api/1.0 (Web API)");
    }

    public async Task<int?> GetPriceAsync(int? itemId, CancellationToken cancellationToken = default)
    {
        if (itemId is null) return null;
        var prices = await FetchPricesAsync(cancellationToken);
        return prices.TryGetValue(itemId.Value, out var price)
            ? price.High ?? price.Low
            : null;
    }

    public async Task<Dictionary<int, int>> GetAllPricesAsync(CancellationToken cancellationToken = default)
    {
        var prices = await FetchPricesAsync(cancellationToken);
        return prices
            .Select(kvp => (kvp.Key, Value: kvp.Value.High ?? kvp.Value.Low))
            .Where(x => x.Value.HasValue)
            .ToDictionary(x => x.Key, x => x.Value!.Value);
    }

    public async Task<Dictionary<int, int>> GetPricesAsync(IEnumerable<int> itemIds, CancellationToken cancellationToken = default)
    {
        var prices = await FetchPricesAsync(cancellationToken);
        var result = new Dictionary<int, int>();

        foreach (var id in itemIds)
        {
            if (prices.TryGetValue(id, out var price))
            {
                var value = price.High ?? price.Low;
                if (value.HasValue)
                    result[id] = value.Value;
            }
        }

        return result;
    }

    private async Task<Dictionary<int, ItemPrice>> FetchPricesAsync(CancellationToken cancellationToken)
    {
        if (_priceCache is not null && DateTime.UtcNow - _lastFetch < CacheDuration)
            return _priceCache;

        var response = await _httpClient.GetFromJsonAsync<PriceResponse>("latest", cancellationToken);
        _priceCache = response?.Data ?? [];
        _lastFetch = DateTime.UtcNow;
        return _priceCache;
    }

    private sealed class PriceResponse
    {
        [JsonPropertyName("data")]
        public Dictionary<int, ItemPrice> Data { get; set; } = [];
    }
}

public class ItemPrice
{
    [JsonPropertyName("high")]
    public int? High { get; set; }

    [JsonPropertyName("highTime")]
    public long? HighTime { get; set; }

    [JsonPropertyName("low")]
    public int? Low { get; set; }

    [JsonPropertyName("lowTime")]
    public long? LowTime { get; set; }
}
