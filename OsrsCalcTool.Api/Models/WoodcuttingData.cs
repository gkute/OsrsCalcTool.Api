namespace OsrsCalcTool.Api.Models;

public class WoodcuttingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }
}

public static class WoodcuttingData
{
    public static IReadOnlyList<WoodcuttingAction> Actions { get; } =
    [
        // ── Standard trees ──────────────────────────────────────────────
        new() { Name = "Logs", Category = "Tree", LevelRequired = 1, Experience = 25, ItemId = 1511 },
        new() { Name = "Achey tree logs", Category = "Tree", LevelRequired = 1, Experience = 25, Members = true, ItemId = 2862, Notes = "Feldip Hills" },
        new() { Name = "Oak logs", Category = "Tree", LevelRequired = 15, Experience = 37.5, ItemId = 1521 },
        new() { Name = "Willow logs", Category = "Tree", LevelRequired = 30, Experience = 67.5, ItemId = 1519 },
        new() { Name = "Teak logs", Category = "Tree", LevelRequired = 35, Experience = 85, Members = true, ItemId = 6333 },
        new() { Name = "Maple logs", Category = "Tree", LevelRequired = 45, Experience = 100, ItemId = 1517 },
        new() { Name = "Bark", Category = "Tree", LevelRequired = 45, Experience = 82.5, Members = true, ItemId = 3239, Notes = "Hollow trees; Canifis swamp" },
        new() { Name = "Mahogany logs", Category = "Tree", LevelRequired = 50, Experience = 125, Members = true, ItemId = 6332 },
        new() { Name = "Arctic pine logs", Category = "Tree", LevelRequired = 54, Experience = 140.2, Members = true, ItemId = 10810, Notes = "Neitiznot" },
        new() { Name = "Yew logs", Category = "Tree", LevelRequired = 60, Experience = 175, ItemId = 1515 },
        new() { Name = "Blisterwood logs", Category = "Tree", LevelRequired = 62, Experience = 76, Members = true, ItemId = 19467, Notes = "Darkmeyer; Sins of the Father" },
        new() { Name = "Magic logs", Category = "Tree", LevelRequired = 75, Experience = 250, Members = true, ItemId = 1513 },
        new() { Name = "Redwood logs", Category = "Tree", LevelRequired = 90, Experience = 380, Members = true, ItemId = 19669, Notes = "Woodcutting Guild" },

        // ── Special & Minigame ──────────────────────────────────────────
        new() { Name = "Juniper logs", Category = "Special", LevelRequired = 42, Experience = 35, Members = true, ItemId = 13355, Notes = "Hosidius; for juniper charcoal" },
        new() { Name = "Sulliuscep", Category = "Special", LevelRequired = 65, Experience = 127, Members = true, Notes = "Fossil Island mushroom forest; no tradeable log" },

        // ── Sailing ─────────────────────────────────────────────────────
        new() { Name = "Driftwood", Category = "Sailing", LevelRequired = 1, Experience = 1, Members = true, Notes = "Sailing content" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();
}
