using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;

namespace OsrsCalcTool.Api.Services;

public class SkillIconService
{
    private readonly HttpClient _httpClient;
    private readonly string _cacheDir;
    private static readonly ConcurrentDictionary<string, string?> _memoryCache = new();
    private static bool _cacheDirCreated;

    private static readonly Dictionary<string, string> SkillIconMap = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Overall"] = "Stats_icon.png",
        ["Attack"] = "Attack_icon.png",
        ["Defence"] = "Defence_icon.png",
        ["Strength"] = "Strength_icon.png",
        ["Hitpoints"] = "Hitpoints_icon.png",
        ["Ranged"] = "Ranged_icon.png",
        ["Prayer"] = "Prayer_icon.png",
        ["Magic"] = "Magic_icon.png",
        ["Cooking"] = "Cooking_icon.png",
        ["Woodcutting"] = "Woodcutting_icon.png",
        ["Fletching"] = "Fletching_icon.png",
        ["Fishing"] = "Fishing_icon.png",
        ["Firemaking"] = "Firemaking_icon.png",
        ["Crafting"] = "Crafting_icon.png",
        ["Smithing"] = "Smithing_icon.png",
        ["Mining"] = "Mining_icon.png",
        ["Herblore"] = "Herblore_icon.png",
        ["Agility"] = "Agility_icon.png",
        ["Thieving"] = "Thieving_icon.png",
        ["Slayer"] = "Slayer_icon.png",
        ["Farming"] = "Farming_icon.png",
        ["Runecrafting"] = "Runecraft_icon.png",
        ["Hunter"] = "Hunter_icon.png",
        ["Construction"] = "Construction_icon.png",
        ["Sailing"] = "Sailing_icon.png",
    };

    public SkillIconService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("OsrsCalcTool.Api/1.0 (Web API)");
        var basePath = config["CachePath"];
        _cacheDir = string.IsNullOrWhiteSpace(basePath)
            ? Path.Combine(AppContext.BaseDirectory, "cache", "skill-icons")
            : Path.Combine(basePath, "skill-icons");
        if (!_cacheDirCreated)
        {
            Directory.CreateDirectory(_cacheDir);
            _cacheDirCreated = true;
        }
    }

    /// <summary>
    /// Returns a base64 data URI for the given skill icon, or null if not yet loaded.
    /// </summary>
    public string? GetIconUri(string skillName)
    {
        return _memoryCache.TryGetValue(skillName, out var uri) ? uri : null;
    }

    /// <summary>
    /// Returns a base64 data URI for the given skill icon, fetching if not already cached.
    /// </summary>
    public async Task<string?> GetOrFetchIconUriAsync(string skillName, CancellationToken ct = default)
    {
        if (_memoryCache.TryGetValue(skillName, out var uri)) return uri;
        await LoadAsync(skillName, ct);
        return _memoryCache.TryGetValue(skillName, out uri) ? uri : null;
    }

    /// <summary>
    /// Downloads and caches skill icons from the OSRS wiki.
    /// </summary>
    public async Task PreloadAsync(IEnumerable<string> skillNames, CancellationToken ct = default)
    {
        var toLoad = skillNames.Where(s => !_memoryCache.ContainsKey(s)).Distinct().ToList();
        if (toLoad.Count == 0) return;

        using var semaphore = new SemaphoreSlim(4);
        await Task.WhenAll(toLoad.Select(async name =>
        {
            await semaphore.WaitAsync(ct);
            try { await LoadAsync(name, ct); }
            finally { semaphore.Release(); }
        }));
    }

    private async Task LoadAsync(string skillName, CancellationToken ct)
    {
        if (_memoryCache.ContainsKey(skillName)) return;

        if (!SkillIconMap.TryGetValue(skillName, out var fileName))
        {
            _memoryCache[skillName] = null;
            return;
        }

        var filePath = Path.Combine(_cacheDir, fileName);

        if (File.Exists(filePath))
        {
            var bytes = await File.ReadAllBytesAsync(filePath, ct);
            _memoryCache[skillName] = ToDataUri(bytes);
            return;
        }

        try
        {
            var url = $"https://oldschool.runescape.wiki/images/{fileName}";
            var bytes = await _httpClient.GetByteArrayAsync(url, ct);
            await File.WriteAllBytesAsync(filePath, bytes, ct);
            _memoryCache[skillName] = ToDataUri(bytes);
        }
        catch
        {
            _memoryCache[skillName] = null;
        }
    }

    private static string ToDataUri(byte[] bytes) =>
        $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
}
