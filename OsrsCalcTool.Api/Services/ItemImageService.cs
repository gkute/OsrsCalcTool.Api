using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;

namespace OsrsCalcTool.Api.Services;

public class ItemImageService
{
    private readonly HttpClient _httpClient;
    private readonly string _cacheDir;
    private static readonly ConcurrentDictionary<int, string?> _memoryCache = new();
    private static bool _cacheDirCreated;

    public ItemImageService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("OsrsCalcTool.Api/1.0 (Web API)");
        var basePath = config["CachePath"];
        _cacheDir = string.IsNullOrWhiteSpace(basePath)
            ? Path.Combine(AppContext.BaseDirectory, "cache", "item-images")
            : Path.Combine(basePath, "item-images");
        if (!_cacheDirCreated)
        {
            Directory.CreateDirectory(_cacheDir);
            _cacheDirCreated = true;
        }
    }

    /// <summary>
    /// Returns a base64 data URI for the given item, or null if not yet loaded.
    /// </summary>
    public string? GetImageUri(int itemId)
    {
        return _memoryCache.TryGetValue(itemId, out var uri) ? uri : null;
    }

    /// <summary>
    /// Downloads and caches images for the given item IDs.
    /// Images are persisted to disk so subsequent API restarts don't need the network.
    /// </summary>
    public async Task PreloadAsync(IEnumerable<int> itemIds, CancellationToken ct = default)
    {
        var toLoad = itemIds.Where(id => !_memoryCache.ContainsKey(id)).Distinct().ToList();
        if (toLoad.Count == 0) return;

        using var semaphore = new SemaphoreSlim(4);
        await Task.WhenAll(toLoad.Select(async id =>
        {
            await semaphore.WaitAsync(ct);
            try { await LoadAsync(id, ct); }
            finally { semaphore.Release(); }
        }));
    }

    /// <summary>
    /// Returns a base64 data URI for the given item, fetching if not already cached.
    /// </summary>
    public async Task<string?> GetOrFetchImageUriAsync(int itemId, CancellationToken ct = default)
    {
        if (_memoryCache.TryGetValue(itemId, out var uri)) return uri;
        await LoadAsync(itemId, ct);
        return _memoryCache.TryGetValue(itemId, out uri) ? uri : null;
    }

    private async Task LoadAsync(int itemId, CancellationToken ct)
    {
        if (_memoryCache.ContainsKey(itemId)) return;

        var filePath = Path.Combine(_cacheDir, $"{itemId}.gif");

        if (File.Exists(filePath))
        {
            var bytes = await File.ReadAllBytesAsync(filePath, ct);
            _memoryCache[itemId] = ToDataUri(bytes);
            return;
        }

        try
        {
            var url = $"https://secure.runescape.com/m=itemdb_oldschool/obj_sprite.gif?id={itemId}";
            var bytes = await _httpClient.GetByteArrayAsync(url, ct);
            await File.WriteAllBytesAsync(filePath, bytes, ct);
            _memoryCache[itemId] = ToDataUri(bytes);
        }
        catch
        {
            _memoryCache[itemId] = null;
        }
    }

    private static string ToDataUri(byte[] bytes) =>
        $"data:image/gif;base64,{Convert.ToBase64String(bytes)}";
}
