namespace OsrsCalcTool.Api.Models;

public class RunecraftingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }
    public string? QuestRequirement { get; init; }

    /// <summary>Level at which you start crafting multiple runes per essence (0 if N/A).</summary>
    public int MultipleRuneLevel { get; init; }
}

public static class RunecraftingData
{
    public static IReadOnlyList<string> Quests { get; } =
    [
        "Dragon Slayer II",
        "Sins of the Father",
    ];

    public static IReadOnlyList<RunecraftingAction> Actions { get; } =
    [
        // ── Standard runes ──────────────────────────────────────────────
        new() { Name = "Air rune", Category = "Rune", LevelRequired = 1, Experience = 5, ItemId = 556, MultipleRuneLevel = 11 },
        new() { Name = "Mind rune", Category = "Rune", LevelRequired = 2, Experience = 5.5, ItemId = 558, MultipleRuneLevel = 14 },
        new() { Name = "Water rune", Category = "Rune", LevelRequired = 5, Experience = 6, ItemId = 555, MultipleRuneLevel = 19 },
        new() { Name = "Earth rune", Category = "Rune", LevelRequired = 9, Experience = 6.5, ItemId = 557, MultipleRuneLevel = 26 },
        new() { Name = "Fire rune", Category = "Rune", LevelRequired = 14, Experience = 7, ItemId = 554, MultipleRuneLevel = 35 },
        new() { Name = "Body rune", Category = "Rune", LevelRequired = 20, Experience = 7.5, ItemId = 559, MultipleRuneLevel = 46 },
        new() { Name = "Cosmic rune", Category = "Rune", LevelRequired = 27, Experience = 8, Members = true, ItemId = 564, MultipleRuneLevel = 59 },
        new() { Name = "Chaos rune", Category = "Rune", LevelRequired = 35, Experience = 8.5, ItemId = 562, MultipleRuneLevel = 74 },
        new() { Name = "Astral rune", Category = "Rune", LevelRequired = 40, Experience = 8.7, Members = true, ItemId = 9075, Notes = "Lunar Isle; Lunar Diplomacy" },
        new() { Name = "Nature rune", Category = "Rune", LevelRequired = 44, Experience = 9, Members = true, ItemId = 561, MultipleRuneLevel = 91 },
        new() { Name = "Law rune", Category = "Rune", LevelRequired = 54, Experience = 9.5, Members = true, ItemId = 563, MultipleRuneLevel = 95 },
        new() { Name = "Death rune", Category = "Rune", LevelRequired = 65, Experience = 10, Members = true, ItemId = 560, MultipleRuneLevel = 99 },
        new() { Name = "Wrath rune", Category = "Rune", LevelRequired = 95, Experience = 8, Members = true, ItemId = 21880, QuestRequirement = "Dragon Slayer II" },
        new() { Name = "Blood rune", Category = "Rune", LevelRequired = 77, Experience = 23.8, Members = true, ItemId = 565, Notes = "True Blood Altar or Arceuus method" },
        new() { Name = "Soul rune", Category = "Rune", LevelRequired = 90, Experience = 29.7, Members = true, ItemId = 566, Notes = "True Soul Altar" },
        new() { Name = "Sunfire rune", Category = "Rune", LevelRequired = 33, Experience = 7, Members = true, ItemId = 29314, Notes = "Sunfire altar in the Fortis Colosseum" },

        // ── Combo runes ─────────────────────────────────────────────────
        new() { Name = "Mist rune", Category = "Combo Rune", LevelRequired = 6, Experience = 8, Members = true, ItemId = 4695 },
        new() { Name = "Dust rune", Category = "Combo Rune", LevelRequired = 10, Experience = 8.3, Members = true, ItemId = 4696 },
        new() { Name = "Mud rune", Category = "Combo Rune", LevelRequired = 13, Experience = 9.3, Members = true, ItemId = 4698 },
        new() { Name = "Smoke rune", Category = "Combo Rune", LevelRequired = 15, Experience = 8.5, Members = true, ItemId = 4697 },
        new() { Name = "Steam rune", Category = "Combo Rune", LevelRequired = 19, Experience = 9.3, Members = true, ItemId = 4694 },
        new() { Name = "Lava rune", Category = "Combo Rune", LevelRequired = 23, Experience = 10, Members = true, ItemId = 4699, Notes = "Popular training method" },

        // ── Tiaras ──────────────────────────────────────────────────────
        new() { Name = "Air tiara", Category = "Tiara", LevelRequired = 1, Experience = 25, ItemId = 5527 },
        new() { Name = "Mind tiara", Category = "Tiara", LevelRequired = 2, Experience = 27.5, ItemId = 5529 },
        new() { Name = "Water tiara", Category = "Tiara", LevelRequired = 5, Experience = 30, ItemId = 5531 },
        new() { Name = "Earth tiara", Category = "Tiara", LevelRequired = 9, Experience = 32.5, ItemId = 5535 },
        new() { Name = "Fire tiara", Category = "Tiara", LevelRequired = 14, Experience = 35, ItemId = 5537 },
        new() { Name = "Body tiara", Category = "Tiara", LevelRequired = 20, Experience = 37.5, ItemId = 5533 },
        new() { Name = "Cosmic tiara", Category = "Tiara", LevelRequired = 27, Experience = 40, Members = true, ItemId = 5539 },
        new() { Name = "Chaos tiara", Category = "Tiara", LevelRequired = 35, Experience = 42.5, ItemId = 5543 },
        new() { Name = "Nature tiara", Category = "Tiara", LevelRequired = 44, Experience = 45, Members = true, ItemId = 5541 },
        new() { Name = "Law tiara", Category = "Tiara", LevelRequired = 54, Experience = 47.5, Members = true, ItemId = 5545 },
        new() { Name = "Death tiara", Category = "Tiara", LevelRequired = 65, Experience = 50, Members = true, ItemId = 5547 },

        // ── Guardians of the Rift ───────────────────────────────────────
        new() { Name = "Guardians of the Rift (avg)", Category = "Minigame", LevelRequired = 27, Experience = 7600, Members = true, Notes = "Avg XP per game; scales with level" },

        // ── Daeyalt essence ─────────────────────────────────────────────
        new() { Name = "Daeyalt essence bonus", Category = "Special", LevelRequired = 1, Experience = 0, Members = true, Notes = "50% more RC XP per essence; mined in Darkmeyer", QuestRequirement = "Sins of the Father" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    public static IEnumerable<int> AllItemIds =>
        Actions.Where(a => a.ItemId.HasValue)
            .Select(a => a.ItemId!.Value)
            .Distinct();
}
