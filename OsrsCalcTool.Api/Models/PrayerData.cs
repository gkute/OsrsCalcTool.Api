namespace OsrsCalcTool.Api.Models;

public class PrayerAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public int? ItemId { get; init; }

    /// <summary>
    /// The item consumed (bone/ash) as a single ingredient for cost calculations.
    /// Populated automatically from ItemId when non-null.
    /// </summary>
    public IReadOnlyList<Ingredient>? Ingredients =>
        ItemId.HasValue ? [new Ingredient(Name, ItemId.Value, 1)] : null;

    /// <summary>
    /// Quest required to use this training method. Null when no quest is needed.
    /// </summary>
    public string? QuestRequirement { get; init; }
}

/// <summary>
/// XP multiplier bonus that can be toggled by the user.
/// </summary>
public record PrayerBonus(string Name, double Multiplier, string Description);

public static class PrayerData
{
    /// <summary>All quests that gate at least one prayer action.</summary>
    public static IReadOnlyList<string> Quests { get; } = [];

    /// <summary>
    /// Altar / location bonuses that multiply bone XP.
    /// Only one can be active at a time.
    /// </summary>
    public static IReadOnlyList<PrayerBonus> Bonuses { get; } =
    [
        new("None (bury / scatter)", 1.0, "Base XP — bury bones or scatter ashes"),
        new("Lit gilded altar (2 burners)", 3.5, "Player-owned house gilded altar with both burners lit (×3.5)"),
        new("Chaos altar (Wilderness)", 3.5, "Chaos Temple altar — same ×3.5 but 50% chance bone is not consumed"),
        new("Ectofuntus", 4.0, "Port Phasmatys Ectofuntus (×4, requires bonemeal + slime)"),
        new("Sinister Offering", 3.0, "Sinister Offering spell (×3, Arceuus spellbook)"),
        new("Sacred bone burner", 3.0, "Fortis Colosseum sacred bone burner (×3)"),
    ];

    public static IReadOnlyList<PrayerAction> Actions { get; } =
    [
        // ── Bones ───────────────────────────────────────────────────────
        new() { Name = "Bones", Category = "Bones", LevelRequired = 1, Experience = 4.5, ItemId = 526 },
        new() { Name = "Burnt bones", Category = "Bones", LevelRequired = 1, Experience = 4.5, ItemId = 528 },
        new() { Name = "Wolf bones", Category = "Bones", LevelRequired = 1, Experience = 4.5, Members = true, ItemId = 2859 },
        new() { Name = "Monkey bones", Category = "Bones", LevelRequired = 1, Experience = 5, ItemId = 3183 },
        new() { Name = "Bat bones", Category = "Bones", LevelRequired = 1, Experience = 5.3, ItemId = 530 },
        new() { Name = "Big bones", Category = "Bones", LevelRequired = 1, Experience = 15, ItemId = 532 },
        new() { Name = "Jogre bones", Category = "Bones", LevelRequired = 1, Experience = 15, Members = true, ItemId = 3125 },
        new() { Name = "Zogre bones", Category = "Bones", LevelRequired = 1, Experience = 22.5, Members = true, ItemId = 4812 },
        new() { Name = "Shaikahan bones", Category = "Bones", LevelRequired = 1, Experience = 25, Members = true, ItemId = 3123 },
        new() { Name = "Babydragon bones", Category = "Bones", LevelRequired = 1, Experience = 30, Members = true, ItemId = 534 },
        new() { Name = "Wyrm bones", Category = "Bones", LevelRequired = 1, Experience = 50, Members = true, ItemId = 22780 },
        new() { Name = "Wyvern bones", Category = "Bones", LevelRequired = 1, Experience = 72, Members = true, ItemId = 6812 },
        new() { Name = "Dragon bones", Category = "Bones", LevelRequired = 1, Experience = 72, Members = true, ItemId = 536 },
        new() { Name = "Drake bones", Category = "Bones", LevelRequired = 1, Experience = 80, Members = true, ItemId = 22783 },
        new() { Name = "Fayrg bones", Category = "Bones", LevelRequired = 1, Experience = 84, Members = true, ItemId = 4830 },
        new() { Name = "Lava dragon bones", Category = "Bones", LevelRequired = 1, Experience = 85, Members = true, ItemId = 11943 },
        new() { Name = "Raurg bones", Category = "Bones", LevelRequired = 1, Experience = 96, Members = true, ItemId = 4832 },
        new() { Name = "Hydra bones", Category = "Bones", LevelRequired = 1, Experience = 110, Members = true, ItemId = 22786 },
        new() { Name = "Dagannoth bones", Category = "Bones", LevelRequired = 1, Experience = 125, Members = true, ItemId = 6729 },
        new() { Name = "Ourg bones", Category = "Bones", LevelRequired = 1, Experience = 140, Members = true, ItemId = 4834 },
        new() { Name = "Superior dragon bones", Category = "Bones", LevelRequired = 70, Experience = 150, Members = true, ItemId = 22124 },

        // ── Ashes ───────────────────────────────────────────────────────
        new() { Name = "Fiendish ashes", Category = "Ashes", LevelRequired = 1, Experience = 10, Members = true, ItemId = 25766 },
        new() { Name = "Vile ashes", Category = "Ashes", LevelRequired = 1, Experience = 25, Members = true, ItemId = 25769 },
        new() { Name = "Malicious ashes", Category = "Ashes", LevelRequired = 1, Experience = 65, Members = true, ItemId = 25772 },
        new() { Name = "Abyssal ashes", Category = "Ashes", LevelRequired = 1, Experience = 85, Members = true, ItemId = 25775 },
        new() { Name = "Infernal ashes", Category = "Ashes", LevelRequired = 1, Experience = 110, Members = true, ItemId = 25778 },

        // ── Ensouled heads (Arceuus spellbook) ──────────────────────────
        new() { Name = "Ensouled goblin head", Category = "Ensouled Head", LevelRequired = 3, Experience = 130, Members = true, ItemId = 13448 },
        new() { Name = "Ensouled monkey head", Category = "Ensouled Head", LevelRequired = 7, Experience = 182, Members = true, ItemId = 13451 },
        new() { Name = "Ensouled imp head", Category = "Ensouled Head", LevelRequired = 12, Experience = 286, Members = true, ItemId = 13454 },
        new() { Name = "Ensouled minotaur head", Category = "Ensouled Head", LevelRequired = 17, Experience = 364, Members = true, ItemId = 13457 },
        new() { Name = "Ensouled scorpion head", Category = "Ensouled Head", LevelRequired = 22, Experience = 454, Members = true, ItemId = 13460 },
        new() { Name = "Ensouled bear head", Category = "Ensouled Head", LevelRequired = 27, Experience = 480, Members = true, ItemId = 13463 },
        new() { Name = "Ensouled unicorn head", Category = "Ensouled Head", LevelRequired = 32, Experience = 494, Members = true, ItemId = 13466 },
        new() { Name = "Ensouled dog head", Category = "Ensouled Head", LevelRequired = 37, Experience = 520, Members = true, ItemId = 13469 },
        new() { Name = "Ensouled chaos druid head", Category = "Ensouled Head", LevelRequired = 45, Experience = 584, Members = true, ItemId = 13472 },
        new() { Name = "Ensouled giant head", Category = "Ensouled Head", LevelRequired = 50, Experience = 650, Members = true, ItemId = 13475 },
        new() { Name = "Ensouled ogre head", Category = "Ensouled Head", LevelRequired = 55, Experience = 716, Members = true, ItemId = 13478 },
        new() { Name = "Ensouled elf head", Category = "Ensouled Head", LevelRequired = 60, Experience = 754, Members = true, ItemId = 13481 },
        new() { Name = "Ensouled troll head", Category = "Ensouled Head", LevelRequired = 65, Experience = 780, Members = true, ItemId = 13484 },
        new() { Name = "Ensouled horror head", Category = "Ensouled Head", LevelRequired = 70, Experience = 832, Members = true, ItemId = 13487 },
        new() { Name = "Ensouled kalphite head", Category = "Ensouled Head", LevelRequired = 75, Experience = 884, Members = true, ItemId = 13490 },
        new() { Name = "Ensouled dagannoth head", Category = "Ensouled Head", LevelRequired = 80, Experience = 936, Members = true, ItemId = 13493 },
        new() { Name = "Ensouled bloodveld head", Category = "Ensouled Head", LevelRequired = 82, Experience = 1040, Members = true, ItemId = 13496 },
        new() { Name = "Ensouled tzhaar head", Category = "Ensouled Head", LevelRequired = 85, Experience = 1104, Members = true, ItemId = 13499 },
        new() { Name = "Ensouled demon head", Category = "Ensouled Head", LevelRequired = 88, Experience = 1170, Members = true, ItemId = 13502 },
        new() { Name = "Ensouled aviansie head", Category = "Ensouled Head", LevelRequired = 93, Experience = 1234, Members = true, ItemId = 13505 },
        new() { Name = "Ensouled abyssal head", Category = "Ensouled Head", LevelRequired = 93, Experience = 1300, Members = true, ItemId = 13508 },
        new() { Name = "Ensouled dragon head", Category = "Ensouled Head", LevelRequired = 93, Experience = 1560, Members = true, ItemId = 13511 },
    ];

    public static IReadOnlyList<Ingredient> GetIngredients(PrayerAction action)
    {
        if (action.ItemId.HasValue)
            return [new(action.Name, action.ItemId.Value)];
        return [];
    }

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();

    public static IEnumerable<int> AllItemIds =>
        Actions.Where(a => a.ItemId.HasValue)
            .Select(a => a.ItemId!.Value)
            .Distinct();

    /// <summary>
    /// Returns effective XP for a bone/ash action given the selected bonus multiplier.
    /// Ensouled heads are NOT affected by altar bonuses.
    /// </summary>
    public static double GetEffectiveXp(PrayerAction action, double bonusMultiplier)
    {
        if (action.Category == "Ensouled Head")
            return action.Experience;
        return action.Experience * bonusMultiplier;
    }
}
