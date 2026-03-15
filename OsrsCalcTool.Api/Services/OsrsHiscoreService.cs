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

    public OsrsHiscoreService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<HiscoreEntry>> GetHiscoresAsync(string playerName, CancellationToken cancellationToken = default)
    {
        var url = $"https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player={Uri.EscapeDataString(playerName)}";
        var response = await _httpClient.GetStringAsync(url, cancellationToken);

        var entries = new List<HiscoreEntry>();
        var lines = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);

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
