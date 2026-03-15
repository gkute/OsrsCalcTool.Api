namespace OsrsCalcTool.Api.Models;

public class ThievingAction
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

public static class ThievingData
{
    public static IReadOnlyList<string> Quests { get; } =
    [
        "The Feud",
        "Song of the Elves",
    ];

    public static IReadOnlyList<ThievingAction> Actions { get; } =
    [
        // ── Pickpocketing ───────────────────────────────────────────────
        new() { Name = "Man / Woman", Category = "Pickpocket", LevelRequired = 1, Experience = 8 },
        new() { Name = "Farmer", Category = "Pickpocket", LevelRequired = 10, Experience = 14.5 },
        new() { Name = "Female H.A.M. member", Category = "Pickpocket", LevelRequired = 15, Experience = 18.5 },
        new() { Name = "Male H.A.M. member", Category = "Pickpocket", LevelRequired = 20, Experience = 22.5 },
        new() { Name = "Warrior", Category = "Pickpocket", LevelRequired = 25, Experience = 26 },
        new() { Name = "Rogue", Category = "Pickpocket", LevelRequired = 32, Experience = 35.5 },
        new() { Name = "Cave goblin", Category = "Pickpocket", LevelRequired = 36, Experience = 40, Members = true },
        new() { Name = "Master farmer", Category = "Pickpocket", LevelRequired = 38, Experience = 43, Members = true },
        new() { Name = "Guard", Category = "Pickpocket", LevelRequired = 40, Experience = 46.8 },
        new() { Name = "Fremennik citizen", Category = "Pickpocket", LevelRequired = 45, Experience = 65, Members = true },
        new() { Name = "Bearded Pollnivnian bandit", Category = "Pickpocket", LevelRequired = 45, Experience = 65, Members = true, QuestRequirement = "The Feud" },
        new() { Name = "Desert bandit", Category = "Pickpocket", LevelRequired = 53, Experience = 79.4, Members = true },
        new() { Name = "Knight of Ardougne", Category = "Pickpocket", LevelRequired = 55, Experience = 84.3, Members = true },
        new() { Name = "Pollnivnian bandit", Category = "Pickpocket", LevelRequired = 55, Experience = 84.3, Members = true, QuestRequirement = "The Feud" },
        new() { Name = "Yanille watchman", Category = "Pickpocket", LevelRequired = 65, Experience = 137.5, Members = true },
        new() { Name = "Menaphite thug", Category = "Pickpocket", LevelRequired = 65, Experience = 137.5, Members = true, QuestRequirement = "The Feud" },
        new() { Name = "Paladin", Category = "Pickpocket", LevelRequired = 70, Experience = 151.8, Members = true },
        new() { Name = "Gnome", Category = "Pickpocket", LevelRequired = 75, Experience = 198.5, Members = true },
        new() { Name = "Hero", Category = "Pickpocket", LevelRequired = 80, Experience = 275, Members = true },
        new() { Name = "Vyre", Category = "Pickpocket", LevelRequired = 82, Experience = 306.9, Members = true },
        new() { Name = "Elf", Category = "Pickpocket", LevelRequired = 85, Experience = 353, Members = true, QuestRequirement = "Song of the Elves" },
        new() { Name = "TzHaar-Hur", Category = "Pickpocket", LevelRequired = 90, Experience = 103.4, Members = true },

        // ── Stalls ──────────────────────────────────────────────────────
        new() { Name = "Vegetable stall", Category = "Stall", LevelRequired = 2, Experience = 10, Members = true },
        new() { Name = "Baker's stall", Category = "Stall", LevelRequired = 5, Experience = 16 },
        new() { Name = "Tea stall", Category = "Stall", LevelRequired = 5, Experience = 16, Members = true },
        new() { Name = "Crafting stall", Category = "Stall", LevelRequired = 5, Experience = 16, Members = true, Notes = "Ape Atoll" },
        new() { Name = "Silk stall", Category = "Stall", LevelRequired = 20, Experience = 24 },
        new() { Name = "Wine stall", Category = "Stall", LevelRequired = 22, Experience = 27, Members = true },
        new() { Name = "Fruit stall", Category = "Stall", LevelRequired = 25, Experience = 28.5, Members = true },
        new() { Name = "Seed stall", Category = "Stall", LevelRequired = 27, Experience = 10, Members = true },
        new() { Name = "Fur stall", Category = "Stall", LevelRequired = 35, Experience = 36 },
        new() { Name = "Fish stall", Category = "Stall", LevelRequired = 42, Experience = 42, Members = true },
        new() { Name = "Silver stall", Category = "Stall", LevelRequired = 50, Experience = 54 },
        new() { Name = "Spice stall", Category = "Stall", LevelRequired = 65, Experience = 81, Members = true },
        new() { Name = "Gem stall", Category = "Stall", LevelRequired = 75, Experience = 160, Members = true },
        new() { Name = "Ore stall", Category = "Stall", LevelRequired = 82, Experience = 180, Members = true, Notes = "Keldagrim" },

        // ── Chests ──────────────────────────────────────────────────────
        new() { Name = "10 coin chest", Category = "Chest", LevelRequired = 13, Experience = 7.8 },
        new() { Name = "Nature rune chest", Category = "Chest", LevelRequired = 28, Experience = 25, Members = true },
        new() { Name = "50 coin chest", Category = "Chest", LevelRequired = 43, Experience = 125, Members = true },
        new() { Name = "Steel arrowtip chest", Category = "Chest", LevelRequired = 47, Experience = 150, Members = true },
        new() { Name = "Blood rune chest", Category = "Chest", LevelRequired = 59, Experience = 250, Members = true },
        new() { Name = "Dorgesh-Kaan rich chest", Category = "Chest", LevelRequired = 78, Experience = 650, Members = true },

        // ── Other ───────────────────────────────────────────────────────
        new() { Name = "Sorceress's Garden (Summer)", Category = "Other", LevelRequired = 65, Experience = 3000, Members = true, Notes = "Per run; Sq'irk juice teleport" },
        new() { Name = "Pyramid Plunder (Room 8)", Category = "Other", LevelRequired = 91, Experience = 6500, Members = true, Notes = "Avg XP per run in final room" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    public static IEnumerable<int> AllItemIds =>
        Actions.Where(a => a.ItemId.HasValue)
            .Select(a => a.ItemId!.Value)
            .Distinct();
}
