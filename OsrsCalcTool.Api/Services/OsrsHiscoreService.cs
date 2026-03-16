namespace OsrsCalcTool.Api.Services;

using OsrsCalcTool.Api.Models;

public class OsrsHiscoreService
{
    private static readonly string[] SkillNames =
    [
        "Overall", "Attack", "Defence", "Strength", "Hitpoints",
        "Ranged", "Prayer", "Magic", "Cooking", "Woodcutting",
        "Fletching", "Fishing", "Firemaking", "Crafting", "Smithing",
        "Mining", "Herblore", "Agility", "Thieving", "Slayer",
        "Farming", "Runecrafting", "Hunter", "Construction", "Sailing"
    ];

    private readonly HttpClient _httpClient;
    private readonly ILogger<OsrsHiscoreService> _logger;

    public OsrsHiscoreService(HttpClient httpClient, ILogger<OsrsHiscoreService> logger)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("OsrsCalcTool.Api/1.0 (Web API)");
        _logger = logger;
    }

    public async Task<List<HiscoreEntry>> GetHiscoresAsync(string playerName, CancellationToken cancellationToken = default)
    {
        var url = $"https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player={Uri.EscapeDataString(playerName)}";

        HttpResponseMessage response;
        try
        {
            response = await _httpClient.GetAsync(url, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error calling OSRS hiscores for player {PlayerName}", playerName);
            throw;
        }

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning("OSRS hiscores returned {StatusCode} for player {PlayerName}", response.StatusCode, playerName);
            return [];
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        var entries = new List<HiscoreEntry>();
        var lines = body.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        for (var i = 0; i < lines.Length && i < SkillNames.Length; i++)
        {
            var parts = lines[i].Split(',');
            if (parts.Length >= 3 &&
                int.TryParse(parts[0], out var rank) &&
                int.TryParse(parts[1], out var level) &&
                long.TryParse(parts[2], out var experience))
            {
                entries.Add(new HiscoreEntry
                {
                    SkillName = SkillNames[i],
                    Rank = rank,
                    Level = level,
                    Experience = experience
                });
            }
        }

        return entries;
    }
}
