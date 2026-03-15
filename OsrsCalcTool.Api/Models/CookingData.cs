namespace OsrsCalcTool.Api.Models;

public class CookingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }
    public IReadOnlyList<Ingredient>? Ingredients { get; set; }
    // OutputItemId = the cooked result (same as ItemId); set in static constructor so the frontend
    // can price the output even when Ingredients is also populated.
    public int? OutputItemId { get; set; }
}

public static class CookingData
{
    public static IReadOnlyList<CookingAction> Actions { get; } =
    [
        // ── Meat / Fish ──────────────────────────────────────────────
        new() { Name = "Cooked meat", Category = "Meat / Fish", LevelRequired = 1, Experience = 30, ItemId = 2142 },
        new() { Name = "Sinew", Category = "Meat / Fish", LevelRequired = 1, Experience = 3, Members = true, ItemId = 9436, Notes = "Use raw beef on range with empty pot" },
        new() { Name = "Shrimps", Category = "Meat / Fish", LevelRequired = 1, Experience = 30, ItemId = 315 },
        new() { Name = "Cooked chicken", Category = "Meat / Fish", LevelRequired = 1, Experience = 30, ItemId = 2140 },
        new() { Name = "Cooked rabbit", Category = "Meat / Fish", LevelRequired = 1, Experience = 30, Members = true, ItemId = 3228 },
        new() { Name = "Anchovies", Category = "Meat / Fish", LevelRequired = 1, Experience = 30, ItemId = 319 },
        new() { Name = "Sardine", Category = "Meat / Fish", LevelRequired = 1, Experience = 40, ItemId = 325 },
        new() { Name = "Poison karambwan", Category = "Meat / Fish", LevelRequired = 1, Experience = 80, Members = true, ItemId = 3146 },
        new() { Name = "Ugthanki meat", Category = "Meat / Fish", LevelRequired = 1, Experience = 40, Members = true, ItemId = 1861 },
        new() { Name = "Herring", Category = "Meat / Fish", LevelRequired = 5, Experience = 50, ItemId = 347 },
        new() { Name = "Guppy", Category = "Meat / Fish", LevelRequired = 7, Experience = 12, Notes = "Sailing content" },
        new() { Name = "Mackerel", Category = "Meat / Fish", LevelRequired = 10, Experience = 60, Members = true, ItemId = 355 },
        new() { Name = "Roast bird meat", Category = "Meat / Fish", LevelRequired = 11, Experience = 60, Members = true, ItemId = 9980, Notes = "Iron spit required" },
        new() { Name = "Thin snail", Category = "Meat / Fish", LevelRequired = 12, Experience = 70, Members = true, ItemId = 3369 },
        new() { Name = "Trout", Category = "Meat / Fish", LevelRequired = 15, Experience = 70, ItemId = 333 },
        new() { Name = "Spider on stick", Category = "Meat / Fish", LevelRequired = 16, Experience = 80, Members = true, ItemId = 6297 },
        new() { Name = "Spider on shaft", Category = "Meat / Fish", LevelRequired = 16, Experience = 80, Members = true, ItemId = 6299 },
        new() { Name = "Roast rabbit", Category = "Meat / Fish", LevelRequired = 16, Experience = 70, Members = true, ItemId = 7223, Notes = "Iron spit required" },
        new() { Name = "Lean snail", Category = "Meat / Fish", LevelRequired = 17, Experience = 80, Members = true, ItemId = 3371 },
        new() { Name = "Cod", Category = "Meat / Fish", LevelRequired = 18, Experience = 75, Members = true, ItemId = 339 },
        new() { Name = "Pike", Category = "Meat / Fish", LevelRequired = 20, Experience = 80, ItemId = 351 },
        new() { Name = "Cavefish", Category = "Meat / Fish", LevelRequired = 20, Experience = 23, Notes = "Sailing content" },
        new() { Name = "Roast beast meat", Category = "Meat / Fish", LevelRequired = 21, Experience = 82.5, Members = true, ItemId = 9988, Notes = "Iron spit required" },
        new() { Name = "Red crab meat", Category = "Meat / Fish", LevelRequired = 21, Experience = 85, Members = true, Notes = "Sailing content" },
        new() { Name = "Cooked giant crab meat", Category = "Meat / Fish", LevelRequired = 21, Experience = 100, Members = true, Notes = "Sailing content" },
        new() { Name = "Fat snail", Category = "Meat / Fish", LevelRequired = 22, Experience = 95, Members = true, ItemId = 3373 },
        new() { Name = "Cooked wild kebbit", Category = "Meat / Fish", LevelRequired = 23, Experience = 73, Members = true, ItemId = 9964 },
        new() { Name = "Salmon", Category = "Meat / Fish", LevelRequired = 25, Experience = 90, ItemId = 329 },
        new() { Name = "Slimy eel", Category = "Meat / Fish", LevelRequired = 28, Experience = 95, Members = true, ItemId = 3381 },
        new() { Name = "Tuna", Category = "Meat / Fish", LevelRequired = 30, Experience = 100, ItemId = 361 },
        new() { Name = "Cooked karambwan", Category = "Meat / Fish", LevelRequired = 30, Experience = 190, Members = true, ItemId = 3144 },
        new() { Name = "Cooked chompy", Category = "Meat / Fish", LevelRequired = 30, Experience = 100, Members = true, ItemId = 2878, Notes = "Iron spit required" },
        new() { Name = "Cooked fishcake", Category = "Meat / Fish", LevelRequired = 31, Experience = 100, Members = true, ItemId = 7530 },
        new() { Name = "Cooked larupia", Category = "Meat / Fish", LevelRequired = 31, Experience = 92, Members = true, ItemId = 9966 },
        new() { Name = "Cooked barb-tailed kebbit", Category = "Meat / Fish", LevelRequired = 32, Experience = 106, Members = true, ItemId = 9968 },
        new() { Name = "Tetra", Category = "Meat / Fish", LevelRequired = 33, Experience = 31, Notes = "Sailing content" },
        new() { Name = "Rainbow fish", Category = "Meat / Fish", LevelRequired = 35, Experience = 110, Members = true, ItemId = 10136 },
        new() { Name = "Cave eel", Category = "Meat / Fish", LevelRequired = 38, Experience = 115, Members = true, ItemId = 5003 },
        new() { Name = "Lobster", Category = "Meat / Fish", LevelRequired = 40, Experience = 120, ItemId = 379 },
        new() { Name = "Cooked jubbly", Category = "Meat / Fish", LevelRequired = 41, Experience = 160, Members = true, ItemId = 7568 },
        new() { Name = "Cooked graahk", Category = "Meat / Fish", LevelRequired = 41, Experience = 124, Members = true, ItemId = 9970 },
        new() { Name = "Bass", Category = "Meat / Fish", LevelRequired = 43, Experience = 130, Members = true, ItemId = 365 },
        new() { Name = "Swordfish", Category = "Meat / Fish", LevelRequired = 45, Experience = 140, ItemId = 373 },
        new() { Name = "Catfish", Category = "Meat / Fish", LevelRequired = 46, Experience = 43, Members = true, Notes = "Sailing content" },
        new() { Name = "Cooked kyatt", Category = "Meat / Fish", LevelRequired = 51, Experience = 143, Members = true, ItemId = 9972 },
        new() { Name = "Lava eel", Category = "Meat / Fish", LevelRequired = 53, Experience = 30, Members = true, ItemId = 2149 },
        new() { Name = "Swordtip squid", Category = "Meat / Fish", LevelRequired = 56, Experience = 150, Members = true, Notes = "Sailing content" },
        new() { Name = "Cooked pyre fox", Category = "Meat / Fish", LevelRequired = 59, Experience = 154, Members = true },
        new() { Name = "Monkfish", Category = "Meat / Fish", LevelRequired = 62, Experience = 150, Members = true, ItemId = 7946 },
        new() { Name = "Cooked sunlight antelope", Category = "Meat / Fish", LevelRequired = 68, Experience = 175, Members = true },
        new() { Name = "Giant krill", Category = "Meat / Fish", LevelRequired = 69, Experience = 177.5, Members = true, Notes = "Sailing content" },
        new() { Name = "Jumbo squid", Category = "Meat / Fish", LevelRequired = 71, Experience = 180, Members = true, Notes = "Sailing content" },
        new() { Name = "Sacred eel", Category = "Meat / Fish", LevelRequired = 72, Experience = 109, Members = true, Notes = "Variable XP (109-124); use knife to process" },
        new() { Name = "Haddock", Category = "Meat / Fish", LevelRequired = 73, Experience = 180, Members = true, Notes = "Sailing content" },
        new() { Name = "Yellowfin", Category = "Meat / Fish", LevelRequired = 79, Experience = 200, Members = true, Notes = "Sailing content" },
        new() { Name = "Shark", Category = "Meat / Fish", LevelRequired = 80, Experience = 210, Members = true, ItemId = 385 },
        new() { Name = "Sea turtle", Category = "Meat / Fish", LevelRequired = 82, Experience = 211.3, Members = true, ItemId = 397 },
        new() { Name = "Cooked dashing kebbit", Category = "Meat / Fish", LevelRequired = 82, Experience = 215, Members = true },
        new() { Name = "Halibut", Category = "Meat / Fish", LevelRequired = 83, Experience = 212.5, Members = true, Notes = "Sailing content" },
        new() { Name = "Anglerfish", Category = "Meat / Fish", LevelRequired = 84, Experience = 230, Members = true, ItemId = 13441 },
        new() { Name = "Bluefin", Category = "Meat / Fish", LevelRequired = 87, Experience = 215, Members = true, Notes = "Sailing content" },
        new() { Name = "Dark crab", Category = "Meat / Fish", LevelRequired = 90, Experience = 215, Members = true, ItemId = 11936 },
        new() { Name = "Manta ray", Category = "Meat / Fish", LevelRequired = 91, Experience = 216.2, Members = true, ItemId = 391 },
        new() { Name = "Marlin", Category = "Meat / Fish", LevelRequired = 91, Experience = 225, Members = true, Notes = "Sailing content" },
        new() { Name = "Cooked moonlight antelope", Category = "Meat / Fish", LevelRequired = 92, Experience = 220, Members = true },

        // ── Bread ────────────────────────────────────────────────────
        new() { Name = "Bread", Category = "Bread", LevelRequired = 1, Experience = 40, ItemId = 2309 },
        new() { Name = "Pitta bread", Category = "Bread", LevelRequired = 58, Experience = 40, Members = true, ItemId = 1865 },

        // ── Pies ─────────────────────────────────────────────────────
        new() { Name = "Redberry pie", Category = "Pie", LevelRequired = 10, Experience = 78, ItemId = 2325 },
        new() { Name = "Meat pie", Category = "Pie", LevelRequired = 20, Experience = 110, ItemId = 2327 },
        new() { Name = "Mud pie", Category = "Pie", LevelRequired = 29, Experience = 128, Members = true, ItemId = 7170, Notes = "Thrown at enemies; does not heal" },
        new() { Name = "Apple pie", Category = "Pie", LevelRequired = 30, Experience = 130, ItemId = 2323 },
        new() { Name = "Garden pie", Category = "Pie", LevelRequired = 34, Experience = 138, Members = true, ItemId = 7178, Notes = "+3 Farming boost" },
        new() { Name = "Fish pie", Category = "Pie", LevelRequired = 47, Experience = 164, Members = true, ItemId = 7188, Notes = "+3 Fishing boost" },
        new() { Name = "Botanical pie", Category = "Pie", LevelRequired = 52, Experience = 180, Members = true, ItemId = 19662, Notes = "+4 Herblore boost" },
        new() { Name = "Mushroom pie", Category = "Pie", LevelRequired = 60, Experience = 200, Members = true, ItemId = 7198, Notes = "+4 Crafting boost" },
        new() { Name = "Admiral pie", Category = "Pie", LevelRequired = 70, Experience = 210, Members = true, ItemId = 7208, Notes = "+5 Fishing boost" },
        new() { Name = "Dragonfruit pie", Category = "Pie", LevelRequired = 73, Experience = 220, Members = true, ItemId = 22795, Notes = "+4 Fletching boost" },
        new() { Name = "Wild pie", Category = "Pie", LevelRequired = 85, Experience = 240, Members = true, ItemId = 7218, Notes = "+4 Ranged, +5 Slayer boost" },
        new() { Name = "Summer pie", Category = "Pie", LevelRequired = 95, Experience = 260, Members = true, ItemId = 7228, Notes = "+5 Agility boost" },

        // ── Stews ────────────────────────────────────────────────────
        new() { Name = "Stew", Category = "Stew", LevelRequired = 25, Experience = 117, ItemId = 2003 },
        new() { Name = "Curry", Category = "Stew", LevelRequired = 60, Experience = 280, Members = true, ItemId = 2011 },

        // ── Pizzas ───────────────────────────────────────────────────
        new() { Name = "Plain pizza", Category = "Pizza", LevelRequired = 35, Experience = 143, ItemId = 2289 },
        new() { Name = "Meat pizza", Category = "Pizza", LevelRequired = 45, Experience = 169, ItemId = 2293 },
        new() { Name = "Anchovy pizza", Category = "Pizza", LevelRequired = 55, Experience = 182, ItemId = 2297 },
        new() { Name = "Pineapple pizza", Category = "Pizza", LevelRequired = 65, Experience = 195, Members = true, ItemId = 2301 },

        // ── Cakes ────────────────────────────────────────────────────
        new() { Name = "Cake", Category = "Cake", LevelRequired = 40, Experience = 180, ItemId = 1891 },
        new() { Name = "Chocolate cake", Category = "Cake", LevelRequired = 50, Experience = 210, ItemId = 1897, Notes = "Add chocolate bar to cake" },

        // ── Wine ─────────────────────────────────────────────────────
        new() { Name = "Jug of wine", Category = "Wine", LevelRequired = 35, Experience = 200, ItemId = 1993 },
        new() { Name = "Wine of zamorak", Category = "Wine", LevelRequired = 65, Experience = 200, Members = true, ItemId = 245 },

        // ── Hot Drinks ───────────────────────────────────────────────
        new() { Name = "Cup of tea", Category = "Hot Drink", LevelRequired = 20, Experience = 52, Members = true, ItemId = 4838, Notes = "Nettle tea; restores 5% run energy" },

        // ── Vegetable ────────────────────────────────────────────────
        new() { Name = "Baked potato", Category = "Vegetable", LevelRequired = 7, Experience = 15, Members = true, ItemId = 6701 },
        new() { Name = "Spicy sauce", Category = "Vegetable", LevelRequired = 9, Experience = 25, Members = true, ItemId = 7072 },
        new() { Name = "Chilli con carne", Category = "Vegetable", LevelRequired = 11, Experience = 25, Members = true, ItemId = 7062 },
        new() { Name = "Scrambled egg", Category = "Vegetable", LevelRequired = 13, Experience = 50, Members = true, ItemId = 7078 },
        new() { Name = "Egg and tomato", Category = "Vegetable", LevelRequired = 23, Experience = 0, Members = true, ItemId = 7064, Notes = "No cooking XP for combining" },
        new() { Name = "Cooked sweetcorn", Category = "Vegetable", LevelRequired = 28, Experience = 104, Members = true, ItemId = 5988 },
        new() { Name = "Potato with butter", Category = "Vegetable", LevelRequired = 39, Experience = 40, Members = true, ItemId = 6703 },
        new() { Name = "Chilli potato", Category = "Vegetable", LevelRequired = 41, Experience = 15, Members = true, ItemId = 7054 },
        new() { Name = "Fried onions", Category = "Vegetable", LevelRequired = 42, Experience = 60, Members = true, ItemId = 7084 },
        new() { Name = "Fried mushrooms", Category = "Vegetable", LevelRequired = 46, Experience = 60, Members = true, ItemId = 7082 },
        new() { Name = "Potato with cheese", Category = "Vegetable", LevelRequired = 47, Experience = 40, Members = true, ItemId = 6705 },
        new() { Name = "Egg potato", Category = "Vegetable", LevelRequired = 51, Experience = 45, Members = true, ItemId = 7056 },
        new() { Name = "Mushroom & onion", Category = "Vegetable", LevelRequired = 57, Experience = 120, Members = true, ItemId = 7066 },
        new() { Name = "Mushroom potato", Category = "Vegetable", LevelRequired = 64, Experience = 55, Members = true, ItemId = 7058 },
        new() { Name = "Tuna and corn", Category = "Vegetable", LevelRequired = 67, Experience = 0, Members = true, ItemId = 7068, Notes = "No cooking XP for combining" },
        new() { Name = "Tuna potato", Category = "Vegetable", LevelRequired = 68, Experience = 10, Members = true, ItemId = 7060 },

        // ── Dairy ────────────────────────────────────────────────────
        new() { Name = "Pot of cream", Category = "Dairy", LevelRequired = 21, Experience = 18, Members = true, ItemId = 2130, Notes = "Made at dairy churn" },
        new() { Name = "Pat of butter", Category = "Dairy", LevelRequired = 38, Experience = 40.5, Members = true, ItemId = 6697, Notes = "Made at dairy churn" },
        new() { Name = "Cheese", Category = "Dairy", LevelRequired = 48, Experience = 64, Members = true, ItemId = 1985, Notes = "Made at dairy churn" },

        // ── Kebabs ───────────────────────────────────────────────────
        new() { Name = "Ugthanki kebab", Category = "Kebab", LevelRequired = 1, Experience = 40, Members = true, ItemId = 1883 },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    private static readonly Dictionary<int, IReadOnlyList<Ingredient>> IngredientsByOutput = new()
    {
        // Meat / Fish
        [2142]  = [new("Raw beef", 2132)],
        [9436]  = [new("Raw beef", 2132)],
        [315]   = [new("Raw shrimps", 317)],
        [2140]  = [new("Raw chicken", 2138)],
        [3228]  = [new("Raw rabbit", 3226)],
        [319]   = [new("Raw anchovies", 321)],
        [325]   = [new("Raw sardine", 327)],
        [3146]  = [new("Raw karambwan", 3142)],
        [1861]  = [new("Raw ugthanki meat", 1859)],
        [347]   = [new("Raw herring", 345)],
        [355]   = [new("Raw mackerel", 353)],
        [3369]  = [new("Thin snail meat", 3363)],
        [333]   = [new("Raw trout", 335)],
        [3371]  = [new("Lean snail meat", 3365)],
        [339]   = [new("Raw cod", 341)],
        [351]   = [new("Raw pike", 349)],
        [3373]  = [new("Fat snail meat", 3367)],
        [329]   = [new("Raw salmon", 331)],
        [3381]  = [new("Raw slimy eel", 3379)],
        [361]   = [new("Raw tuna", 359)],
        [3144]  = [new("Raw karambwan", 3142)],
        [10136] = [new("Raw rainbow fish", 10138)],
        [5003]  = [new("Raw cave eel", 5001)],
        [379]   = [new("Raw lobster", 377)],
        [365]   = [new("Raw bass", 363)],
        [373]   = [new("Raw swordfish", 371)],
        [2149]  = [new("Raw lava eel", 2148)],
        [7946]  = [new("Raw monkfish", 7944)],
        [385]   = [new("Raw shark", 383)],
        [397]   = [new("Raw sea turtle", 395)],
        [13441] = [new("Raw anglerfish", 13439)],
        [11936] = [new("Raw dark crab", 11934)],
        [391]   = [new("Raw manta ray", 389)],

        // Bread
        [2309] = [new("Bread dough", 2307)],
        [1865] = [new("Pitta dough", 1863)],

        // Pies
        [2325]  = [new("Uncooked berry pie", 2321)],
        [2327]  = [new("Uncooked meat pie", 2319)],
        [7170]  = [new("Raw mud pie", 7168)],
        [2323]  = [new("Uncooked apple pie", 2317)],
        [7178]  = [new("Raw garden pie", 7176)],
        [7188]  = [new("Raw fish pie", 7186)],
        [19662] = [new("Uncooked botanical pie", 19660)],
        [7198]  = [new("Raw mushroom pie", 7196)],
        [7208]  = [new("Raw admiral pie", 7206)],
        [22795] = [new("Raw dragonfruit pie", 22793)],
        [7218]  = [new("Raw wild pie", 7216)],
        [7228]  = [new("Raw summer pie", 7226)],

        // Stews
        [2003] = [new("Uncooked stew", 2001)],
        [2011] = [new("Uncooked curry", 2009)],

        // Pizzas
        [2289] = [new("Uncooked pizza", 2287)],

        // Cakes
        [1891] = [new("Uncooked cake", 1889)],

        // Wine
        [1993] = [new("Grapes", 1987), new("Jug of water", 1937)],

        // Vegetable
        [6701] = [new("Potato", 1942)],
        [5988] = [new("Sweetcorn", 5986)],
        [6703] = [new("Baked potato", 6701), new("Pat of butter", 6697)],
        [6705] = [new("Baked potato", 6701), new("Cheese", 1985)],
    };

    public static IReadOnlyList<Ingredient> GetIngredients(CookingAction action)
    {
        if (action.ItemId.HasValue && IngredientsByOutput.TryGetValue(action.ItemId.Value, out var ingredients))
            return ingredients;
        return [];
    }

    public static IEnumerable<int> AllItemIds =>
        Actions.Select(a => a.ItemId)
            .Concat(IngredientsByOutput.Values.SelectMany(ings => ings.Select(i => i.ItemId)))
            .Where(id => id.HasValue)
            .Select(id => id!.Value)
            .Distinct();

    static CookingData()
    {
        foreach (var action in Actions)
        {
            if (action.ItemId.HasValue && IngredientsByOutput.TryGetValue(action.ItemId.Value, out var ings))
            {
                action.Ingredients = ings;
                // ItemId is the cooked output; expose it as OutputItemId so the frontend
                // can calculate output value even when Ingredients is populated.
                action.OutputItemId = action.ItemId;
            }
        }
    }
}
