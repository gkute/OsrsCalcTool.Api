namespace OsrsCalcTool.Api.Models;

public class SmithingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }

    /// <summary>
    /// Explicit ingredients for smelting actions.
    /// Anvil items derive ingredients automatically via <see cref="SmithingData.GetIngredients"/>.
    /// </summary>
    public IReadOnlyList<Ingredient>? Ingredients { get; init; }
    public string? QuestRequirement { get; init; }
}

public static class SmithingData
{
    public const double GoldBarBaseXp = 22.5;
    public const double GoldBarGauntletXp = 56.2;

    // Bar item ID keyed by anvil category
    private static readonly Dictionary<string, Ingredient> BarByCategory = new()
    {
        ["Bronze"] = new("Bronze bar", 2349),
        ["Iron"]   = new("Iron bar", 2351),
        ["Steel"]  = new("Steel bar", 2353),
        ["Gold"]   = new("Gold bar", 2357),
        ["Mithril"] = new("Mithril bar", 2359),
        ["Adamant"] = new("Adamantite bar", 2361),
        ["Rune"]   = new("Runite bar", 2363),
    };

    // Log type needed for spears & hastas by category
    private static readonly Dictionary<string, Ingredient> LogByCategory = new()
    {
        ["Bronze"]  = new("Logs", 1511),
        ["Iron"]    = new("Oak logs", 1521),
        ["Steel"]   = new("Willow logs", 1519),
        ["Mithril"] = new("Maple logs", 1517),
        ["Adamant"] = new("Yew logs", 1515),
        ["Rune"]    = new("Magic logs", 1513),
    };

    /// <summary>
    /// Returns the material ingredients for any smithing action.
    /// Smelting actions use their explicit <see cref="SmithingAction.Ingredients"/>;
    /// anvil actions derive bars (and optional logs) from Category + Notes.
    /// </summary>
    public static IReadOnlyList<Ingredient> GetIngredients(SmithingAction action)
    {
        if (action.Ingredients is not null)
            return action.Ingredients;

        if (!BarByCategory.TryGetValue(action.Category, out var bar))
            return [];

        var barCount = ParseBarCount(action.Notes);
        if (barCount <= 0) return [];

        var barIngredient = bar with { Quantity = barCount };

        if ((action.Name.Contains("spear", StringComparison.OrdinalIgnoreCase)
          || action.Name.Contains("hasta", StringComparison.OrdinalIgnoreCase))
          && LogByCategory.TryGetValue(action.Category, out var log))
        {
            return [barIngredient, log];
        }

        return [barIngredient];
    }

    /// <summary>
    /// Returns actions with Ingredients fully resolved (anvil items get bar + optional log ingredients).
    /// Use this instead of Actions when serializing for the Angular frontend.
    /// </summary>
    public static IReadOnlyList<string> Quests =>
        Actions.Where(a => a.QuestRequirement != null)
               .Select(a => a.QuestRequirement!)
               .Distinct()
               .Order()
               .ToList();

    public static IReadOnlyList<object> ToSkillActions() =>
        Actions.Select(a =>
        {
            var ingredients = GetIngredients(a);
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
                // OutputItemId = ItemId: the smithed item is the produced output
                OutputItemId = a.ItemId,
                Ingredients = ingredients.Count > 0 ? (IReadOnlyList<Ingredient>)ingredients : null,
            };
        }).ToList();

    /// <summary>
    /// Collects every distinct item ID referenced by ingredients or output across all actions.
    /// </summary>
    public static IEnumerable<int> AllItemIds =>
        Actions.SelectMany(a =>
        {
            var ids = new List<int?>();
            if (a.ItemId.HasValue) ids.Add(a.ItemId);
            foreach (var ing in GetIngredients(a))
                if (ing.ItemId.HasValue) ids.Add(ing.ItemId);
            return ids;
        })
        .Where(id => id.HasValue)
        .Select(id => id!.Value)
        .Distinct();

    private static int ParseBarCount(string? notes) =>
        notes is [var ch, ..] && char.IsDigit(ch) ? ch - '0' : 0;

    public static IReadOnlyList<SmithingAction> Actions { get; } =
    [
        // ── Smelting — Bars at furnace ──────────────────────────────────
        new() { Name = "Bronze bar", Category = "Smelting", LevelRequired = 1, Experience = 6.2, ItemId = 2349, Ingredients = [new("Tin ore", 438), new("Copper ore", 436)], Notes = "50% chance with no ring of forging" },
        new() { Name = "Iron bar", Category = "Smelting", LevelRequired = 15, Experience = 12.5, ItemId = 2351, Ingredients = [new("Iron ore", 440)], Notes = "50% success without ring of forging" },
        new() { Name = "Silver bar", Category = "Smelting", LevelRequired = 20, Experience = 13.7, ItemId = 2355, Ingredients = [new("Silver ore", 442)] },
        new() { Name = "Steel bar", Category = "Smelting", LevelRequired = 30, Experience = 17.5, ItemId = 2353, Ingredients = [new("Iron ore", 440), new("Coal", 453, 2)] },
        new() { Name = "Gold bar", Category = "Smelting", LevelRequired = 40, Experience = 22.5, ItemId = 2357, Ingredients = [new("Gold ore", 444)], Notes = "56.2 XP with goldsmith gauntlets" },
        new() { Name = "Mithril bar", Category = "Smelting", LevelRequired = 50, Experience = 30, ItemId = 2359, Ingredients = [new("Mithril ore", 447), new("Coal", 453, 4)] },
        new() { Name = "Adamantite bar", Category = "Smelting", LevelRequired = 70, Experience = 37.5, ItemId = 2361, Ingredients = [new("Adamantite ore", 449), new("Coal", 453, 6)] },
        new() { Name = "Runite bar", Category = "Smelting", LevelRequired = 85, Experience = 50, ItemId = 2363, Ingredients = [new("Runite ore", 451), new("Coal", 453, 8)] },

        // ── Bronze — Anvil items ────────────────────────────────────────
        new() { Name = "Bronze dagger", Category = "Bronze", LevelRequired = 1, Experience = 12.5, ItemId = 1205, Notes = "1 bar" },
        new() { Name = "Bronze axe", Category = "Bronze", LevelRequired = 1, Experience = 12.5, ItemId = 1351, Notes = "1 bar" },
        new() { Name = "Bronze mace", Category = "Bronze", LevelRequired = 2, Experience = 12.5, ItemId = 1422, Notes = "1 bar" },
        new() { Name = "Bronze med helm", Category = "Bronze", LevelRequired = 3, Experience = 12.5, ItemId = 1139, Notes = "1 bar" },
        new() { Name = "Bronze bolts (unf) ×10", Category = "Bronze", LevelRequired = 3, Experience = 12.5, Members = true, ItemId = 9375, Notes = "1 bar" },
        new() { Name = "Bronze sword", Category = "Bronze", LevelRequired = 4, Experience = 12.5, ItemId = 1277, Notes = "1 bar" },
        new() { Name = "Bronze dart tip ×10", Category = "Bronze", LevelRequired = 4, Experience = 12.5, Members = true, ItemId = 819, Notes = "1 bar; requires The Tourist Trap" },
        new() { Name = "Bronze wire", Category = "Bronze", LevelRequired = 4, Experience = 12.5, Members = true, ItemId = 1641, Notes = "1 bar" },
        new() { Name = "Bronze nails ×15", Category = "Bronze", LevelRequired = 4, Experience = 12.5, Members = true, ItemId = 4819, Notes = "1 bar" },
        new() { Name = "Bronze scimitar", Category = "Bronze", LevelRequired = 5, Experience = 25, ItemId = 1321, Notes = "2 bars" },
        new() { Name = "Bronze spear", Category = "Bronze", LevelRequired = 5, Experience = 25, Members = true, ItemId = 1237, Notes = "1 bar + 1 log; requires Barbarian Training" },
        new() { Name = "Bronze hasta", Category = "Bronze", LevelRequired = 5, Experience = 25, Members = true, ItemId = 11367, Notes = "1 bar + 1 log; requires Barbarian Training" },
        new() { Name = "Bronze arrowtips ×15", Category = "Bronze", LevelRequired = 5, Experience = 12.5, Members = true, ItemId = 39, Notes = "1 bar" },
        new() { Name = "Bronze cannonball ×4", Category = "Bronze", LevelRequired = 5, Experience = 9, Members = true, Notes = "1 bar; requires ammo mould" },
        new() { Name = "Bronze limbs", Category = "Bronze", LevelRequired = 6, Experience = 12.5, Members = true, ItemId = 9420, Notes = "1 bar" },
        new() { Name = "Bronze longsword", Category = "Bronze", LevelRequired = 6, Experience = 25, ItemId = 1291, Notes = "2 bars" },
        new() { Name = "Bronze javelin tips ×5", Category = "Bronze", LevelRequired = 6, Experience = 12.5, Members = true, Notes = "1 bar" },
        new() { Name = "Bronze full helm", Category = "Bronze", LevelRequired = 7, Experience = 25, ItemId = 1155, Notes = "2 bars" },
        new() { Name = "Bronze knife ×5", Category = "Bronze", LevelRequired = 7, Experience = 12.5, Members = true, ItemId = 864, Notes = "1 bar" },
        new() { Name = "Bronze sq shield", Category = "Bronze", LevelRequired = 8, Experience = 25, ItemId = 1173, Notes = "2 bars" },
        new() { Name = "Bronze warhammer", Category = "Bronze", LevelRequired = 9, Experience = 37.5, ItemId = 1337, Notes = "3 bars" },
        new() { Name = "Bronze battleaxe", Category = "Bronze", LevelRequired = 10, Experience = 37.5, ItemId = 1375, Notes = "3 bars" },
        new() { Name = "Bronze chainbody", Category = "Bronze", LevelRequired = 11, Experience = 37.5, ItemId = 1103, Notes = "3 bars" },
        new() { Name = "Bronze kiteshield", Category = "Bronze", LevelRequired = 12, Experience = 37.5, ItemId = 1189, Notes = "3 bars" },
        new() { Name = "Bronze claws", Category = "Bronze", LevelRequired = 13, Experience = 25, Members = true, ItemId = 3095, Notes = "2 bars; requires Death Plateau" },
        new() { Name = "Bronze 2h sword", Category = "Bronze", LevelRequired = 14, Experience = 37.5, ItemId = 1307, Notes = "3 bars" },
        new() { Name = "Bronze platelegs", Category = "Bronze", LevelRequired = 16, Experience = 37.5, ItemId = 1075, Notes = "3 bars" },
        new() { Name = "Bronze plateskirt", Category = "Bronze", LevelRequired = 16, Experience = 37.5, ItemId = 1087, Notes = "3 bars" },
        new() { Name = "Bronze platebody", Category = "Bronze", LevelRequired = 18, Experience = 62.5, ItemId = 1117, Notes = "5 bars" },

        // ── Iron — Anvil items ──────────────────────────────────────────
        new() { Name = "Iron dagger", Category = "Iron", LevelRequired = 15, Experience = 25, ItemId = 1203, Notes = "1 bar" },
        new() { Name = "Iron axe", Category = "Iron", LevelRequired = 16, Experience = 25, ItemId = 1349, Notes = "1 bar" },
        new() { Name = "Iron mace", Category = "Iron", LevelRequired = 17, Experience = 25, ItemId = 1420, Notes = "1 bar" },
        new() { Name = "Iron spit", Category = "Iron", LevelRequired = 17, Experience = 25, Members = true, ItemId = 7225, Notes = "1 bar" },
        new() { Name = "Iron med helm", Category = "Iron", LevelRequired = 18, Experience = 25, ItemId = 1137, Notes = "1 bar" },
        new() { Name = "Iron bolts (unf) ×10", Category = "Iron", LevelRequired = 18, Experience = 25, Members = true, ItemId = 9377, Notes = "1 bar" },
        new() { Name = "Iron sword", Category = "Iron", LevelRequired = 19, Experience = 25, ItemId = 1279, Notes = "1 bar" },
        new() { Name = "Iron dart tip ×10", Category = "Iron", LevelRequired = 19, Experience = 25, Members = true, ItemId = 820, Notes = "1 bar; requires The Tourist Trap" },
        new() { Name = "Iron nails ×15", Category = "Iron", LevelRequired = 19, Experience = 25, Members = true, ItemId = 4820, Notes = "1 bar" },
        new() { Name = "Iron scimitar", Category = "Iron", LevelRequired = 20, Experience = 50, ItemId = 1323, Notes = "2 bars" },
        new() { Name = "Iron spear", Category = "Iron", LevelRequired = 20, Experience = 50, Members = true, ItemId = 1239, Notes = "1 bar + 1 oak log; requires Barbarian Training" },
        new() { Name = "Iron hasta", Category = "Iron", LevelRequired = 20, Experience = 50, Members = true, ItemId = 11369, Notes = "1 bar + 1 oak log; requires Barbarian Training" },
        new() { Name = "Iron arrowtips ×15", Category = "Iron", LevelRequired = 20, Experience = 25, Members = true, ItemId = 40, Notes = "1 bar" },
        new() { Name = "Iron cannonball ×4", Category = "Iron", LevelRequired = 20, Experience = 17, Members = true, Notes = "1 bar; requires Dwarf Cannon" },
        new() { Name = "Iron longsword", Category = "Iron", LevelRequired = 21, Experience = 50, ItemId = 1293, Notes = "2 bars" },
        new() { Name = "Iron javelin tips ×5", Category = "Iron", LevelRequired = 21, Experience = 25, Members = true, Notes = "1 bar" },
        new() { Name = "Iron full helm", Category = "Iron", LevelRequired = 22, Experience = 50, ItemId = 1153, Notes = "2 bars" },
        new() { Name = "Iron knife ×5", Category = "Iron", LevelRequired = 22, Experience = 25, Members = true, ItemId = 863, Notes = "1 bar" },
        new() { Name = "Iron sq shield", Category = "Iron", LevelRequired = 23, Experience = 50, ItemId = 1175, Notes = "2 bars" },
        new() { Name = "Iron limbs", Category = "Iron", LevelRequired = 23, Experience = 25, Members = true, ItemId = 9423, Notes = "1 bar" },
        new() { Name = "Iron warhammer", Category = "Iron", LevelRequired = 24, Experience = 75, ItemId = 1335, Notes = "3 bars" },
        new() { Name = "Iron battleaxe", Category = "Iron", LevelRequired = 25, Experience = 75, ItemId = 1363, Notes = "3 bars" },
        new() { Name = "Iron chainbody", Category = "Iron", LevelRequired = 26, Experience = 75, ItemId = 1101, Notes = "3 bars" },
        new() { Name = "Oil lantern frame", Category = "Iron", LevelRequired = 26, Experience = 25, Members = true, ItemId = 4540, Notes = "1 bar" },
        new() { Name = "Iron kiteshield", Category = "Iron", LevelRequired = 27, Experience = 75, ItemId = 1191, Notes = "3 bars" },
        new() { Name = "Iron claws", Category = "Iron", LevelRequired = 28, Experience = 50, Members = true, ItemId = 3096, Notes = "2 bars; requires Death Plateau" },
        new() { Name = "Iron 2h sword", Category = "Iron", LevelRequired = 29, Experience = 75, ItemId = 1309, Notes = "3 bars" },
        new() { Name = "Iron platelegs", Category = "Iron", LevelRequired = 31, Experience = 75, ItemId = 1067, Notes = "3 bars" },
        new() { Name = "Iron plateskirt", Category = "Iron", LevelRequired = 31, Experience = 75, ItemId = 1081, Notes = "3 bars" },
        new() { Name = "Iron platebody", Category = "Iron", LevelRequired = 33, Experience = 125, ItemId = 1115, Notes = "5 bars" },

        // ── Steel — Anvil items ─────────────────────────────────────────
        new() { Name = "Steel dagger", Category = "Steel", LevelRequired = 30, Experience = 37.5, ItemId = 1207, Notes = "1 bar" },
        new() { Name = "Steel axe", Category = "Steel", LevelRequired = 31, Experience = 37.5, ItemId = 1353, Notes = "1 bar" },
        new() { Name = "Steel mace", Category = "Steel", LevelRequired = 32, Experience = 37.5, ItemId = 1424, Notes = "1 bar" },
        new() { Name = "Steel med helm", Category = "Steel", LevelRequired = 33, Experience = 37.5, ItemId = 1141, Notes = "1 bar" },
        new() { Name = "Steel bolts (unf) ×10", Category = "Steel", LevelRequired = 33, Experience = 37.5, Members = true, ItemId = 9378, Notes = "1 bar" },
        new() { Name = "Steel sword", Category = "Steel", LevelRequired = 34, Experience = 37.5, ItemId = 1281, Notes = "1 bar" },
        new() { Name = "Steel nails ×15", Category = "Steel", LevelRequired = 34, Experience = 37.5, ItemId = 1539, Notes = "1 bar" },
        new() { Name = "Steel dart tip ×10", Category = "Steel", LevelRequired = 34, Experience = 37.5, Members = true, ItemId = 821, Notes = "1 bar; requires The Tourist Trap" },
        new() { Name = "Steel scimitar", Category = "Steel", LevelRequired = 35, Experience = 75, ItemId = 1325, Notes = "2 bars" },
        new() { Name = "Steel spear", Category = "Steel", LevelRequired = 35, Experience = 75, Members = true, ItemId = 1241, Notes = "1 bar + 1 willow log; requires Barbarian Training" },
        new() { Name = "Steel hasta", Category = "Steel", LevelRequired = 35, Experience = 75, Members = true, ItemId = 11371, Notes = "1 bar + 1 willow log; requires Barbarian Training" },
        new() { Name = "Steel arrowtips ×15", Category = "Steel", LevelRequired = 35, Experience = 37.5, Members = true, ItemId = 41, Notes = "1 bar" },
        new() { Name = "Steel cannonball ×4", Category = "Steel", LevelRequired = 35, Experience = 25.6, Members = true, ItemId = 2, Notes = "1 bar; requires Dwarf Cannon" },
        new() { Name = "Steel limbs", Category = "Steel", LevelRequired = 36, Experience = 37.5, Members = true, ItemId = 9425, Notes = "1 bar" },
        new() { Name = "Steel longsword", Category = "Steel", LevelRequired = 36, Experience = 75, ItemId = 1295, Notes = "2 bars" },
        new() { Name = "Steel javelin tips ×5", Category = "Steel", LevelRequired = 36, Experience = 37.5, Members = true, Notes = "1 bar" },
        new() { Name = "Steel studs", Category = "Steel", LevelRequired = 36, Experience = 37.5, Members = true, ItemId = 2370, Notes = "1 bar" },
        new() { Name = "Steel full helm", Category = "Steel", LevelRequired = 37, Experience = 75, ItemId = 1157, Notes = "2 bars" },
        new() { Name = "Steel knife ×5", Category = "Steel", LevelRequired = 37, Experience = 37.5, Members = true, ItemId = 865, Notes = "1 bar" },
        new() { Name = "Steel sq shield", Category = "Steel", LevelRequired = 38, Experience = 75, ItemId = 1177, Notes = "2 bars" },
        new() { Name = "Steel warhammer", Category = "Steel", LevelRequired = 39, Experience = 112.5, ItemId = 1339, Notes = "3 bars" },
        new() { Name = "Steel battleaxe", Category = "Steel", LevelRequired = 40, Experience = 112.5, ItemId = 1365, Notes = "3 bars" },
        new() { Name = "Steel chainbody", Category = "Steel", LevelRequired = 41, Experience = 112.5, ItemId = 1105, Notes = "3 bars" },
        new() { Name = "Steel kiteshield", Category = "Steel", LevelRequired = 42, Experience = 112.5, ItemId = 1193, Notes = "3 bars" },
        new() { Name = "Steel claws", Category = "Steel", LevelRequired = 43, Experience = 75, Members = true, ItemId = 3097, Notes = "2 bars; requires Death Plateau" },
        new() { Name = "Steel 2h sword", Category = "Steel", LevelRequired = 44, Experience = 112.5, ItemId = 1311, Notes = "3 bars" },
        new() { Name = "Steel platelegs", Category = "Steel", LevelRequired = 46, Experience = 112.5, ItemId = 1069, Notes = "3 bars" },
        new() { Name = "Steel plateskirt", Category = "Steel", LevelRequired = 46, Experience = 112.5, ItemId = 1083, Notes = "3 bars" },
        new() { Name = "Steel platebody", Category = "Steel", LevelRequired = 48, Experience = 187.5, ItemId = 1119, Notes = "5 bars" },
        new() { Name = "Bullseye lantern (unf)", Category = "Steel", LevelRequired = 49, Experience = 37.5, Members = true, ItemId = 4544, Notes = "1 bar" },

        // ── Gold — Anvil items (quest only) ─────────────────────────────
        new() { Name = "Gold helmet", Category = "Gold", LevelRequired = 50, Experience = 30, Members = true, Notes = "3 bars; requires Between a Rock..." },
        new() { Name = "Gold bowl", Category = "Gold", LevelRequired = 50, Experience = 30, Members = true, Notes = "2 bars; requires Legends' Quest", QuestRequirement = "Legends' Quest" },

        // ── Mithril — Anvil items ───────────────────────────────────────
        new() { Name = "Mithril dagger", Category = "Mithril", LevelRequired = 50, Experience = 50, ItemId = 1209, Notes = "1 bar" },
        new() { Name = "Mithril axe", Category = "Mithril", LevelRequired = 51, Experience = 50, ItemId = 1355, Notes = "1 bar" },
        new() { Name = "Mithril mace", Category = "Mithril", LevelRequired = 52, Experience = 50, ItemId = 1428, Notes = "1 bar" },
        new() { Name = "Mithril med helm", Category = "Mithril", LevelRequired = 53, Experience = 50, ItemId = 1143, Notes = "1 bar" },
        new() { Name = "Mithril bolts (unf) ×10", Category = "Mithril", LevelRequired = 53, Experience = 50, Members = true, ItemId = 9379, Notes = "1 bar" },
        new() { Name = "Mithril sword", Category = "Mithril", LevelRequired = 54, Experience = 50, ItemId = 1285, Notes = "1 bar" },
        new() { Name = "Mithril nails ×15", Category = "Mithril", LevelRequired = 54, Experience = 50, Members = true, ItemId = 4822, Notes = "1 bar" },
        new() { Name = "Mithril dart tip ×10", Category = "Mithril", LevelRequired = 54, Experience = 50, Members = true, ItemId = 822, Notes = "1 bar; requires The Tourist Trap" },
        new() { Name = "Mithril cannonball ×4", Category = "Mithril", LevelRequired = 55, Experience = 34, Members = true, Notes = "1 bar; requires Dwarf Cannon" },
        new() { Name = "Mithril scimitar", Category = "Mithril", LevelRequired = 55, Experience = 100, ItemId = 1329, Notes = "2 bars" },
        new() { Name = "Mithril spear", Category = "Mithril", LevelRequired = 55, Experience = 100, Members = true, ItemId = 1243, Notes = "1 bar + 1 maple log; requires Barbarian Training" },
        new() { Name = "Mithril hasta", Category = "Mithril", LevelRequired = 55, Experience = 100, Members = true, ItemId = 11373, Notes = "1 bar + 1 maple log; requires Barbarian Training" },
        new() { Name = "Mithril arrowtips ×15", Category = "Mithril", LevelRequired = 55, Experience = 50, Members = true, ItemId = 42, Notes = "1 bar" },
        new() { Name = "Mithril limbs", Category = "Mithril", LevelRequired = 56, Experience = 50, Members = true, ItemId = 9427, Notes = "1 bar" },
        new() { Name = "Mithril longsword", Category = "Mithril", LevelRequired = 56, Experience = 100, ItemId = 1299, Notes = "2 bars" },
        new() { Name = "Mithril javelin tips ×5", Category = "Mithril", LevelRequired = 56, Experience = 50, Members = true, Notes = "1 bar" },
        new() { Name = "Mithril full helm", Category = "Mithril", LevelRequired = 57, Experience = 100, ItemId = 1159, Notes = "2 bars" },
        new() { Name = "Mithril knife ×5", Category = "Mithril", LevelRequired = 57, Experience = 50, Members = true, ItemId = 866, Notes = "1 bar" },
        new() { Name = "Mithril sq shield", Category = "Mithril", LevelRequired = 58, Experience = 100, ItemId = 1181, Notes = "2 bars" },
        new() { Name = "Mithril warhammer", Category = "Mithril", LevelRequired = 59, Experience = 150, ItemId = 1343, Notes = "3 bars" },
        new() { Name = "Mith grapple tip", Category = "Mithril", LevelRequired = 59, Experience = 50, Members = true, ItemId = 9416, Notes = "1 bar" },
        new() { Name = "Mithril battleaxe", Category = "Mithril", LevelRequired = 60, Experience = 150, ItemId = 1369, Notes = "3 bars" },
        new() { Name = "Mithril chainbody", Category = "Mithril", LevelRequired = 61, Experience = 150, ItemId = 1109, Notes = "3 bars" },
        new() { Name = "Mithril kiteshield", Category = "Mithril", LevelRequired = 62, Experience = 150, ItemId = 1197, Notes = "3 bars" },
        new() { Name = "Mithril claws", Category = "Mithril", LevelRequired = 63, Experience = 100, Members = true, ItemId = 3099, Notes = "2 bars; requires Death Plateau" },
        new() { Name = "Mithril 2h sword", Category = "Mithril", LevelRequired = 64, Experience = 150, ItemId = 1315, Notes = "3 bars" },
        new() { Name = "Mithril platelegs", Category = "Mithril", LevelRequired = 66, Experience = 150, ItemId = 1071, Notes = "3 bars" },
        new() { Name = "Mithril plateskirt", Category = "Mithril", LevelRequired = 66, Experience = 150, ItemId = 1085, Notes = "3 bars" },
        new() { Name = "Mithril platebody", Category = "Mithril", LevelRequired = 68, Experience = 250, ItemId = 1121, Notes = "5 bars" },

        // ── Adamant — Anvil items ───────────────────────────────────────
        new() { Name = "Adamant dagger", Category = "Adamant", LevelRequired = 70, Experience = 62.5, ItemId = 1211, Notes = "1 bar" },
        new() { Name = "Adamant axe", Category = "Adamant", LevelRequired = 71, Experience = 62.5, ItemId = 1357, Notes = "1 bar" },
        new() { Name = "Adamant mace", Category = "Adamant", LevelRequired = 72, Experience = 62.5, ItemId = 1430, Notes = "1 bar" },
        new() { Name = "Adamant med helm", Category = "Adamant", LevelRequired = 73, Experience = 62.5, ItemId = 1145, Notes = "1 bar" },
        new() { Name = "Adamant bolts (unf) ×10", Category = "Adamant", LevelRequired = 73, Experience = 62.5, Members = true, ItemId = 9380, Notes = "1 bar" },
        new() { Name = "Adamant sword", Category = "Adamant", LevelRequired = 74, Experience = 62.5, ItemId = 1287, Notes = "1 bar" },
        new() { Name = "Adamantite nails ×15", Category = "Adamant", LevelRequired = 74, Experience = 62.5, Members = true, ItemId = 4823, Notes = "1 bar" },
        new() { Name = "Adamant dart tip ×10", Category = "Adamant", LevelRequired = 74, Experience = 62.5, Members = true, ItemId = 823, Notes = "1 bar; requires The Tourist Trap" },
        new() { Name = "Adamant scimitar", Category = "Adamant", LevelRequired = 75, Experience = 125, ItemId = 1331, Notes = "2 bars" },
        new() { Name = "Adamant spear", Category = "Adamant", LevelRequired = 75, Experience = 125, Members = true, ItemId = 1245, Notes = "1 bar + 1 yew log; requires Barbarian Training" },
        new() { Name = "Adamant hasta", Category = "Adamant", LevelRequired = 75, Experience = 125, Members = true, ItemId = 11375, Notes = "1 bar + 1 yew log; requires Barbarian Training" },
        new() { Name = "Adamant arrowtips ×15", Category = "Adamant", LevelRequired = 75, Experience = 62.5, Members = true, ItemId = 43, Notes = "1 bar" },
        new() { Name = "Adamant cannonball ×4", Category = "Adamant", LevelRequired = 75, Experience = 42.5, Members = true, Notes = "1 bar; requires Dwarf Cannon" },
        new() { Name = "Adamantite limbs", Category = "Adamant", LevelRequired = 76, Experience = 62.5, Members = true, ItemId = 9429, Notes = "1 bar" },
        new() { Name = "Adamant longsword", Category = "Adamant", LevelRequired = 76, Experience = 125, ItemId = 1301, Notes = "2 bars" },
        new() { Name = "Adamant javelin tips ×5", Category = "Adamant", LevelRequired = 76, Experience = 62.5, Members = true, Notes = "1 bar" },
        new() { Name = "Adamant full helm", Category = "Adamant", LevelRequired = 77, Experience = 125, ItemId = 1161, Notes = "2 bars" },
        new() { Name = "Adamant knife ×5", Category = "Adamant", LevelRequired = 77, Experience = 62.5, Members = true, ItemId = 867, Notes = "1 bar" },
        new() { Name = "Adamant sq shield", Category = "Adamant", LevelRequired = 78, Experience = 125, ItemId = 1183, Notes = "2 bars" },
        new() { Name = "Adamant warhammer", Category = "Adamant", LevelRequired = 79, Experience = 187.5, ItemId = 1345, Notes = "3 bars" },
        new() { Name = "Adamant battleaxe", Category = "Adamant", LevelRequired = 80, Experience = 187.5, ItemId = 1371, Notes = "3 bars" },
        new() { Name = "Adamant chainbody", Category = "Adamant", LevelRequired = 81, Experience = 187.5, ItemId = 1111, Notes = "3 bars" },
        new() { Name = "Adamant kiteshield", Category = "Adamant", LevelRequired = 82, Experience = 187.5, ItemId = 1199, Notes = "3 bars" },
        new() { Name = "Adamant claws", Category = "Adamant", LevelRequired = 83, Experience = 125, Members = true, ItemId = 3100, Notes = "2 bars; requires Death Plateau" },
        new() { Name = "Adamant 2h sword", Category = "Adamant", LevelRequired = 84, Experience = 187.5, ItemId = 1317, Notes = "3 bars" },
        new() { Name = "Adamant platelegs", Category = "Adamant", LevelRequired = 86, Experience = 187.5, ItemId = 1073, Notes = "3 bars" },
        new() { Name = "Adamant plateskirt", Category = "Adamant", LevelRequired = 86, Experience = 187.5, ItemId = 1091, Notes = "3 bars" },
        new() { Name = "Adamant platebody", Category = "Adamant", LevelRequired = 88, Experience = 312.5, ItemId = 1123, Notes = "5 bars" },

        // ── Rune — Anvil items ──────────────────────────────────────────
        new() { Name = "Rune dagger", Category = "Rune", LevelRequired = 85, Experience = 75, ItemId = 1213, Notes = "1 bar" },
        new() { Name = "Rune axe", Category = "Rune", LevelRequired = 86, Experience = 75, ItemId = 1359, Notes = "1 bar" },
        new() { Name = "Rune mace", Category = "Rune", LevelRequired = 87, Experience = 75, ItemId = 1432, Notes = "1 bar" },
        new() { Name = "Rune med helm", Category = "Rune", LevelRequired = 88, Experience = 75, ItemId = 1147, Notes = "1 bar" },
        new() { Name = "Runite bolts (unf) ×10", Category = "Rune", LevelRequired = 88, Experience = 75, Members = true, ItemId = 9381, Notes = "1 bar" },
        new() { Name = "Rune sword", Category = "Rune", LevelRequired = 89, Experience = 75, ItemId = 1289, Notes = "1 bar" },
        new() { Name = "Rune nails ×15", Category = "Rune", LevelRequired = 89, Experience = 75, Members = true, ItemId = 4824, Notes = "1 bar" },
        new() { Name = "Rune dart tip ×10", Category = "Rune", LevelRequired = 89, Experience = 75, Members = true, ItemId = 824, Notes = "1 bar; requires The Tourist Trap" },
        new() { Name = "Rune scimitar", Category = "Rune", LevelRequired = 90, Experience = 150, ItemId = 1333, Notes = "2 bars" },
        new() { Name = "Rune spear", Category = "Rune", LevelRequired = 90, Experience = 150, Members = true, ItemId = 1247, Notes = "1 bar + 1 magic log; requires Barbarian Training" },
        new() { Name = "Rune hasta", Category = "Rune", LevelRequired = 90, Experience = 150, Members = true, ItemId = 11377, Notes = "1 bar + 1 magic log; requires Barbarian Training" },
        new() { Name = "Rune arrowtips ×15", Category = "Rune", LevelRequired = 90, Experience = 75, Members = true, ItemId = 44, Notes = "1 bar" },
        new() { Name = "Rune cannonball ×4", Category = "Rune", LevelRequired = 90, Experience = 50.5, Members = true, Notes = "1 bar" },
        new() { Name = "Runite limbs", Category = "Rune", LevelRequired = 91, Experience = 75, Members = true, ItemId = 9431, Notes = "1 bar" },
        new() { Name = "Rune longsword", Category = "Rune", LevelRequired = 91, Experience = 150, ItemId = 1303, Notes = "2 bars" },
        new() { Name = "Rune javelin tips ×5", Category = "Rune", LevelRequired = 91, Experience = 75, Members = true, Notes = "1 bar" },
        new() { Name = "Rune full helm", Category = "Rune", LevelRequired = 92, Experience = 150, ItemId = 1163, Notes = "2 bars" },
        new() { Name = "Rune knife ×5", Category = "Rune", LevelRequired = 92, Experience = 75, Members = true, ItemId = 868, Notes = "1 bar" },
        new() { Name = "Rune sq shield", Category = "Rune", LevelRequired = 93, Experience = 150, ItemId = 1185, Notes = "2 bars" },
        new() { Name = "Rune warhammer", Category = "Rune", LevelRequired = 94, Experience = 225, ItemId = 1347, Notes = "3 bars" },
        new() { Name = "Rune battleaxe", Category = "Rune", LevelRequired = 95, Experience = 225, ItemId = 1373, Notes = "3 bars" },
        new() { Name = "Rune chainbody", Category = "Rune", LevelRequired = 96, Experience = 225, ItemId = 1113, Notes = "3 bars" },
        new() { Name = "Rune kiteshield", Category = "Rune", LevelRequired = 97, Experience = 225, ItemId = 1201, Notes = "3 bars" },
        new() { Name = "Rune claws", Category = "Rune", LevelRequired = 98, Experience = 150, Members = true, ItemId = 3101, Notes = "2 bars; requires Death Plateau" },
        new() { Name = "Rune 2h sword", Category = "Rune", LevelRequired = 99, Experience = 225, ItemId = 1319, Notes = "3 bars" },
        new() { Name = "Rune platelegs", Category = "Rune", LevelRequired = 99, Experience = 225, ItemId = 1079, Notes = "3 bars" },
        new() { Name = "Rune plateskirt", Category = "Rune", LevelRequired = 99, Experience = 225, ItemId = 1093, Notes = "3 bars" },
        new() { Name = "Rune platebody", Category = "Rune", LevelRequired = 99, Experience = 375, ItemId = 1127, Notes = "5 bars" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();
}
    