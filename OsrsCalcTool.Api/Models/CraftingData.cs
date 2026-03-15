namespace OsrsCalcTool.Api.Models;

public class CraftingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }
    /// <summary>Ingredients consumed to make this item. Set by the static constructor.</summary>
    public IReadOnlyList<Ingredient>? Ingredients { get; set; }
    /// <summary>GE-priceable output item id (= ItemId). Set by the static constructor.</summary>
    public int? OutputItemId { get; set; }
}

public static class CraftingData
{
    public static IReadOnlyList<CraftingAction> Actions { get; } =
    [
        // ── Leather ─────────────────────────────────────────────────────
        new() { Name = "Leather gloves", Category = "Leather", LevelRequired = 1, Experience = 13.8, ItemId = 1059 },
        new() { Name = "Leather boots", Category = "Leather", LevelRequired = 7, Experience = 16.3, ItemId = 1061 },
        new() { Name = "Leather cowl", Category = "Leather", LevelRequired = 9, Experience = 18.5, ItemId = 1167 },
        new() { Name = "Leather vambraces", Category = "Leather", LevelRequired = 11, Experience = 22, ItemId = 1063 },
        new() { Name = "Leather body", Category = "Leather", LevelRequired = 14, Experience = 25, ItemId = 1129 },
        new() { Name = "Leather chaps", Category = "Leather", LevelRequired = 18, Experience = 27, ItemId = 1095 },
        new() { Name = "Coif", Category = "Leather", LevelRequired = 38, Experience = 37, ItemId = 1169 },
        new() { Name = "Hardleather body", Category = "Leather", LevelRequired = 28, Experience = 35, ItemId = 1131 },
        new() { Name = "Studded body", Category = "Leather", LevelRequired = 41, Experience = 40, ItemId = 1133, Notes = "Leather body + Steel studs" },
        new() { Name = "Studded chaps", Category = "Leather", LevelRequired = 44, Experience = 42, ItemId = 1097, Notes = "Leather chaps + Steel studs" },

        // ── Dragonhide ──────────────────────────────────────────────────
        new() { Name = "Green d'hide vambraces", Category = "Dragonhide", LevelRequired = 57, Experience = 62, Members = true, ItemId = 1065 },
        new() { Name = "Green d'hide chaps", Category = "Dragonhide", LevelRequired = 60, Experience = 124, Members = true, ItemId = 1099 },
        new() { Name = "Green d'hide body", Category = "Dragonhide", LevelRequired = 63, Experience = 186, Members = true, ItemId = 1135 },
        new() { Name = "Green d'hide shield", Category = "Dragonhide", LevelRequired = 64, Experience = 124, Members = true, ItemId = 22272 },
        new() { Name = "Blue d'hide vambraces", Category = "Dragonhide", LevelRequired = 66, Experience = 70, Members = true, ItemId = 2487 },
        new() { Name = "Blue d'hide chaps", Category = "Dragonhide", LevelRequired = 68, Experience = 140, Members = true, ItemId = 2493 },
        new() { Name = "Blue d'hide body", Category = "Dragonhide", LevelRequired = 71, Experience = 210, Members = true, ItemId = 2499 },
        new() { Name = "Blue d'hide shield", Category = "Dragonhide", LevelRequired = 72, Experience = 140, Members = true, ItemId = 22275 },
        new() { Name = "Red d'hide vambraces", Category = "Dragonhide", LevelRequired = 73, Experience = 78, Members = true, ItemId = 2489 },
        new() { Name = "Red d'hide chaps", Category = "Dragonhide", LevelRequired = 75, Experience = 156, Members = true, ItemId = 2495 },
        new() { Name = "Red d'hide body", Category = "Dragonhide", LevelRequired = 77, Experience = 234, Members = true, ItemId = 2501 },
        new() { Name = "Red d'hide shield", Category = "Dragonhide", LevelRequired = 78, Experience = 156, Members = true, ItemId = 22278 },
        new() { Name = "Black d'hide vambraces", Category = "Dragonhide", LevelRequired = 79, Experience = 86, Members = true, ItemId = 2491 },
        new() { Name = "Black d'hide chaps", Category = "Dragonhide", LevelRequired = 82, Experience = 172, Members = true, ItemId = 2497 },
        new() { Name = "Black d'hide body", Category = "Dragonhide", LevelRequired = 84, Experience = 258, Members = true, ItemId = 2503 },
        new() { Name = "Black d'hide shield", Category = "Dragonhide", LevelRequired = 85, Experience = 172, Members = true, ItemId = 22281 },

        // ── Gem cutting ─────────────────────────────────────────────────
        new() { Name = "Opal", Category = "Gem", LevelRequired = 1, Experience = 15, ItemId = 1609 },
        new() { Name = "Jade", Category = "Gem", LevelRequired = 13, Experience = 20, ItemId = 1611 },
        new() { Name = "Red topaz", Category = "Gem", LevelRequired = 16, Experience = 25, ItemId = 1613 },
        new() { Name = "Sapphire", Category = "Gem", LevelRequired = 20, Experience = 50, ItemId = 1607 },
        new() { Name = "Emerald", Category = "Gem", LevelRequired = 27, Experience = 67.5, ItemId = 1605 },
        new() { Name = "Ruby", Category = "Gem", LevelRequired = 34, Experience = 85, ItemId = 1603 },
        new() { Name = "Diamond", Category = "Gem", LevelRequired = 43, Experience = 107.5, ItemId = 1601 },
        new() { Name = "Dragonstone", Category = "Gem", LevelRequired = 55, Experience = 137.5, Members = true, ItemId = 1615 },
        new() { Name = "Onyx", Category = "Gem", LevelRequired = 67, Experience = 167.5, Members = true, ItemId = 6573 },
        new() { Name = "Zenyte", Category = "Gem", LevelRequired = 89, Experience = 200, Members = true, ItemId = 19493 },

        // ── Silver jewellery ────────────────────────────────────────────
        new() { Name = "Unstrung symbol", Category = "Silver Jewellery", LevelRequired = 16, Experience = 50, ItemId = 1714 },
        new() { Name = "Silver sickle", Category = "Silver Jewellery", LevelRequired = 18, Experience = 50, Members = true, ItemId = 2961 },
        new() { Name = "Tiara", Category = "Silver Jewellery", LevelRequired = 23, Experience = 52.5, ItemId = 5525 },
        new() { Name = "Silver bolts (unf) (×10)", Category = "Silver Jewellery", LevelRequired = 21, Experience = 50, Members = true, ItemId = 9382 },

        // ── Gold jewellery ──────────────────────────────────────────────
        new() { Name = "Gold ring", Category = "Gold Jewellery", LevelRequired = 5, Experience = 15, ItemId = 1635 },
        new() { Name = "Gold necklace", Category = "Gold Jewellery", LevelRequired = 6, Experience = 20, ItemId = 1654 },
        new() { Name = "Gold bracelet", Category = "Gold Jewellery", LevelRequired = 7, Experience = 25, ItemId = 11069 },
        new() { Name = "Gold amulet (u)", Category = "Gold Jewellery", LevelRequired = 8, Experience = 30, ItemId = 1673 },
        new() { Name = "Sapphire ring", Category = "Gold Jewellery", LevelRequired = 20, Experience = 40, ItemId = 1637 },
        new() { Name = "Sapphire necklace", Category = "Gold Jewellery", LevelRequired = 22, Experience = 55, ItemId = 1656 },
        new() { Name = "Sapphire bracelet", Category = "Gold Jewellery", LevelRequired = 23, Experience = 60, ItemId = 11072 },
        new() { Name = "Sapphire amulet (u)", Category = "Gold Jewellery", LevelRequired = 24, Experience = 65, ItemId = 1675 },
        new() { Name = "Emerald ring", Category = "Gold Jewellery", LevelRequired = 27, Experience = 55, ItemId = 1639 },
        new() { Name = "Emerald necklace", Category = "Gold Jewellery", LevelRequired = 29, Experience = 60, ItemId = 1658 },
        new() { Name = "Emerald bracelet", Category = "Gold Jewellery", LevelRequired = 30, Experience = 65, ItemId = 11076 },
        new() { Name = "Emerald amulet (u)", Category = "Gold Jewellery", LevelRequired = 31, Experience = 70, ItemId = 1677 },
        new() { Name = "Ruby ring", Category = "Gold Jewellery", LevelRequired = 34, Experience = 70, ItemId = 1641 },
        new() { Name = "Ruby necklace", Category = "Gold Jewellery", LevelRequired = 40, Experience = 75, ItemId = 1660 },
        new() { Name = "Ruby bracelet", Category = "Gold Jewellery", LevelRequired = 42, Experience = 80, ItemId = 11085 },
        new() { Name = "Ruby amulet (u)", Category = "Gold Jewellery", LevelRequired = 50, Experience = 85, ItemId = 1679 },
        new() { Name = "Diamond ring", Category = "Gold Jewellery", LevelRequired = 43, Experience = 85, ItemId = 1643 },
        new() { Name = "Diamond necklace", Category = "Gold Jewellery", LevelRequired = 56, Experience = 90, ItemId = 1662 },
        new() { Name = "Diamond bracelet", Category = "Gold Jewellery", LevelRequired = 58, Experience = 95, ItemId = 11092 },
        new() { Name = "Diamond amulet (u)", Category = "Gold Jewellery", LevelRequired = 70, Experience = 100, ItemId = 1681 },
        new() { Name = "Dragonstone ring", Category = "Gold Jewellery", LevelRequired = 55, Experience = 100, Members = true, ItemId = 1645 },
        new() { Name = "Dragon necklace", Category = "Gold Jewellery", LevelRequired = 72, Experience = 105, Members = true, ItemId = 1664 },
        new() { Name = "Dragonstone bracelet", Category = "Gold Jewellery", LevelRequired = 74, Experience = 110, Members = true, ItemId = 11115 },
        new() { Name = "Dragonstone amulet (u)", Category = "Gold Jewellery", LevelRequired = 80, Experience = 150, Members = true, ItemId = 1683 },
        new() { Name = "Onyx ring", Category = "Gold Jewellery", LevelRequired = 67, Experience = 115, Members = true, ItemId = 6575 },
        new() { Name = "Onyx necklace", Category = "Gold Jewellery", LevelRequired = 82, Experience = 120, Members = true, ItemId = 6577 },
        new() { Name = "Onyx bracelet", Category = "Gold Jewellery", LevelRequired = 84, Experience = 125, Members = true, ItemId = 11130 },
        new() { Name = "Onyx amulet (u)", Category = "Gold Jewellery", LevelRequired = 90, Experience = 165, Members = true, ItemId = 6579 },
        new() { Name = "Zenyte ring", Category = "Gold Jewellery", LevelRequired = 89, Experience = 150, Members = true, ItemId = 19538 },
        new() { Name = "Zenyte necklace", Category = "Gold Jewellery", LevelRequired = 92, Experience = 165, Members = true, ItemId = 19535 },
        new() { Name = "Zenyte bracelet", Category = "Gold Jewellery", LevelRequired = 95, Experience = 180, Members = true, ItemId = 19532 },
        new() { Name = "Zenyte amulet (u)", Category = "Gold Jewellery", LevelRequired = 98, Experience = 200, Members = true, ItemId = 19501 },

        // ── Glass ───────────────────────────────────────────────────────
        new() { Name = "Beer glass", Category = "Glass", LevelRequired = 1, Experience = 17.5, ItemId = 1919 },
        new() { Name = "Candle lantern", Category = "Glass", LevelRequired = 4, Experience = 19, Members = true, ItemId = 4527 },
        new() { Name = "Oil lamp", Category = "Glass", LevelRequired = 12, Experience = 25, Members = true, ItemId = 4525 },
        new() { Name = "Vial", Category = "Glass", LevelRequired = 33, Experience = 35, ItemId = 229 },
        new() { Name = "Fishbowl", Category = "Glass", LevelRequired = 42, Experience = 42.5, Members = true, ItemId = 6667 },
        new() { Name = "Unpowered staff orb", Category = "Glass", LevelRequired = 46, Experience = 52.5, Members = true, ItemId = 567 },
        new() { Name = "Lantern lens", Category = "Glass", LevelRequired = 49, Experience = 55, Members = true, ItemId = 4542 },
        new() { Name = "Dorgeshuun light orb", Category = "Glass", LevelRequired = 87, Experience = 70, Members = true, ItemId = 10973 },

        // ── Pottery ─────────────────────────────────────────────────────
        new() { Name = "Pot (unfired)", Category = "Pottery", LevelRequired = 1, Experience = 6.3, ItemId = 1787, Notes = "Soft clay → unfired pot" },
        new() { Name = "Pot (fired)", Category = "Pottery", LevelRequired = 1, Experience = 6.3, ItemId = 1931, Notes = "Unfired pot → pot" },
        new() { Name = "Pie dish (unfired)", Category = "Pottery", LevelRequired = 7, Experience = 15, ItemId = 1789, Notes = "Soft clay → unfired pie dish" },
        new() { Name = "Pie dish (fired)", Category = "Pottery", LevelRequired = 7, Experience = 10, ItemId = 2313, Notes = "Unfired pie dish → pie dish" },
        new() { Name = "Bowl (unfired)", Category = "Pottery", LevelRequired = 8, Experience = 18, ItemId = 1791, Notes = "Soft clay → unfired bowl" },
        new() { Name = "Bowl (fired)", Category = "Pottery", LevelRequired = 8, Experience = 15, ItemId = 1923, Notes = "Unfired bowl → bowl" },

        // ── Battlestaves ────────────────────────────────────────────────
        new() { Name = "Water battlestaff", Category = "Battlestaff", LevelRequired = 54, Experience = 100, Members = true, ItemId = 1395 },
        new() { Name = "Earth battlestaff", Category = "Battlestaff", LevelRequired = 58, Experience = 112.5, Members = true, ItemId = 1399 },
        new() { Name = "Fire battlestaff", Category = "Battlestaff", LevelRequired = 62, Experience = 125, Members = true, ItemId = 1393 },
        new() { Name = "Air battlestaff", Category = "Battlestaff", LevelRequired = 66, Experience = 137.5, Members = true, ItemId = 1397 },

        // ── Spinning ────────────────────────────────────────────────────
        new() { Name = "Ball of wool", Category = "Spinning", LevelRequired = 1, Experience = 2.5, ItemId = 1759 },
        new() { Name = "Bow string", Category = "Spinning", LevelRequired = 10, Experience = 15, Members = true, ItemId = 1777 },
        new() { Name = "Crossbow string", Category = "Spinning", LevelRequired = 10, Experience = 15, Members = true, ItemId = 9438 },
        new() { Name = "Magic string", Category = "Spinning", LevelRequired = 19, Experience = 30, Members = true, ItemId = 6038 },

        // ── Snakeskin ───────────────────────────────────────────────────
        new() { Name = "Snakeskin boots", Category = "Snakeskin", LevelRequired = 45, Experience = 30, Members = true, ItemId = 6328 },
        new() { Name = "Snakeskin vambraces", Category = "Snakeskin", LevelRequired = 47, Experience = 35, Members = true, ItemId = 6330 },
        new() { Name = "Snakeskin bandana", Category = "Snakeskin", LevelRequired = 48, Experience = 45, Members = true, ItemId = 6326 },
        new() { Name = "Snakeskin chaps", Category = "Snakeskin", LevelRequired = 51, Experience = 50, Members = true, ItemId = 6324 },
        new() { Name = "Snakeskin body", Category = "Snakeskin", LevelRequired = 53, Experience = 55, Members = true, ItemId = 6322 },
        new() { Name = "Snakeskin shield", Category = "Snakeskin", LevelRequired = 56, Experience = 100, Members = true, ItemId = 22284 },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    // ── Ingredient lookup (keyed by output ItemId) ──────────────────────
    private static readonly Dictionary<int, IReadOnlyList<Ingredient>> IngredientsByOutput = new()
    {
        // ── Leather ──────────────────────────────────────────────────────
        [1059]  = [new("Leather", 1741)],
        [1061]  = [new("Leather", 1741)],
        [1167]  = [new("Leather", 1741)],
        [1063]  = [new("Leather", 1741)],
        [1129]  = [new("Leather", 1741)],
        [1095]  = [new("Leather", 1741)],
        [1169]  = [new("Leather", 1741)],
        [1131]  = [new("Hard leather", 1743)],
        [1133]  = [new("Leather body", 1129), new("Steel studs", 3012)],
        [1097]  = [new("Leather chaps", 1095), new("Steel studs", 3012)],

        // ── Dragonhide ───────────────────────────────────────────────────
        [1065]  = [new("Green dragon leather", 1749)],
        [1099]  = [new("Green dragon leather", 1749, 2)],
        [1135]  = [new("Green dragon leather", 1749, 3)],
        [22272] = [new("Green dragon leather", 1749, 2), new("Maple shield", 22257), new("Steel nails", 1539, 15)],
        [2487]  = [new("Blue dragon leather", 2505)],
        [2493]  = [new("Blue dragon leather", 2505, 2)],
        [2499]  = [new("Blue dragon leather", 2505, 3)],
        [22275] = [new("Blue dragon leather", 2505, 2), new("Yew shield", 22260), new("Mithril nails", 4822, 15)],
        [2489]  = [new("Red dragon leather", 2507)],
        [2495]  = [new("Red dragon leather", 2507, 2)],
        [2501]  = [new("Red dragon leather", 2507, 3)],
        [22278] = [new("Red dragon leather", 2507, 2), new("Magic shield", 22263), new("Adamantite nails", 4823, 15)],
        [2491]  = [new("Black dragon leather", 2509)],
        [2497]  = [new("Black dragon leather", 2509, 2)],
        [2503]  = [new("Black dragon leather", 2509, 3)],
        [22281] = [new("Black dragon leather", 2509, 2), new("Redwood shield", 22266), new("Rune nails", 4824, 15)],

        // ── Gem cutting ──────────────────────────────────────────────────
        [1609]  = [new("Uncut opal", 1625)],
        [1611]  = [new("Uncut jade", 1627)],
        [1613]  = [new("Uncut red topaz", 1629)],
        [1607]  = [new("Uncut sapphire", 1623)],
        [1605]  = [new("Uncut emerald", 1621)],
        [1603]  = [new("Uncut ruby", 1619)],
        [1601]  = [new("Uncut diamond", 1617)],
        [1615]  = [new("Uncut dragonstone", 1631)],
        [6573]  = [new("Uncut onyx", 6571)],
        [19493] = [new("Uncut zenyte", 19491)],

        // ── Silver jewellery ─────────────────────────────────────────────
        [1714]  = [new("Silver bar", 2355)],
        [2961]  = [new("Silver bar", 2355)],
        [5525]  = [new("Silver bar", 2355)],
        [9382]  = [new("Silver bar", 2355)],

        // ── Gold jewellery ───────────────────────────────────────────────
        [1635]  = [new("Gold bar", 2357)],
        [1654]  = [new("Gold bar", 2357)],
        [11069] = [new("Gold bar", 2357)],
        [1673]  = [new("Gold bar", 2357)],
        [1637]  = [new("Gold bar", 2357), new("Sapphire", 1607)],
        [1656]  = [new("Gold bar", 2357), new("Sapphire", 1607)],
        [11072] = [new("Gold bar", 2357), new("Sapphire", 1607)],
        [1675]  = [new("Gold bar", 2357), new("Sapphire", 1607)],
        [1639]  = [new("Gold bar", 2357), new("Emerald", 1605)],
        [1658]  = [new("Gold bar", 2357), new("Emerald", 1605)],
        [11076] = [new("Gold bar", 2357), new("Emerald", 1605)],
        [1677]  = [new("Gold bar", 2357), new("Emerald", 1605)],
        [1641]  = [new("Gold bar", 2357), new("Ruby", 1603)],
        [1660]  = [new("Gold bar", 2357), new("Ruby", 1603)],
        [11085] = [new("Gold bar", 2357), new("Ruby", 1603)],
        [1679]  = [new("Gold bar", 2357), new("Ruby", 1603)],
        [1643]  = [new("Gold bar", 2357), new("Diamond", 1601)],
        [1662]  = [new("Gold bar", 2357), new("Diamond", 1601)],
        [11092] = [new("Gold bar", 2357), new("Diamond", 1601)],
        [1681]  = [new("Gold bar", 2357), new("Diamond", 1601)],
        [1645]  = [new("Gold bar", 2357), new("Dragonstone", 1615)],
        [1664]  = [new("Gold bar", 2357), new("Dragonstone", 1615)],
        [11115] = [new("Gold bar", 2357), new("Dragonstone", 1615)],
        [1683]  = [new("Gold bar", 2357), new("Dragonstone", 1615)],
        [6575]  = [new("Gold bar", 2357), new("Onyx", 6573)],
        [6577]  = [new("Gold bar", 2357), new("Onyx", 6573)],
        [11130] = [new("Gold bar", 2357), new("Onyx", 6573)],
        [6579]  = [new("Gold bar", 2357), new("Onyx", 6573)],
        [19538] = [new("Gold bar", 2357), new("Zenyte", 19493)],
        [19535] = [new("Gold bar", 2357), new("Zenyte", 19493)],
        [19532] = [new("Gold bar", 2357), new("Zenyte", 19493)],
        [19501] = [new("Gold bar", 2357), new("Zenyte", 19493)],

        // ── Glass ────────────────────────────────────────────────────────
        [1919]  = [new("Molten glass", 1775)],
        [4527]  = [new("Molten glass", 1775)],
        [4525]  = [new("Molten glass", 1775)],
        [229]   = [new("Molten glass", 1775)],
        [6667]  = [new("Molten glass", 1775)],
        [567]   = [new("Molten glass", 1775)],
        [4542]  = [new("Molten glass", 1775)],
        [10973] = [new("Molten glass", 1775)],

        // ── Pottery ──────────────────────────────────────────────────────
        [1787]  = [new("Soft clay", 1761)],
        [1931]  = [new("Unfired pot", 1787)],
        [1789]  = [new("Soft clay", 1761)],
        [2313]  = [new("Unfired pie dish", 1789)],
        [1791]  = [new("Soft clay", 1761)],
        [1923]  = [new("Unfired bowl", 1791)],

        // ── Battlestaves ─────────────────────────────────────────────────
        [1395]  = [new("Battlestaff", 1391), new("Water orb", 571)],
        [1399]  = [new("Battlestaff", 1391), new("Earth orb", 575)],
        [1393]  = [new("Battlestaff", 1391), new("Fire orb", 569)],
        [1397]  = [new("Battlestaff", 1391), new("Air orb", 573)],

        // ── Spinning ─────────────────────────────────────────────────────
        [1759]  = [new("Wool", 1737)],
        [1777]  = [new("Flax", 1779)],
        [9438]  = [new("Sinew", 9436)],
        [6038]  = [new("Magic roots", 6032)],

        // ── Snakeskin ────────────────────────────────────────────────────
        [6328]  = [new("Snakeskin", 6287, 6)],
        [6330]  = [new("Snakeskin", 6287, 8)],
        [6326]  = [new("Snakeskin", 6287, 5)],
        [6324]  = [new("Snakeskin", 6287, 12)],
        [6322]  = [new("Snakeskin", 6287, 15)],
        [22284] = [new("Snakeskin", 6287, 2), new("Willow shield", 22254), new("Iron nails", 4820, 15)],
    };

    public static IEnumerable<int> AllItemIds =>
        Actions.Select(a => a.ItemId)
            .Concat(IngredientsByOutput.Values.SelectMany(ings => ings.Select(i => (int?)i.ItemId)))
            .Where(id => id.HasValue)
            .Select(id => id!.Value)
            .Distinct();

    static CraftingData()
    {
        foreach (var action in Actions)
        {
            if (action.ItemId.HasValue && IngredientsByOutput.TryGetValue(action.ItemId.Value, out var ings))
            {
                action.Ingredients = ings;
                action.OutputItemId = action.ItemId;
            }
        }
    }
}
