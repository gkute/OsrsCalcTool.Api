namespace OsrsCalcTool.Api.Models;

public class FishingAction
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

public static class FishingData
{
    public static IReadOnlyList<FishingAction> Actions { get; } =
    [
        // Net — Small fishing net
        new() { Name = "Raw shrimps", Category = "Net", LevelRequired = 1, Experience = 10, ItemId = 317 },
        new() { Name = "Raw karambwanji", Category = "Net", LevelRequired = 5, Experience = 5, Members = true, ItemId = 3150, Notes = "Karamja lake" },
        new() { Name = "Raw anchovies", Category = "Net", LevelRequired = 15, Experience = 40, ItemId = 321 },
        new() { Name = "Raw monkfish", Category = "Net", LevelRequired = 62, Experience = 120, Members = true, ItemId = 7944, Notes = "Requires Swan Song quest", QuestRequirement = "Swan Song" },
        new() { Name = "Minnow", Category = "Net", LevelRequired = 82, Experience = 26.1, Members = true, ItemId = 21356, Notes = "Fishing Guild; requires angler outfit shown to Kylie Minnow" },

        // Bait — Fishing rod + bait
        new() { Name = "Raw sardine", Category = "Bait", LevelRequired = 5, Experience = 20, ItemId = 327 },
        new() { Name = "Raw herring", Category = "Bait", LevelRequired = 10, Experience = 30, ItemId = 345 },
        new() { Name = "Raw pike", Category = "Bait", LevelRequired = 25, Experience = 60, ItemId = 349 },
        new() { Name = "Raw slimy eel", Category = "Bait", LevelRequired = 28, Experience = 65, Members = true, ItemId = 3379, Notes = "Lumbridge Swamp Caves / Mort Myre Swamp" },
        new() { Name = "Raw cave eel", Category = "Bait", LevelRequired = 38, Experience = 80, Members = true, ItemId = 5001, Notes = "Lumbridge Swamp Caves" },
        new() { Name = "Raw lava eel", Category = "Bait", LevelRequired = 53, Experience = 30, Members = true, ItemId = 2148, Notes = "Requires oily fishing rod; Taverley Dungeon" },
        new() { Name = "Raw anglerfish", Category = "Bait", LevelRequired = 82, Experience = 120, Members = true, ItemId = 13439, Notes = "Requires sandworms as bait; Port Piscarilius" },
        new() { Name = "Sacred eel", Category = "Bait", LevelRequired = 87, Experience = 105, Members = true, ItemId = 13339, Notes = "Zul-Andra; partial Regicide completion" },
        new() { Name = "Infernal eel", Category = "Bait", LevelRequired = 80, Experience = 95, Members = true, ItemId = 21293, Notes = "Requires oily fishing rod + ice gloves; Mor Ul Rek" },

        // Lure — Fly fishing rod + feathers
        new() { Name = "Raw trout", Category = "Lure", LevelRequired = 20, Experience = 50, ItemId = 335 },
        new() { Name = "Raw salmon", Category = "Lure", LevelRequired = 30, Experience = 70, ItemId = 331 },
        new() { Name = "Raw rainbow fish", Category = "Lure", LevelRequired = 38, Experience = 80, Members = true, ItemId = 10138, Notes = "Requires stripy feather" },

        // Cage — Lobster pot
        new() { Name = "Raw lobster", Category = "Cage", LevelRequired = 40, Experience = 90, ItemId = 377 },
        new() { Name = "Raw dark crab", Category = "Cage", LevelRequired = 85, Experience = 130, Members = true, ItemId = 11934, Notes = "Wilderness Resource Area; requires dark fishing bait" },

        // Harpoon
        new() { Name = "Raw tuna", Category = "Harpoon", LevelRequired = 35, Experience = 80, ItemId = 359 },
        new() { Name = "Raw swordfish", Category = "Harpoon", LevelRequired = 50, Experience = 100, ItemId = 371 },
        new() { Name = "Raw shark", Category = "Harpoon", LevelRequired = 76, Experience = 110, Members = true, ItemId = 383 },

        // Big Net
        new() { Name = "Raw mackerel", Category = "Big Net", LevelRequired = 16, Experience = 20, Members = true, ItemId = 353 },
        new() { Name = "Raw cod", Category = "Big Net", LevelRequired = 23, Experience = 45, Members = true, ItemId = 341 },
        new() { Name = "Raw bass", Category = "Big Net", LevelRequired = 46, Experience = 100, Members = true, ItemId = 363 },

        // Barbarian Fishing — Heavy rod
        new() { Name = "Leaping trout", Category = "Barbarian", LevelRequired = 48, Experience = 50, Members = true, ItemId = 11328, Notes = "Requires 15 Agility & 15 Strength; also gives Str & Agi XP" },
        new() { Name = "Leaping salmon", Category = "Barbarian", LevelRequired = 58, Experience = 70, Members = true, ItemId = 11330, Notes = "Requires 30 Agility & 30 Strength; also gives Str & Agi XP" },
        new() { Name = "Leaping sturgeon", Category = "Barbarian", LevelRequired = 70, Experience = 80, Members = true, ItemId = 11332, Notes = "Requires 45 Agility & 45 Strength; also gives Str & Agi XP" },

        // Aerial Fishing — Cormorant's glove
        new() { Name = "Bluegill", Category = "Aerial", LevelRequired = 43, Experience = 11.5, Members = true, ItemId = 22826, Notes = "Requires 35 Hunter; Lake Molch" },
        new() { Name = "Common tench", Category = "Aerial", LevelRequired = 56, Experience = 40, Members = true, ItemId = 22829, Notes = "Requires 51 Hunter; Lake Molch" },
        new() { Name = "Mottled eel", Category = "Aerial", LevelRequired = 73, Experience = 65, Members = true, ItemId = 22832, Notes = "Requires 68 Hunter; Lake Molch" },
        new() { Name = "Greater siren", Category = "Aerial", LevelRequired = 91, Experience = 100, Members = true, ItemId = 22835, Notes = "Requires 87 Hunter; Lake Molch" },

        // Karambwan
        new() { Name = "Raw karambwan", Category = "Karambwan", LevelRequired = 65, Experience = 50, Members = true, ItemId = 3142, Notes = "Requires Tai Bwo Wannai Trio quest; karambwan vessel + raw karambwanji", QuestRequirement = "Tai Bwo Wannai Trio" },

        // Drift Net
        new() { Name = "Fish shoal (Drift net)", Category = "Drift Net", LevelRequired = 47, Experience = 77, Members = true, ItemId = 21510, Notes = "Requires 44 Hunter; Fossil Island underwater" },

        // Tempoross — skilling boss
        new() { Name = "Harpoonfish (Tempoross)", Category = "Tempoross", LevelRequired = 35, Experience = 65, Members = true, ItemId = 25564, Notes = "Ruins of Unkah; XP varies by contribution" },

        // Ruins of Camdozaal (Below Ice Mountain)
        new() { Name = "Raw guppy", Category = "Camdozaal", LevelRequired = 7, Experience = 8, ItemId = 25652, Notes = "Ruins of Camdozaal; Below Ice Mountain quest", QuestRequirement = "Below Ice Mountain" },
        new() { Name = "Raw cavefish", Category = "Camdozaal", LevelRequired = 20, Experience = 16, ItemId = 25654, Notes = "Ruins of Camdozaal; Below Ice Mountain quest", QuestRequirement = "Below Ice Mountain" },
        new() { Name = "Raw tetra", Category = "Camdozaal", LevelRequired = 33, Experience = 24, ItemId = 25656, Notes = "Ruins of Camdozaal; Below Ice Mountain quest", QuestRequirement = "Below Ice Mountain" },
        new() { Name = "Raw catfish", Category = "Camdozaal", LevelRequired = 46, Experience = 33, ItemId = 25658, Notes = "Ruins of Camdozaal; Below Ice Mountain quest; big net", QuestRequirement = "Below Ice Mountain" },

        // Frog spawn
        new() { Name = "Frog spawn", Category = "Special", LevelRequired = 33, Experience = 10, Members = true, ItemId = 5004, Notes = "Lumbridge Swamp Caves / Dorgesh-Kaan" },
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
