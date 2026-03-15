namespace OsrsCalcTool.Api.Models;

public class ConstructionAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }
    public int PlanksRequired { get; init; }
    public int? PlankItemId { get; init; }
    public int SteelBarsRequired { get; init; }
    public string? QuestRequirement { get; init; }
}

public static class ConstructionData
{
    public static IReadOnlyList<ConstructionAction> Actions { get; } =
    [
        // ── Plank (regular) ─────────────────────────────────────────────
        new() { Name = "Crude wooden chair", Category = "Plank", LevelRequired = 1, Experience = 58, Members = true, PlanksRequired = 2, PlankItemId = 960 },
        new() { Name = "Wooden bookcase", Category = "Plank", LevelRequired = 4, Experience = 115, Members = true, PlanksRequired = 4, PlankItemId = 960 },
        new() { Name = "Wooden chair", Category = "Plank", LevelRequired = 8, Experience = 87, Members = true, PlanksRequired = 3, PlankItemId = 960 },
        new() { Name = "Wooden larder", Category = "Plank", LevelRequired = 9, Experience = 228, Members = true, PlanksRequired = 8, PlankItemId = 960 },
        new() { Name = "Repair bench", Category = "Plank", LevelRequired = 15, Experience = 120, Members = true, PlanksRequired = 2, PlankItemId = 960, SteelBarsRequired = 2 },
        new() { Name = "Crafting table 1", Category = "Plank", LevelRequired = 16, Experience = 240, Members = true, PlanksRequired = 4, PlankItemId = 960 },

        // ── Oak ─────────────────────────────────────────────────────────
        new() { Name = "Oak chair", Category = "Oak", LevelRequired = 19, Experience = 120, Members = true, PlanksRequired = 2, PlankItemId = 8778 },
        new() { Name = "Oak dining table", Category = "Oak", LevelRequired = 22, Experience = 240, Members = true, PlanksRequired = 4, PlankItemId = 8778 },
        new() { Name = "Oak armchair", Category = "Oak", LevelRequired = 26, Experience = 180, Members = true, PlanksRequired = 3, PlankItemId = 8778 },
        new() { Name = "Oak larder", Category = "Oak", LevelRequired = 33, Experience = 480, Members = true, PlanksRequired = 8, PlankItemId = 8778 },
        new() { Name = "Oak dungeon door", Category = "Oak", LevelRequired = 74, Experience = 600, Members = true, PlanksRequired = 10, PlankItemId = 8778 },

        // ── Teak ────────────────────────────────────────────────────────
        new() { Name = "Teak table", Category = "Teak", LevelRequired = 38, Experience = 360, Members = true, PlanksRequired = 4, PlankItemId = 8780 },
        new() { Name = "Teak larder", Category = "Teak", LevelRequired = 43, Experience = 540, Members = true, PlanksRequired = 8, PlankItemId = 8780, SteelBarsRequired = 2, Notes = "8 teak + 2 steel bars" },
        new() { Name = "Teak bench", Category = "Teak", LevelRequired = 44, Experience = 540, Members = true, PlanksRequired = 6, PlankItemId = 8780 },
        new() { Name = "Teak dining bench", Category = "Teak", LevelRequired = 44, Experience = 540, Members = true, PlanksRequired = 6, PlankItemId = 8780 },
        new() { Name = "Teak garden bench", Category = "Teak", LevelRequired = 66, Experience = 540, Members = true, PlanksRequired = 6, PlankItemId = 8780 },

        // ── Mahogany ────────────────────────────────────────────────────
        new() { Name = "Mahogany table", Category = "Mahogany", LevelRequired = 52, Experience = 840, Members = true, PlanksRequired = 6, PlankItemId = 8782 },
        new() { Name = "Mahogany bench", Category = "Mahogany", LevelRequired = 56, Experience = 840, Members = true, PlanksRequired = 6, PlankItemId = 8782 },
        new() { Name = "Mahogany bookcase", Category = "Mahogany", LevelRequired = 57, Experience = 840, Members = true, PlanksRequired = 3, PlankItemId = 8782 },
        new() { Name = "Mahogany dining bench", Category = "Mahogany", LevelRequired = 56, Experience = 840, Members = true, PlanksRequired = 6, PlankItemId = 8782 },
        new() { Name = "Gilded bench", Category = "Mahogany", LevelRequired = 61, Experience = 1760, Members = true, PlanksRequired = 6, PlankItemId = 8782, Notes = "6 mahogany + 4 gold leaves" },
        new() { Name = "Gilded clock", Category = "Mahogany", LevelRequired = 85, Experience = 602, Members = true, PlanksRequired = 1, PlankItemId = 8782, Notes = "1 mahogany + 1 gold leaf" },
        new() { Name = "Gnome bench", Category = "Mahogany", LevelRequired = 77, Experience = 840, Members = true, PlanksRequired = 6, PlankItemId = 8782 },

        // ── Mythical cape (mount) ───────────────────────────────────────
        new() { Name = "Mythical cape (mounted)", Category = "Special", LevelRequired = 47, Experience = 370, Members = true, Notes = "Requires Dragon Slayer II; teak planks", QuestRequirement = "Dragon Slayer II" },
    ];

    private static readonly Dictionary<int, string> PlankNames = new()
    {
        [960]  = "Plank",
        [8778] = "Oak plank",
        [8780] = "Teak plank",
        [8782] = "Mahogany plank",
    };

    /// <summary>
    /// Converts ConstructionActions to the standard SkillAction-compatible DTO with
    /// Ingredients populated from PlanksRequired + PlankItemId + SteelBarsRequired.
    /// </summary>
    public static IReadOnlyList<string> Quests { get; } =
        Actions.Where(a => a.QuestRequirement != null)
               .Select(a => a.QuestRequirement!)
               .Distinct()
               .Order()
               .ToList();

    public static IReadOnlyList<object> ToSkillActions() =>
        Actions.Select(a =>
        {
            var ingredients = new List<Ingredient>();
            if (a.PlankItemId.HasValue && a.PlanksRequired > 0)
            {
                var plankName = PlankNames.GetValueOrDefault(a.PlankItemId.Value, "Plank");
                ingredients.Add(new Ingredient(plankName, a.PlankItemId.Value, a.PlanksRequired));
            }
            if (a.SteelBarsRequired > 0)
                ingredients.Add(new Ingredient("Steel bar", 2353, a.SteelBarsRequired));

            return (object)new
            {
                a.Name,
                a.Category,
                a.LevelRequired,
                a.Experience,
                a.Members,
                a.Notes,
                a.ItemId,
                a.QuestRequirement,
                Ingredients = ingredients.Count > 0 ? (IReadOnlyList<Ingredient>)ingredients : null,
            };
        }).ToList();

    /// <summary>Plank item IDs: 960 = plank, 8778 = oak plank, 8780 = teak plank, 8782 = mahogany plank.</summary>
    public static IEnumerable<int> AllItemIds
    {
        get
        {
            var ids = new HashSet<int>();
            foreach (var a in Actions)
            {
                if (a.ItemId.HasValue) ids.Add(a.ItemId.Value);
                if (a.PlankItemId.HasValue) ids.Add(a.PlankItemId.Value);
            }
            // Steel bar
            ids.Add(2353);
            return ids;
        }
    }

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();
}
