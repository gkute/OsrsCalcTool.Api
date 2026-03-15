namespace OsrsCalcTool.Api.Models;

public class MiningAction
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

public static class MiningData
{
    public static IReadOnlyList<MiningAction> Actions { get; } =
    [
        // Standard Ores — IDs verified via OSRS wiki + GE mapping API
        new() { Name = "Clay", Category = "Ore", LevelRequired = 1, Experience = 5, ItemId = 434 },
        new() { Name = "Copper ore", Category = "Ore", LevelRequired = 1, Experience = 17.5, ItemId = 436 },
        new() { Name = "Tin ore", Category = "Ore", LevelRequired = 1, Experience = 17.5, ItemId = 438 },
        new() { Name = "Blurite ore", Category = "Ore", LevelRequired = 10, Experience = 17.5, ItemId = 668, Notes = "The Knight's Sword quest area; untradeable" },
        new() { Name = "Iron ore", Category = "Ore", LevelRequired = 15, Experience = 35, ItemId = 440 },
        new() { Name = "Silver ore", Category = "Ore", LevelRequired = 20, Experience = 40, ItemId = 442 },
        new() { Name = "Lead ore", Category = "Ore", LevelRequired = 25, Experience = 40.5, Members = true, ItemId = 31716, Notes = "Perilous Moons quest", QuestRequirement = "Perilous Moons" },
        new() { Name = "Coal", Category = "Ore", LevelRequired = 30, Experience = 50, ItemId = 453 },
        new() { Name = "Gold ore", Category = "Ore", LevelRequired = 40, Experience = 65, ItemId = 444 },
        new() { Name = "Mithril ore", Category = "Ore", LevelRequired = 55, Experience = 80, ItemId = 447 },
        new() { Name = "Lovakite ore", Category = "Ore", LevelRequired = 65, Experience = 60, Members = true, ItemId = 13356, Notes = "Lovakengj; untradeable" },
        new() { Name = "Adamantite ore", Category = "Ore", LevelRequired = 70, Experience = 95, ItemId = 449 },
        new() { Name = "Nickel ore", Category = "Ore", LevelRequired = 74, Experience = 80.5, Members = true, ItemId = 31719, Notes = "Perilous Moons quest", QuestRequirement = "Perilous Moons" },
        new() { Name = "Runite ore", Category = "Ore", LevelRequired = 85, Experience = 125, ItemId = 451 },
        new() { Name = "Amethyst", Category = "Ore", LevelRequired = 92, Experience = 240, Members = true, ItemId = 21347, Notes = "Mining Guild only" },

        // Essence
        new() { Name = "Rune essence", Category = "Essence", LevelRequired = 1, Experience = 5, ItemId = 1436 },
        new() { Name = "Daeyalt ore", Category = "Essence", LevelRequired = 20, Experience = 17.5, Members = true, ItemId = 9632, Notes = "Meiyerditch mine; untradeable" },
        new() { Name = "Pure essence", Category = "Essence", LevelRequired = 30, Experience = 5, Members = true, ItemId = 7936 },
        new() { Name = "Dense essence block", Category = "Essence", LevelRequired = 38, Experience = 12, Members = true, ItemId = 13445, Notes = "Arceuus; blood/soul runes; untradeable" },
        new() { Name = "Daeyalt shard", Category = "Essence", LevelRequired = 60, Experience = 5, Members = true, ItemId = 24706, Notes = "Darkmeyer; untradeable" },
        new() { Name = "Ancient essence", Category = "Essence", LevelRequired = 75, Experience = 13.5, Members = true, ItemId = 27616, Notes = "Arceuus" },

        // Gems
        new() { Name = "Gem rocks", Category = "Gem", LevelRequired = 40, Experience = 65, Members = true, ItemId = 11381, Notes = "Drops various uncut gems" },

        // Sandstone & Granite
        new() { Name = "Sandstone (1kg)", Category = "Sandstone & Granite", LevelRequired = 35, Experience = 30, Members = true, ItemId = 6971 },
        new() { Name = "Sandstone (2kg)", Category = "Sandstone & Granite", LevelRequired = 35, Experience = 40, Members = true, ItemId = 6973 },
        new() { Name = "Sandstone (5kg)", Category = "Sandstone & Granite", LevelRequired = 35, Experience = 50, Members = true, ItemId = 6975 },
        new() { Name = "Sandstone (10kg)", Category = "Sandstone & Granite", LevelRequired = 35, Experience = 60, Members = true, ItemId = 6977 },
        new() { Name = "Granite (500g)", Category = "Sandstone & Granite", LevelRequired = 45, Experience = 50, Members = true, ItemId = 6979, Notes = "Popular for 3-tick mining" },
        new() { Name = "Granite (2kg)", Category = "Sandstone & Granite", LevelRequired = 45, Experience = 60, Members = true, ItemId = 6981 },
        new() { Name = "Granite (5kg)", Category = "Sandstone & Granite", LevelRequired = 45, Experience = 75, Members = true, ItemId = 6983 },

        // Special & Minigames
        new() { Name = "Limestone", Category = "Special", LevelRequired = 10, Experience = 26.5, Members = true, ItemId = 3211 },
        new() { Name = "Stardust (Shooting Stars)", Category = "Special", LevelRequired = 10, Experience = 32, ItemId = 25527, Notes = "D&D; star tiers require lvl 10–90; untradeable" },
        new() { Name = "Barronite shards", Category = "Special", LevelRequired = 14, Experience = 16, ItemId = 25676, Notes = "Ruins of Camdozaal; untradeable" },
        new() { Name = "Volcanic ash", Category = "Special", LevelRequired = 22, Experience = 10, Members = true, ItemId = 21622 },
        new() { Name = "Pay-dirt (Motherlode Mine)", Category = "Special", LevelRequired = 30, Experience = 60, Members = true, ItemId = 12011, Notes = "Random ores from hopper; untradeable" },
        new() { Name = "Calcified rocks", Category = "Special", LevelRequired = 41, Experience = 33, Members = true, ItemId = 29088, Notes = "Cam Torum Mine; untradeable" },
        new() { Name = "Volcanic sulphur", Category = "Special", LevelRequired = 42, Experience = 25, Members = true, ItemId = 13571, Notes = "Untradeable" },
        new() { Name = "Blasted ore (Blast Mine)", Category = "Special", LevelRequired = 43, Experience = 20, Members = true, ItemId = 13575, Notes = "Lovakengj; uses dynamite; untradeable" },
        new() { Name = "Lunar ore", Category = "Special", LevelRequired = 60, Experience = 0, Members = true, ItemId = 9076, Notes = "Lunar Diplomacy quest; no XP; untradeable", QuestRequirement = "Lunar Diplomacy" },
        new() { Name = "Soft clay", Category = "Special", LevelRequired = 70, Experience = 5, Members = true, ItemId = 1761, Notes = "Requires bracelet of clay" },
        new() { Name = "Salts", Category = "Special", LevelRequired = 72, Experience = 5, Members = true, ItemId = 22593, Notes = "Weiss; untradeable" },
        new() { Name = "Infernal shale", Category = "Special", LevelRequired = 78, Experience = 56.5, Members = true, ItemId = 30846, Notes = "Avg XP; 10–103 range; untradeable" },
    ];

    public static IReadOnlyList<string> Quests { get; } =
        Actions.Where(a => a.QuestRequirement != null)
               .Select(a => a.QuestRequirement!)
               .Distinct()
               .Order()
               .ToList();

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();
}
