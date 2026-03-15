namespace OsrsCalcTool.Api.Models;

public class HunterAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }
    public string? QuestRequirement { get; init; }
}

public static class HunterData
{
    public static IReadOnlyList<string> Quests { get; } =
    [
        "Eagles' Peak",
        "Song of the Elves",
        "Bone Voyage",
    ];

    public static IReadOnlyList<HunterAction> Actions { get; } =
    [
        // ── Bird snares ─────────────────────────────────────────────────
        new() { Name = "Crimson swift", Category = "Bird Snare", LevelRequired = 1, Experience = 34, Members = true, ItemId = 10088 },
        new() { Name = "Golden warbler", Category = "Bird Snare", LevelRequired = 5, Experience = 47, Members = true, ItemId = 10090 },
        new() { Name = "Copper longtail", Category = "Bird Snare", LevelRequired = 9, Experience = 61, Members = true, ItemId = 10091 },
        new() { Name = "Cerulean twitch", Category = "Bird Snare", LevelRequired = 11, Experience = 64.5, Members = true, ItemId = 10089 },
        new() { Name = "Tropical wagtail", Category = "Bird Snare", LevelRequired = 19, Experience = 95, Members = true, ItemId = 10092 },

        // ── Butterfly nets ──────────────────────────────────────────────
        new() { Name = "Ruby harvest", Category = "Butterfly", LevelRequired = 15, Experience = 24, Members = true, ItemId = 10020 },
        new() { Name = "Sapphire glacialis", Category = "Butterfly", LevelRequired = 25, Experience = 34, Members = true, ItemId = 10018 },
        new() { Name = "Snowy knight", Category = "Butterfly", LevelRequired = 35, Experience = 44, Members = true, ItemId = 10016 },
        new() { Name = "Black warlock", Category = "Butterfly", LevelRequired = 45, Experience = 54, Members = true, ItemId = 10014 },
        new() { Name = "Sunlight moth", Category = "Butterfly", LevelRequired = 65, Experience = 82, Members = true, ItemId = 28899 },
        new() { Name = "Moonlight moth", Category = "Butterfly", LevelRequired = 75, Experience = 97, Members = true, ItemId = 28893 },

        // ── Box traps ───────────────────────────────────────────────────
        new() { Name = "Ferret", Category = "Box Trap", LevelRequired = 27, Experience = 115, Members = true, QuestRequirement = "Eagles' Peak" },
        new() { Name = "Grey chinchompa", Category = "Box Trap", LevelRequired = 53, Experience = 198.4, Members = true, ItemId = 10033, QuestRequirement = "Eagles' Peak" },
        new() { Name = "Red chinchompa", Category = "Box Trap", LevelRequired = 63, Experience = 265, Members = true, ItemId = 10034, QuestRequirement = "Eagles' Peak" },
        new() { Name = "Black chinchompa", Category = "Box Trap", LevelRequired = 73, Experience = 315, Members = true, ItemId = 11959, QuestRequirement = "Eagles' Peak", Notes = "Wilderness only" },
        new() { Name = "Carnivorous chinchompa", Category = "Box Trap", LevelRequired = 80, Experience = 360, Members = true, ItemId = 28952, QuestRequirement = "Eagles' Peak" },

        // ── Deadfall traps ──────────────────────────────────────────────
        new() { Name = "Wild kebbit", Category = "Deadfall", LevelRequired = 23, Experience = 128, Members = true },
        new() { Name = "Barb-tailed kebbit", Category = "Deadfall", LevelRequired = 33, Experience = 168, Members = true },
        new() { Name = "Prickly kebbit", Category = "Deadfall", LevelRequired = 37, Experience = 204, Members = true },
        new() { Name = "Sabre-toothed kebbit", Category = "Deadfall", LevelRequired = 51, Experience = 200, Members = true },
        new() { Name = "Maniacal monkey", Category = "Deadfall", LevelRequired = 60, Experience = 1000, Members = true, Notes = "Crash Site Cavern; requires greegree + bananas" },

        // ── Net traps ───────────────────────────────────────────────────
        new() { Name = "Swamp lizard", Category = "Net Trap", LevelRequired = 29, Experience = 152, Members = true, ItemId = 10149 },
        new() { Name = "Orange salamander", Category = "Net Trap", LevelRequired = 47, Experience = 224, Members = true, ItemId = 10146 },
        new() { Name = "Red salamander", Category = "Net Trap", LevelRequired = 59, Experience = 272, Members = true, ItemId = 10147 },
        new() { Name = "Black salamander", Category = "Net Trap", LevelRequired = 67, Experience = 319.2, Members = true, ItemId = 10148 },
        new() { Name = "Tecu salamander", Category = "Net Trap", LevelRequired = 79, Experience = 344, Members = true, ItemId = 28894 },

        // ── Tracking ────────────────────────────────────────────────────
        new() { Name = "Polar kebbit", Category = "Tracking", LevelRequired = 1, Experience = 30, Members = true },
        new() { Name = "Common kebbit", Category = "Tracking", LevelRequired = 3, Experience = 36, Members = true },
        new() { Name = "Feldip weasel", Category = "Tracking", LevelRequired = 7, Experience = 48, Members = true },
        new() { Name = "Desert devil", Category = "Tracking", LevelRequired = 13, Experience = 66, Members = true },
        new() { Name = "Razor-backed kebbit", Category = "Tracking", LevelRequired = 49, Experience = 348, Members = true },

        // ── Falconry ────────────────────────────────────────────────────
        new() { Name = "Spotted kebbit", Category = "Falconry", LevelRequired = 43, Experience = 104, Members = true },
        new() { Name = "Dark kebbit", Category = "Falconry", LevelRequired = 57, Experience = 132, Members = true },
        new() { Name = "Dashing kebbit", Category = "Falconry", LevelRequired = 69, Experience = 156, Members = true },

        // ── Pitfall traps ───────────────────────────────────────────────
        new() { Name = "Spined larupia", Category = "Pitfall", LevelRequired = 31, Experience = 180, Members = true },
        new() { Name = "Horned graahk", Category = "Pitfall", LevelRequired = 41, Experience = 240, Members = true },
        new() { Name = "Sabre-toothed kyatt", Category = "Pitfall", LevelRequired = 55, Experience = 300, Members = true },

        // ── Implings ────────────────────────────────────────────────────
        new() { Name = "Baby impling", Category = "Impling", LevelRequired = 17, Experience = 18, Members = true, ItemId = 11238 },
        new() { Name = "Young impling", Category = "Impling", LevelRequired = 22, Experience = 20, Members = true, ItemId = 11240 },
        new() { Name = "Gourmet impling", Category = "Impling", LevelRequired = 28, Experience = 22, Members = true, ItemId = 11242 },
        new() { Name = "Earth impling", Category = "Impling", LevelRequired = 36, Experience = 25, Members = true, ItemId = 11244 },
        new() { Name = "Essence impling", Category = "Impling", LevelRequired = 42, Experience = 27, Members = true, ItemId = 11246 },
        new() { Name = "Eclectic impling", Category = "Impling", LevelRequired = 50, Experience = 32, Members = true, ItemId = 11248 },
        new() { Name = "Nature impling", Category = "Impling", LevelRequired = 58, Experience = 34, Members = true, ItemId = 11250 },
        new() { Name = "Magpie impling", Category = "Impling", LevelRequired = 65, Experience = 44, Members = true, ItemId = 11252 },
        new() { Name = "Ninja impling", Category = "Impling", LevelRequired = 74, Experience = 52, Members = true, ItemId = 11254 },
        new() { Name = "Crystal impling", Category = "Impling", LevelRequired = 80, Experience = 280, Members = true, ItemId = 23640, QuestRequirement = "Song of the Elves" },
        new() { Name = "Dragon impling", Category = "Impling", LevelRequired = 83, Experience = 65, Members = true, ItemId = 11256 },
        new() { Name = "Lucky impling", Category = "Impling", LevelRequired = 89, Experience = 380, Members = true, ItemId = 19732 },

        // ── Birdhouse runs ──────────────────────────────────────────────
        new() { Name = "Regular birdhouse", Category = "Birdhouse", LevelRequired = 5, Experience = 280, Members = true, ItemId = 21512, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },
        new() { Name = "Oak birdhouse", Category = "Birdhouse", LevelRequired = 14, Experience = 420, Members = true, ItemId = 21515, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },
        new() { Name = "Willow birdhouse", Category = "Birdhouse", LevelRequired = 24, Experience = 560, Members = true, ItemId = 21518, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },
        new() { Name = "Teak birdhouse", Category = "Birdhouse", LevelRequired = 34, Experience = 700, Members = true, ItemId = 21521, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },
        new() { Name = "Maple birdhouse", Category = "Birdhouse", LevelRequired = 44, Experience = 820, Members = true, ItemId = 21524, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },
        new() { Name = "Mahogany birdhouse", Category = "Birdhouse", LevelRequired = 49, Experience = 960, Members = true, ItemId = 21527, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },
        new() { Name = "Yew birdhouse", Category = "Birdhouse", LevelRequired = 59, Experience = 1020, Members = true, ItemId = 21530, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },
        new() { Name = "Magic birdhouse", Category = "Birdhouse", LevelRequired = 74, Experience = 1140, Members = true, ItemId = 21533, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },
        new() { Name = "Redwood birdhouse", Category = "Birdhouse", LevelRequired = 89, Experience = 1200, Members = true, ItemId = 21536, QuestRequirement = "Bone Voyage", Notes = "Passive; 50 min cycle" },

        // ── Herbiboar ───────────────────────────────────────────────────
        new() { Name = "Herbiboar", Category = "Special", LevelRequired = 80, Experience = 1950, Members = true, Notes = "Fossil Island; also gives Herblore XP" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    public static IEnumerable<int> AllItemIds =>
        Actions.Where(a => a.ItemId.HasValue)
            .Select(a => a.ItemId!.Value)
            .Distinct();
}
