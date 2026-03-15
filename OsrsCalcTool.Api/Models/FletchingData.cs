namespace OsrsCalcTool.Api.Models;

public class FletchingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }

    /// <summary>
    /// Quest required to craft this item. Null when no quest is needed.
    /// </summary>
    public string? QuestRequirement { get; init; }

    /// <summary>Ingredients consumed to make this item. Set by the static constructor.</summary>
    public IReadOnlyList<Ingredient>? Ingredients { get; set; }

    /// <summary>GE-priceable output item id (= ItemId). Set by the static constructor.</summary>
    public int? OutputItemId { get; set; }
}

public static class FletchingData
{
    /// <summary>All quests that gate at least one fletching action.</summary>
    public static IReadOnlyList<string> Quests { get; } =
    [
        "The Tourist Trap",
        "Big Chompy Bird Hunting",
        "Zogre Flesh Eaters",
        "Monkey Madness I",
        "Monkey Madness II",
    ];

    public static IReadOnlyList<FletchingAction> Actions { get; } =
    [
        // ── Arrow shafts & headless arrows ──────────────────────────────
        new() { Name = "Arrow shaft (×15)", Category = "Arrow", LevelRequired = 1, Experience = 5, ItemId = 52, Notes = "Knife + Logs; yields 15" },
        new() { Name = "Headless arrow (×15)", Category = "Arrow", LevelRequired = 1, Experience = 15, ItemId = 53, Notes = "Arrow shaft + Feather; yields 15" },

        // ── Arrows ──────────────────────────────────────────────────────
        new() { Name = "Bronze arrow (×15)", Category = "Arrow", LevelRequired = 1, Experience = 19.5, ItemId = 882 },
        new() { Name = "Iron arrow (×15)", Category = "Arrow", LevelRequired = 15, Experience = 37.5, ItemId = 884 },
        new() { Name = "Steel arrow (×15)", Category = "Arrow", LevelRequired = 30, Experience = 75, ItemId = 886 },
        new() { Name = "Mithril arrow (×15)", Category = "Arrow", LevelRequired = 45, Experience = 112.5, ItemId = 888 },
        new() { Name = "Broad arrow (×15)", Category = "Arrow", LevelRequired = 52, Experience = 150, Members = true, ItemId = 4160, Notes = "Requires broader fletching unlock" },
        new() { Name = "Adamant arrow (×15)", Category = "Arrow", LevelRequired = 60, Experience = 150, ItemId = 890 },
        new() { Name = "Rune arrow (×15)", Category = "Arrow", LevelRequired = 75, Experience = 187.5, ItemId = 892 },
        new() { Name = "Amethyst arrow (×15)", Category = "Arrow", LevelRequired = 82, Experience = 202.5, Members = true, ItemId = 21326 },
        new() { Name = "Dragon arrow (×15)", Category = "Arrow", LevelRequired = 90, Experience = 225, Members = true, ItemId = 11212 },

        // ── Ogre arrows ─────────────────────────────────────────────────
        new() { Name = "Ogre arrow shaft (×4 avg)", Category = "Ogre Arrow", LevelRequired = 5, Experience = 6.4, Members = true, ItemId = 2865, QuestRequirement = "Big Chompy Bird Hunting", Notes = "Achey logs; avg 4 per log" },
        new() { Name = "Flighted ogre arrow", Category = "Ogre Arrow", LevelRequired = 5, Experience = 0.9, Members = true, ItemId = 2866, QuestRequirement = "Big Chompy Bird Hunting" },
        new() { Name = "Ogre arrow", Category = "Ogre Arrow", LevelRequired = 5, Experience = 1, Members = true, ItemId = 2867, QuestRequirement = "Big Chompy Bird Hunting" },
        new() { Name = "Bronze brutal", Category = "Ogre Arrow", LevelRequired = 7, Experience = 1.4, Members = true, ItemId = 4773, QuestRequirement = "Zogre Flesh Eaters" },
        new() { Name = "Iron brutal", Category = "Ogre Arrow", LevelRequired = 18, Experience = 2.6, Members = true, ItemId = 4778, QuestRequirement = "Zogre Flesh Eaters" },
        new() { Name = "Steel brutal", Category = "Ogre Arrow", LevelRequired = 33, Experience = 5.1, Members = true, ItemId = 4783, QuestRequirement = "Zogre Flesh Eaters" },
        new() { Name = "Black brutal", Category = "Ogre Arrow", LevelRequired = 38, Experience = 6.5, Members = true, ItemId = 4788, QuestRequirement = "Zogre Flesh Eaters" },
        new() { Name = "Mithril brutal", Category = "Ogre Arrow", LevelRequired = 49, Experience = 7.5, Members = true, ItemId = 4793, QuestRequirement = "Zogre Flesh Eaters" },
        new() { Name = "Adamant brutal", Category = "Ogre Arrow", LevelRequired = 62, Experience = 10.2, Members = true, ItemId = 4798, QuestRequirement = "Zogre Flesh Eaters" },
        new() { Name = "Rune brutal", Category = "Ogre Arrow", LevelRequired = 77, Experience = 12.5, Members = true, ItemId = 4803, QuestRequirement = "Zogre Flesh Eaters" },

        // ── Darts ───────────────────────────────────────────────────────
        new() { Name = "Bronze dart (×10)", Category = "Dart", LevelRequired = 10, Experience = 18, ItemId = 806, QuestRequirement = "The Tourist Trap" },
        new() { Name = "Iron dart (×10)", Category = "Dart", LevelRequired = 22, Experience = 38, ItemId = 807, QuestRequirement = "The Tourist Trap" },
        new() { Name = "Steel dart (×10)", Category = "Dart", LevelRequired = 37, Experience = 75, ItemId = 808, QuestRequirement = "The Tourist Trap" },
        new() { Name = "Mithril dart (×10)", Category = "Dart", LevelRequired = 52, Experience = 112, ItemId = 809, QuestRequirement = "The Tourist Trap" },
        new() { Name = "Adamant dart (×10)", Category = "Dart", LevelRequired = 67, Experience = 150, ItemId = 810, QuestRequirement = "The Tourist Trap" },
        new() { Name = "Rune dart (×10)", Category = "Dart", LevelRequired = 81, Experience = 188, ItemId = 811, QuestRequirement = "The Tourist Trap" },
        new() { Name = "Amethyst dart (×10)", Category = "Dart", LevelRequired = 90, Experience = 210, Members = true, ItemId = 25849, QuestRequirement = "The Tourist Trap" },
        new() { Name = "Dragon dart (×10)", Category = "Dart", LevelRequired = 95, Experience = 250, Members = true, ItemId = 11230, QuestRequirement = "The Tourist Trap" },

        // ── Unstrung bows ───────────────────────────────────────────────
        new() { Name = "Shortbow (u)", Category = "Unstrung Bow", LevelRequired = 5, Experience = 5, ItemId = 50 },
        new() { Name = "Longbow (u)", Category = "Unstrung Bow", LevelRequired = 10, Experience = 10, ItemId = 48 },
        new() { Name = "Oak shortbow (u)", Category = "Unstrung Bow", LevelRequired = 20, Experience = 16.5, Members = true, ItemId = 54 },
        new() { Name = "Oak longbow (u)", Category = "Unstrung Bow", LevelRequired = 25, Experience = 25, Members = true, ItemId = 56 },
        new() { Name = "Unstrung comp bow", Category = "Unstrung Bow", LevelRequired = 30, Experience = 45, Members = true, ItemId = 4825, QuestRequirement = "Zogre Flesh Eaters", Notes = "Achey logs + Wolf bones" },
        new() { Name = "Willow shortbow (u)", Category = "Unstrung Bow", LevelRequired = 35, Experience = 33.3, Members = true, ItemId = 60 },
        new() { Name = "Willow longbow (u)", Category = "Unstrung Bow", LevelRequired = 40, Experience = 41.5, Members = true, ItemId = 58 },
        new() { Name = "Maple shortbow (u)", Category = "Unstrung Bow", LevelRequired = 50, Experience = 50, Members = true, ItemId = 64 },
        new() { Name = "Maple longbow (u)", Category = "Unstrung Bow", LevelRequired = 55, Experience = 58.3, Members = true, ItemId = 62 },
        new() { Name = "Yew shortbow (u)", Category = "Unstrung Bow", LevelRequired = 65, Experience = 67.5, Members = true, ItemId = 68 },
        new() { Name = "Yew longbow (u)", Category = "Unstrung Bow", LevelRequired = 70, Experience = 75, Members = true, ItemId = 66 },
        new() { Name = "Magic shortbow (u)", Category = "Unstrung Bow", LevelRequired = 80, Experience = 83.3, Members = true, ItemId = 72 },
        new() { Name = "Magic longbow (u)", Category = "Unstrung Bow", LevelRequired = 85, Experience = 91.5, Members = true, ItemId = 70 },

        // ── Strung bows ─────────────────────────────────────────────────
        new() { Name = "Shortbow", Category = "Strung Bow", LevelRequired = 5, Experience = 5, ItemId = 841 },
        new() { Name = "Longbow", Category = "Strung Bow", LevelRequired = 10, Experience = 10, ItemId = 839 },
        new() { Name = "Oak shortbow", Category = "Strung Bow", LevelRequired = 20, Experience = 16.5, Members = true, ItemId = 843 },
        new() { Name = "Oak longbow", Category = "Strung Bow", LevelRequired = 25, Experience = 25, Members = true, ItemId = 845 },
        new() { Name = "Comp ogre bow", Category = "Strung Bow", LevelRequired = 30, Experience = 45, Members = true, ItemId = 4827, QuestRequirement = "Zogre Flesh Eaters" },
        new() { Name = "Willow shortbow", Category = "Strung Bow", LevelRequired = 35, Experience = 33.2, Members = true, ItemId = 849 },
        new() { Name = "Willow longbow", Category = "Strung Bow", LevelRequired = 40, Experience = 41.5, Members = true, ItemId = 847 },
        new() { Name = "Maple shortbow", Category = "Strung Bow", LevelRequired = 50, Experience = 50, Members = true, ItemId = 853 },
        new() { Name = "Maple longbow", Category = "Strung Bow", LevelRequired = 55, Experience = 58.2, Members = true, ItemId = 851 },
        new() { Name = "Yew shortbow", Category = "Strung Bow", LevelRequired = 65, Experience = 67.5, Members = true, ItemId = 857 },
        new() { Name = "Yew longbow", Category = "Strung Bow", LevelRequired = 70, Experience = 75, Members = true, ItemId = 855 },
        new() { Name = "Magic shortbow", Category = "Strung Bow", LevelRequired = 80, Experience = 83.2, Members = true, ItemId = 861 },
        new() { Name = "Magic longbow", Category = "Strung Bow", LevelRequired = 85, Experience = 91.5, Members = true, ItemId = 859 },

        // ── Crossbow stocks ─────────────────────────────────────────────
        new() { Name = "Wooden stock", Category = "Crossbow", LevelRequired = 9, Experience = 6, ItemId = 9440 },
        new() { Name = "Oak stock", Category = "Crossbow", LevelRequired = 24, Experience = 16, Members = true, ItemId = 9442 },
        new() { Name = "Willow stock", Category = "Crossbow", LevelRequired = 39, Experience = 22, Members = true, ItemId = 9444 },
        new() { Name = "Teak stock", Category = "Crossbow", LevelRequired = 46, Experience = 27, Members = true, ItemId = 9446 },
        new() { Name = "Maple stock", Category = "Crossbow", LevelRequired = 54, Experience = 32, Members = true, ItemId = 9448 },
        new() { Name = "Mahogany stock", Category = "Crossbow", LevelRequired = 61, Experience = 41, Members = true, ItemId = 9450 },
        new() { Name = "Yew stock", Category = "Crossbow", LevelRequired = 69, Experience = 50, Members = true, ItemId = 9452 },
        new() { Name = "Magic stock", Category = "Crossbow", LevelRequired = 78, Experience = 70, Members = true, ItemId = 21952 },

        // ── Crossbows (unstrung) ────────────────────────────────────────
        new() { Name = "Bronze crossbow (u)", Category = "Crossbow", LevelRequired = 9, Experience = 12, ItemId = 9454 },
        new() { Name = "Blurite crossbow (u)", Category = "Crossbow", LevelRequired = 24, Experience = 32, Members = true, ItemId = 9456 },
        new() { Name = "Iron crossbow (u)", Category = "Crossbow", LevelRequired = 39, Experience = 44, Members = true, ItemId = 9457 },
        new() { Name = "Steel crossbow (u)", Category = "Crossbow", LevelRequired = 46, Experience = 54, Members = true, ItemId = 9459 },
        new() { Name = "Mithril crossbow (u)", Category = "Crossbow", LevelRequired = 54, Experience = 64, Members = true, ItemId = 9461 },
        new() { Name = "Adamant crossbow (u)", Category = "Crossbow", LevelRequired = 61, Experience = 82, Members = true, ItemId = 9463 },
        new() { Name = "Runite crossbow (u)", Category = "Crossbow", LevelRequired = 69, Experience = 100, Members = true, ItemId = 9465 },
        new() { Name = "Dragon crossbow (u)", Category = "Crossbow", LevelRequired = 78, Experience = 135, Members = true, ItemId = 21918 },

        // ── Crossbows (strung) ──────────────────────────────────────────
        new() { Name = "Bronze crossbow", Category = "Crossbow", LevelRequired = 9, Experience = 6, ItemId = 9174 },
        new() { Name = "Blurite crossbow", Category = "Crossbow", LevelRequired = 24, Experience = 16, Members = true, ItemId = 9176 },
        new() { Name = "Iron crossbow", Category = "Crossbow", LevelRequired = 39, Experience = 22, Members = true, ItemId = 9177 },
        new() { Name = "Steel crossbow", Category = "Crossbow", LevelRequired = 46, Experience = 27, Members = true, ItemId = 9179 },
        new() { Name = "Mithril crossbow", Category = "Crossbow", LevelRequired = 54, Experience = 32, Members = true, ItemId = 9181 },
        new() { Name = "Adamant crossbow", Category = "Crossbow", LevelRequired = 61, Experience = 41, Members = true, ItemId = 9183 },
        new() { Name = "Rune crossbow", Category = "Crossbow", LevelRequired = 69, Experience = 50, Members = true, ItemId = 9185 },
        new() { Name = "Dragon crossbow", Category = "Crossbow", LevelRequired = 78, Experience = 70, Members = true, ItemId = 21902 },

        // ── Bolts (feathering) ──────────────────────────────────────────
        new() { Name = "Bronze bolts (×10)", Category = "Bolt", LevelRequired = 9, Experience = 5, ItemId = 877 },
        new() { Name = "Blurite bolts (×10)", Category = "Bolt", LevelRequired = 24, Experience = 10, Members = true, ItemId = 9139 },
        new() { Name = "Iron bolts (×10)", Category = "Bolt", LevelRequired = 39, Experience = 15, ItemId = 9140 },
        new() { Name = "Silver bolts (×10)", Category = "Bolt", LevelRequired = 43, Experience = 25, Members = true, ItemId = 9145 },
        new() { Name = "Steel bolts (×10)", Category = "Bolt", LevelRequired = 46, Experience = 35, ItemId = 9141 },
        new() { Name = "Mithril bolts (×10)", Category = "Bolt", LevelRequired = 54, Experience = 50, ItemId = 9142 },
        new() { Name = "Broad bolts (×10)", Category = "Bolt", LevelRequired = 55, Experience = 30, Members = true, ItemId = 11875, Notes = "Requires broader fletching unlock" },
        new() { Name = "Adamant bolts (×10)", Category = "Bolt", LevelRequired = 61, Experience = 70, ItemId = 9143 },
        new() { Name = "Rune bolts (×10)", Category = "Bolt", LevelRequired = 69, Experience = 100, ItemId = 9144 },
        new() { Name = "Dragon bolts (×10)", Category = "Bolt", LevelRequired = 84, Experience = 120, Members = true, ItemId = 21905 },

        // ── Shields ─────────────────────────────────────────────────────
        new() { Name = "Oak shield", Category = "Shield", LevelRequired = 27, Experience = 50, Members = true, ItemId = 22251 },
        new() { Name = "Willow shield", Category = "Shield", LevelRequired = 42, Experience = 83, Members = true, ItemId = 22254 },
        new() { Name = "Maple shield", Category = "Shield", LevelRequired = 57, Experience = 116.5, Members = true, ItemId = 22257 },
        new() { Name = "Yew shield", Category = "Shield", LevelRequired = 72, Experience = 150, Members = true, ItemId = 22260 },
        new() { Name = "Magic shield", Category = "Shield", LevelRequired = 87, Experience = 183, Members = true, ItemId = 22263 },
        new() { Name = "Redwood shield", Category = "Shield", LevelRequired = 92, Experience = 216, Members = true, ItemId = 22266 },

        // ── Ballistae ───────────────────────────────────────────────────
        new() { Name = "Incomplete light ballista", Category = "Ballista", LevelRequired = 47, Experience = 15, Members = true, ItemId = 19586, QuestRequirement = "Monkey Madness I" },
        new() { Name = "Unstrung light ballista", Category = "Ballista", LevelRequired = 47, Experience = 15, Members = true, ItemId = 19589, QuestRequirement = "Monkey Madness I" },
        new() { Name = "Light ballista", Category = "Ballista", LevelRequired = 47, Experience = 300, Members = true, ItemId = 19478, QuestRequirement = "Monkey Madness I" },
        new() { Name = "Incomplete heavy ballista", Category = "Ballista", LevelRequired = 72, Experience = 30, Members = true, ItemId = 19592, QuestRequirement = "Monkey Madness II" },
        new() { Name = "Unstrung heavy ballista", Category = "Ballista", LevelRequired = 72, Experience = 30, Members = true, ItemId = 19595, QuestRequirement = "Monkey Madness II" },
        new() { Name = "Heavy ballista", Category = "Ballista", LevelRequired = 72, Experience = 600, Members = true, ItemId = 19481, QuestRequirement = "Monkey Madness II" },

        // ── Blowpipes ───────────────────────────────────────────────────
        new() { Name = "Toxic blowpipe", Category = "Blowpipe", LevelRequired = 78, Experience = 120, Members = true, ItemId = 12924, Notes = "Chisel + Tanzanite fang" },

        // ── Battlestaff ─────────────────────────────────────────────────
        new() { Name = "Battlestaff", Category = "Battlestaff", LevelRequired = 40, Experience = 80, Members = true, ItemId = 1391 },

        // ── Javelin shafts & javelins ───────────────────────────────────
        new() { Name = "Javelin shaft (×15)", Category = "Javelin", LevelRequired = 3, Experience = 15, Members = true, ItemId = 19584 },
        new() { Name = "Bronze javelin (×15)", Category = "Javelin", LevelRequired = 3, Experience = 15, Members = true, ItemId = 825 },
        new() { Name = "Iron javelin (×15)", Category = "Javelin", LevelRequired = 17, Experience = 30, Members = true, ItemId = 826 },
        new() { Name = "Steel javelin (×15)", Category = "Javelin", LevelRequired = 32, Experience = 75, Members = true, ItemId = 827 },
        new() { Name = "Mithril javelin (×15)", Category = "Javelin", LevelRequired = 47, Experience = 112.5, Members = true, ItemId = 828 },
        new() { Name = "Adamant javelin (×15)", Category = "Javelin", LevelRequired = 62, Experience = 150, Members = true, ItemId = 829 },
        new() { Name = "Rune javelin (×15)", Category = "Javelin", LevelRequired = 77, Experience = 186, Members = true, ItemId = 830 },
        new() { Name = "Amethyst javelin (×15)", Category = "Javelin", LevelRequired = 84, Experience = 202.5, Members = true, ItemId = 21318 },
        new() { Name = "Dragon javelin (×15)", Category = "Javelin", LevelRequired = 92, Experience = 225, Members = true, ItemId = 19484 },
    ];

    // ── Ingredient lookups (keyed by output ItemId) ─────────────────
    private static readonly Dictionary<int, IReadOnlyList<Ingredient>> IngredientsByOutput = new()
    {
        // Arrow shafts / headless arrows
        [52]    = [new("Logs", 1511)],
        [53]    = [new("Arrow shaft", 52), new("Feather", 314)],

        // Arrows
        [882]   = [new("Headless arrow", 53), new("Bronze arrowtips", 39)],
        [884]   = [new("Headless arrow", 53), new("Iron arrowtips", 40)],
        [886]   = [new("Headless arrow", 53), new("Steel arrowtips", 41)],
        [888]   = [new("Headless arrow", 53), new("Mithril arrowtips", 42)],
        [4160]  = [new("Headless arrow", 53), new("Broad arrowheads", 4158)],
        [890]   = [new("Headless arrow", 53), new("Adamant arrowtips", 43)],
        [892]   = [new("Headless arrow", 53), new("Rune arrowtips", 44)],
        [21326] = [new("Headless arrow", 53), new("Amethyst arrowtips", 21350)],
        [11212] = [new("Headless arrow", 53), new("Dragon arrowtips", 11237)],

        // Ogre arrows
        [2865]  = [new("Achey tree logs", 2862)],
        [2866]  = [new("Ogre arrow shaft", 2865), new("Feather", 314, 4)],
        [2867]  = [new("Flighted ogre arrow", 2866), new("Wolfbone arrowtips", 2861)],
        [4773]  = [new("Flighted ogre arrow", 2866), new("Bronze nails", 4819)],
        [4778]  = [new("Flighted ogre arrow", 2866), new("Iron nails", 4820)],
        [4783]  = [new("Flighted ogre arrow", 2866), new("Steel nails", 1539)],
        [4788]  = [new("Flighted ogre arrow", 2866), new("Black nails", 4821)],
        [4793]  = [new("Flighted ogre arrow", 2866), new("Mithril nails", 4822)],
        [4798]  = [new("Flighted ogre arrow", 2866), new("Adamantite nails", 4823)],
        [4803]  = [new("Flighted ogre arrow", 2866), new("Rune nails", 4824)],

        // Darts
        [806]   = [new("Bronze dart tip", 819), new("Feather", 314)],
        [807]   = [new("Iron dart tip", 820), new("Feather", 314)],
        [808]   = [new("Steel dart tip", 821), new("Feather", 314)],
        [809]   = [new("Mithril dart tip", 822), new("Feather", 314)],
        [810]   = [new("Adamant dart tip", 823), new("Feather", 314)],
        [811]   = [new("Rune dart tip", 824), new("Feather", 314)],
        [25849] = [new("Amethyst dart tip", 25853), new("Feather", 314)],
        [11230] = [new("Dragon dart tip", 11232), new("Feather", 314)],

        // Unstrung bows
        [50]    = [new("Logs", 1511)],
        [48]    = [new("Logs", 1511)],
        [54]    = [new("Oak logs", 1521)],
        [56]    = [new("Oak logs", 1521)],
        [4825]  = [new("Achey tree logs", 2862), new("Wolf bones", 2859)],
        [60]    = [new("Willow logs", 1519)],
        [58]    = [new("Willow logs", 1519)],
        [64]    = [new("Maple logs", 1517)],
        [62]    = [new("Maple logs", 1517)],
        [68]    = [new("Yew logs", 1515)],
        [66]    = [new("Yew logs", 1515)],
        [72]    = [new("Magic logs", 1513)],
        [70]    = [new("Magic logs", 1513)],

        // Strung bows
        [841]   = [new("Shortbow (u)", 50), new("Bow string", 1777)],
        [839]   = [new("Longbow (u)", 48), new("Bow string", 1777)],
        [843]   = [new("Oak shortbow (u)", 54), new("Bow string", 1777)],
        [845]   = [new("Oak longbow (u)", 56), new("Bow string", 1777)],
        [4827]  = [new("Unstrung comp bow", 4825), new("Bow string", 1777)],
        [849]   = [new("Willow shortbow (u)", 60), new("Bow string", 1777)],
        [847]   = [new("Willow longbow (u)", 58), new("Bow string", 1777)],
        [853]   = [new("Maple shortbow (u)", 64), new("Bow string", 1777)],
        [851]   = [new("Maple longbow (u)", 62), new("Bow string", 1777)],
        [857]   = [new("Yew shortbow (u)", 68), new("Bow string", 1777)],
        [855]   = [new("Yew longbow (u)", 66), new("Bow string", 1777)],
        [861]   = [new("Magic shortbow (u)", 72), new("Bow string", 1777)],
        [859]   = [new("Magic longbow (u)", 70), new("Bow string", 1777)],

        // Crossbow stocks
        [9440]  = [new("Logs", 1511)],
        [9442]  = [new("Oak logs", 1521)],
        [9444]  = [new("Willow logs", 1519)],
        [9446]  = [new("Teak logs", 6333)],
        [9448]  = [new("Maple logs", 1517)],
        [9450]  = [new("Mahogany logs", 6332)],
        [9452]  = [new("Yew logs", 1515)],
        [21952] = [new("Magic logs", 1513)],

        // Crossbows (unstrung — stock + limbs)
        [9454]  = [new("Wooden stock", 9440), new("Bronze limbs", 9420)],
        [9456]  = [new("Oak stock", 9442), new("Blurite limbs", 9422)],
        [9457]  = [new("Willow stock", 9444), new("Iron limbs", 9423)],
        [9459]  = [new("Teak stock", 9446), new("Steel limbs", 9425)],
        [9461]  = [new("Maple stock", 9448), new("Mithril limbs", 9427)],
        [9463]  = [new("Mahogany stock", 9450), new("Adamantite limbs", 9429)],
        [9465]  = [new("Yew stock", 9452), new("Runite limbs", 9431)],
        [21918] = [new("Magic stock", 21952), new("Dragon limbs", 21922)],

        // Crossbows (strung)
        [9174]  = [new("Bronze crossbow (u)", 9454), new("Crossbow string", 9438)],
        [9176]  = [new("Blurite crossbow (u)", 9456), new("Crossbow string", 9438)],
        [9177]  = [new("Iron crossbow (u)", 9457), new("Crossbow string", 9438)],
        [9179]  = [new("Steel crossbow (u)", 9459), new("Crossbow string", 9438)],
        [9181]  = [new("Mithril crossbow (u)", 9461), new("Crossbow string", 9438)],
        [9183]  = [new("Adamant crossbow (u)", 9463), new("Crossbow string", 9438)],
        [9185]  = [new("Runite crossbow (u)", 9465), new("Crossbow string", 9438)],
        [21902] = [new("Dragon crossbow (u)", 21918), new("Crossbow string", 9438)],

        // Bolts (feathering)
        [877]   = [new("Bronze bolts (unf)", 9375), new("Feather", 314)],
        [9139]  = [new("Blurite bolts (unf)", 9376), new("Feather", 314)],
        [9140]  = [new("Iron bolts (unf)", 9377), new("Feather", 314)],
        [9145]  = [new("Silver bolts (unf)", 9382), new("Feather", 314)],
        [9141]  = [new("Steel bolts (unf)", 9378), new("Feather", 314)],
        [9142]  = [new("Mithril bolts (unf)", 9379), new("Feather", 314)],
        [11875] = [new("Unfinished broad bolts", 11876), new("Feather", 314)],
        [9143]  = [new("Adamant bolts (unf)", 9380), new("Feather", 314)],
        [9144]  = [new("Runite bolts (unf)", 9381), new("Feather", 314)],
        [21905] = [new("Dragon bolts (unf)", 21930), new("Feather", 314)],

        // Shields
        [22251] = [new("Oak logs", 1521, 2)],
        [22254] = [new("Willow logs", 1519, 2)],
        [22257] = [new("Maple logs", 1517, 2)],
        [22260] = [new("Yew logs", 1515, 2)],
        [22263] = [new("Magic logs", 1513, 2)],
        [22266] = [new("Redwood logs", 19669, 2)],

        // Ballistae
        [19586] = [new("Light frame", 19572), new("Ballista limbs", 19592)],
        [19589] = [new("Incomplete light ballista", 19586), new("Ballista spring", 19601)],
        [19478] = [new("Unstrung light ballista", 19589), new("Monkey tail", 19610)],
        [19592] = [new("Heavy frame", 19571), new("Ballista limbs", 19598)],
        [19595] = [new("Incomplete heavy ballista", 19592), new("Ballista spring", 19601)],
        [19481] = [new("Unstrung heavy ballista", 19595), new("Monkey tail", 19610)],

        // Blowpipe
        [12924] = [new("Tanzanite fang", 12922)],

        // Battlestaff
        [1391]  = [new("Celastrus bark", 22783)],

        // Javelin shafts
        [19584] = [new("Logs", 1511)],

        // Javelins
        [825]   = [new("Javelin shaft", 19584), new("Bronze javelin tips", 19570)],
        [826]   = [new("Javelin shaft", 19584), new("Iron javelin tips", 19572)],
        [827]   = [new("Javelin shaft", 19584), new("Steel javelin tips", 19574)],
        [828]   = [new("Javelin shaft", 19584), new("Mithril javelin tips", 19576)],
        [829]   = [new("Javelin shaft", 19584), new("Adamant javelin tips", 19578)],
        [830]   = [new("Javelin shaft", 19584), new("Rune javelin tips", 19580)],
        [21318] = [new("Javelin shaft", 19584), new("Amethyst javelin tips", 21352)],
        [19484] = [new("Javelin shaft", 19584), new("Dragon javelin tips", 19582)],
    };

    public static IReadOnlyList<Ingredient> GetIngredients(FletchingAction action)
    {
        if (action.ItemId.HasValue && IngredientsByOutput.TryGetValue(action.ItemId.Value, out var ingredients))
            return ingredients;
        return [];
    }

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    public static IEnumerable<int> AllItemIds =>
        Actions.Select(a => a.ItemId)
            .Concat(IngredientsByOutput.Values.SelectMany(ings => ings.Select(i => i.ItemId)))
            .Where(id => id.HasValue)
            .Select(id => id!.Value)
            .Distinct();

    static FletchingData()
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
