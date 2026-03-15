namespace OsrsCalcTool.Api.Models;

public class MagicAction
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

public static class MagicData
{
    public static IReadOnlyList<string> Quests { get; } =
    [
        "Desert Treasure I",
        "Lunar Diplomacy",
        "Dream Mentor",
    ];

    public static IReadOnlyList<MagicAction> Actions { get; } =
    [
        // ── Standard combat spells ──────────────────────────────────────
        new() { Name = "Wind Strike", Category = "Standard Combat", LevelRequired = 1, Experience = 5.5 },
        new() { Name = "Water Strike", Category = "Standard Combat", LevelRequired = 5, Experience = 7.5 },
        new() { Name = "Earth Strike", Category = "Standard Combat", LevelRequired = 9, Experience = 9.5 },
        new() { Name = "Fire Strike", Category = "Standard Combat", LevelRequired = 13, Experience = 11.5 },
        new() { Name = "Wind Bolt", Category = "Standard Combat", LevelRequired = 17, Experience = 13.5 },
        new() { Name = "Water Bolt", Category = "Standard Combat", LevelRequired = 23, Experience = 16.5 },
        new() { Name = "Earth Bolt", Category = "Standard Combat", LevelRequired = 29, Experience = 19.5 },
        new() { Name = "Fire Bolt", Category = "Standard Combat", LevelRequired = 35, Experience = 22.5 },
        new() { Name = "Wind Blast", Category = "Standard Combat", LevelRequired = 41, Experience = 25.5 },
        new() { Name = "Water Blast", Category = "Standard Combat", LevelRequired = 47, Experience = 28.5 },
        new() { Name = "Earth Blast", Category = "Standard Combat", LevelRequired = 53, Experience = 31.5 },
        new() { Name = "Fire Blast", Category = "Standard Combat", LevelRequired = 59, Experience = 34.5 },
        new() { Name = "Wind Wave", Category = "Standard Combat", LevelRequired = 62, Experience = 36, Members = true },
        new() { Name = "Water Wave", Category = "Standard Combat", LevelRequired = 65, Experience = 37.5, Members = true },
        new() { Name = "Earth Wave", Category = "Standard Combat", LevelRequired = 70, Experience = 40, Members = true },
        new() { Name = "Fire Wave", Category = "Standard Combat", LevelRequired = 75, Experience = 42.5, Members = true },
        new() { Name = "Wind Surge", Category = "Standard Combat", LevelRequired = 81, Experience = 44.5, Members = true },
        new() { Name = "Water Surge", Category = "Standard Combat", LevelRequired = 85, Experience = 46.5, Members = true },
        new() { Name = "Earth Surge", Category = "Standard Combat", LevelRequired = 90, Experience = 48.5, Members = true },
        new() { Name = "Fire Surge", Category = "Standard Combat", LevelRequired = 95, Experience = 50.5, Members = true },

        // ── Enchanting ──────────────────────────────────────────────────
        new() { Name = "Lvl-1 Enchant", Category = "Enchant", LevelRequired = 7, Experience = 17.5, Notes = "Sapphire jewellery" },
        new() { Name = "Lvl-2 Enchant", Category = "Enchant", LevelRequired = 27, Experience = 37, Notes = "Emerald jewellery" },
        new() { Name = "Lvl-3 Enchant", Category = "Enchant", LevelRequired = 49, Experience = 59, Notes = "Ruby jewellery" },
        new() { Name = "Lvl-4 Enchant", Category = "Enchant", LevelRequired = 57, Experience = 67, Members = true, Notes = "Diamond jewellery" },
        new() { Name = "Lvl-5 Enchant", Category = "Enchant", LevelRequired = 68, Experience = 78, Members = true, Notes = "Dragonstone jewellery" },
        new() { Name = "Lvl-6 Enchant", Category = "Enchant", LevelRequired = 87, Experience = 97, Members = true, Notes = "Onyx jewellery" },
        new() { Name = "Lvl-7 Enchant", Category = "Enchant", LevelRequired = 93, Experience = 110, Members = true, Notes = "Zenyte jewellery" },

        // ── Enchant crossbow bolt ───────────────────────────────────────
        new() { Name = "Enchant opal bolts (×10)", Category = "Enchant Bolt", LevelRequired = 4, Experience = 9, ItemId = 9236 },
        new() { Name = "Enchant sapphire bolts (×10)", Category = "Enchant Bolt", LevelRequired = 7, Experience = 17, ItemId = 9240 },
        new() { Name = "Enchant jade bolts (×10)", Category = "Enchant Bolt", LevelRequired = 14, Experience = 19, ItemId = 9237 },
        new() { Name = "Enchant pearl bolts (×10)", Category = "Enchant Bolt", LevelRequired = 24, Experience = 29, ItemId = 9238 },
        new() { Name = "Enchant emerald bolts (×10)", Category = "Enchant Bolt", LevelRequired = 27, Experience = 37, ItemId = 9241 },
        new() { Name = "Enchant red topaz bolts (×10)", Category = "Enchant Bolt", LevelRequired = 29, Experience = 33, ItemId = 9239 },
        new() { Name = "Enchant ruby bolts (×10)", Category = "Enchant Bolt", LevelRequired = 49, Experience = 59, ItemId = 9242 },
        new() { Name = "Enchant diamond bolts (×10)", Category = "Enchant Bolt", LevelRequired = 57, Experience = 67, Members = true, ItemId = 9243 },
        new() { Name = "Enchant dragonstone bolts (×10)", Category = "Enchant Bolt", LevelRequired = 68, Experience = 78, Members = true, ItemId = 9244 },
        new() { Name = "Enchant onyx bolts (×10)", Category = "Enchant Bolt", LevelRequired = 87, Experience = 97, Members = true, ItemId = 9245 },

        // ── Alchemy ─────────────────────────────────────────────────────
        new() { Name = "Low Level Alchemy", Category = "Alchemy", LevelRequired = 21, Experience = 31, Notes = "1 nature rune + 1 fire rune" },
        new() { Name = "High Level Alchemy", Category = "Alchemy", LevelRequired = 55, Experience = 65, Notes = "1 nature rune + 5 fire runes" },

        // ── Teleports ───────────────────────────────────────────────────
        new() { Name = "Varrock Teleport", Category = "Teleport", LevelRequired = 25, Experience = 35 },
        new() { Name = "Lumbridge Teleport", Category = "Teleport", LevelRequired = 31, Experience = 41 },
        new() { Name = "Falador Teleport", Category = "Teleport", LevelRequired = 37, Experience = 48 },
        new() { Name = "Camelot Teleport", Category = "Teleport", LevelRequired = 45, Experience = 55.5, Members = true },
        new() { Name = "Ardougne Teleport", Category = "Teleport", LevelRequired = 51, Experience = 61, Members = true },
        new() { Name = "Watchtower Teleport", Category = "Teleport", LevelRequired = 58, Experience = 68, Members = true },
        new() { Name = "Trollheim Teleport", Category = "Teleport", LevelRequired = 61, Experience = 68, Members = true },
        new() { Name = "Kourend Castle Teleport", Category = "Teleport", LevelRequired = 69, Experience = 82, Members = true },

        // ── Superheat / utility ─────────────────────────────────────────
        new() { Name = "Superheat Item", Category = "Utility", LevelRequired = 43, Experience = 53, Notes = "1 nature rune + 4 fire runes; also gives Smithing XP" },
        new() { Name = "Bones to Bananas", Category = "Utility", LevelRequired = 15, Experience = 25, Notes = "1 nature + 2 earth + 2 water" },
        new() { Name = "Bones to Peaches", Category = "Utility", LevelRequired = 60, Experience = 65, Members = true, Notes = "MTA unlock" },
        new() { Name = "Plank Make", Category = "Utility", LevelRequired = 86, Experience = 90, Members = true, Notes = "Lunar spellbook", QuestRequirement = "Lunar Diplomacy" },
        new() { Name = "Tan Leather", Category = "Utility", LevelRequired = 78, Experience = 81, Members = true, Notes = "Tans 5 hides; Lunar spellbook", QuestRequirement = "Lunar Diplomacy" },
        new() { Name = "Spin Flax", Category = "Utility", LevelRequired = 76, Experience = 75, Members = true, Notes = "Spins 5 flax; Lunar spellbook", QuestRequirement = "Lunar Diplomacy" },
        new() { Name = "String Jewellery", Category = "Utility", LevelRequired = 80, Experience = 83, Members = true, Notes = "Lunar spellbook", QuestRequirement = "Lunar Diplomacy" },
        new() { Name = "Humidify", Category = "Utility", LevelRequired = 68, Experience = 65, Members = true, Notes = "Fills containers with water; Lunar spellbook", QuestRequirement = "Dream Mentor" },

        // ── Ancient Magicks combat ──────────────────────────────────────
        new() { Name = "Smoke Rush", Category = "Ancient Combat", LevelRequired = 50, Experience = 30, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Shadow Rush", Category = "Ancient Combat", LevelRequired = 52, Experience = 31, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Blood Rush", Category = "Ancient Combat", LevelRequired = 56, Experience = 33, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Ice Rush", Category = "Ancient Combat", LevelRequired = 58, Experience = 34, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Smoke Burst", Category = "Ancient Combat", LevelRequired = 62, Experience = 36, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Shadow Burst", Category = "Ancient Combat", LevelRequired = 64, Experience = 37, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Blood Burst", Category = "Ancient Combat", LevelRequired = 68, Experience = 39, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Ice Burst", Category = "Ancient Combat", LevelRequired = 70, Experience = 40, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Smoke Blitz", Category = "Ancient Combat", LevelRequired = 74, Experience = 42, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Shadow Blitz", Category = "Ancient Combat", LevelRequired = 76, Experience = 43, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Blood Blitz", Category = "Ancient Combat", LevelRequired = 80, Experience = 45, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Ice Blitz", Category = "Ancient Combat", LevelRequired = 82, Experience = 46, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Smoke Barrage", Category = "Ancient Combat", LevelRequired = 86, Experience = 48, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Shadow Barrage", Category = "Ancient Combat", LevelRequired = 88, Experience = 49, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Blood Barrage", Category = "Ancient Combat", LevelRequired = 92, Experience = 51, Members = true, QuestRequirement = "Desert Treasure I" },
        new() { Name = "Ice Barrage", Category = "Ancient Combat", LevelRequired = 94, Experience = 52, Members = true, QuestRequirement = "Desert Treasure I" },

        // ── Lunar spells (non-utility, notable XP) ──────────────────────
        new() { Name = "Superglass Make", Category = "Lunar", LevelRequired = 77, Experience = 78, Members = true, QuestRequirement = "Lunar Diplomacy", Notes = "Crafting training method" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    public static IEnumerable<int> AllItemIds =>
        Actions.Where(a => a.ItemId.HasValue)
            .Select(a => a.ItemId!.Value)
            .Distinct();
}
