namespace OsrsCalcTool.Api.Models;

public class FiremakingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }

    /// <summary>
    /// The log/item consumed as a single ingredient for cost calculations.
    /// </summary>
    public IReadOnlyList<Ingredient>? Ingredients =>
        ItemId.HasValue ? [new Ingredient(Name, ItemId.Value, 1)] : null;
}

public static class FiremakingData
{
    public static IReadOnlyList<FiremakingAction> Actions { get; } =
    [
        // ── Standard logs ───────────────────────────────────────────────
        new() { Name = "Logs", Category = "Log", LevelRequired = 1, Experience = 40, ItemId = 1511 },
        new() { Name = "Achey tree logs", Category = "Log", LevelRequired = 1, Experience = 40, Members = true, ItemId = 2862 },
        new() { Name = "Oak logs", Category = "Log", LevelRequired = 15, Experience = 60, ItemId = 1521 },
        new() { Name = "Willow logs", Category = "Log", LevelRequired = 30, Experience = 90, ItemId = 1519 },
        new() { Name = "Teak logs", Category = "Log", LevelRequired = 35, Experience = 105, Members = true, ItemId = 6333 },
        new() { Name = "Arctic pine logs", Category = "Log", LevelRequired = 42, Experience = 125, Members = true, ItemId = 10810 },
        new() { Name = "Maple logs", Category = "Log", LevelRequired = 45, Experience = 135, ItemId = 1517 },
        new() { Name = "Mahogany logs", Category = "Log", LevelRequired = 50, Experience = 157.5, Members = true, ItemId = 6332 },
        new() { Name = "Yew logs", Category = "Log", LevelRequired = 60, Experience = 202.5, ItemId = 1515 },
        new() { Name = "Blisterwood logs", Category = "Log", LevelRequired = 62, Experience = 96, Members = true, ItemId = 19467 },
        new() { Name = "Magic logs", Category = "Log", LevelRequired = 75, Experience = 303.8, Members = true, ItemId = 1513 },
        new() { Name = "Redwood logs", Category = "Log", LevelRequired = 90, Experience = 350, Members = true, ItemId = 19669 },

        // ── Pyre logs (Shades of Mort'ton) ──────────────────────────────
        new() { Name = "Pyre logs", Category = "Pyre Log", LevelRequired = 5, Experience = 50, Members = true, ItemId = 3438, Notes = "Logs + sacred oil" },
        new() { Name = "Oak pyre logs", Category = "Pyre Log", LevelRequired = 20, Experience = 70, Members = true, ItemId = 3440, Notes = "Oak logs + sacred oil" },
        new() { Name = "Willow pyre logs", Category = "Pyre Log", LevelRequired = 35, Experience = 100, Members = true, ItemId = 3442, Notes = "Willow logs + sacred oil" },
        new() { Name = "Teak pyre logs", Category = "Pyre Log", LevelRequired = 40, Experience = 120, Members = true, ItemId = 3444, Notes = "Teak logs + sacred oil" },
        new() { Name = "Arctic pyre logs", Category = "Pyre Log", LevelRequired = 47, Experience = 158, Members = true, ItemId = 3446, Notes = "Arctic pine logs + sacred oil" },
        new() { Name = "Maple pyre logs", Category = "Pyre Log", LevelRequired = 50, Experience = 175, Members = true, ItemId = 3448, Notes = "Maple logs + sacred oil" },
        new() { Name = "Mahogany pyre logs", Category = "Pyre Log", LevelRequired = 55, Experience = 210, Members = true, ItemId = 3450, Notes = "Mahogany logs + sacred oil" },
        new() { Name = "Yew pyre logs", Category = "Pyre Log", LevelRequired = 65, Experience = 225, Members = true, ItemId = 3452, Notes = "Yew logs + sacred oil" },
        new() { Name = "Magic pyre logs", Category = "Pyre Log", LevelRequired = 80, Experience = 404.5, Members = true, ItemId = 3454, Notes = "Magic logs + sacred oil" },
        new() { Name = "Redwood pyre logs", Category = "Pyre Log", LevelRequired = 95, Experience = 500, Members = true, ItemId = 22302, Notes = "Redwood logs + sacred oil" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    public static IEnumerable<int> AllItemIds =>
        Actions.Where(a => a.ItemId.HasValue)
            .Select(a => a.ItemId!.Value)
            .Distinct();
}
