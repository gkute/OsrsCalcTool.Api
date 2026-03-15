namespace OsrsCalcTool.Api.Models;

public class SailingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public string? Duration { get; init; }
    public string? Notes { get; init; }
}

public static class SailingData
{
    public static IReadOnlyList<SailingAction> Actions { get; } =
    [
        // Shipwreck Salvaging — Salvage only (XP per salvage action)
        new() { Name = "Small shipwreck (Salvage)", Category = "Salvaging", LevelRequired = 15, Experience = 10, Duration = "~1 min", Notes = "Salvage XP only" },
        new() { Name = "Fisherman's shipwreck (Salvage)", Category = "Salvaging", LevelRequired = 26, Experience = 17, Duration = "~3 min", Notes = "Salvage XP only" },
        new() { Name = "Barracuda shipwreck (Salvage)", Category = "Salvaging", LevelRequired = 35, Experience = 31, Duration = "~3 min", Notes = "Salvage XP only" },
        new() { Name = "Large shipwreck (Salvage)", Category = "Salvaging", LevelRequired = 53, Experience = 48, Duration = "~3 min", Notes = "Salvage XP only" },
        new() { Name = "Pirate shipwreck (Salvage)", Category = "Salvaging", LevelRequired = 64, Experience = 76, Duration = "~3 min", Notes = "Salvage XP only" },
        new() { Name = "Mercenary shipwreck (Salvage)", Category = "Salvaging", LevelRequired = 73, Experience = 138, Duration = "~3:15 min", Notes = "Salvage XP only" },
        new() { Name = "Fremennik shipwreck (Salvage)", Category = "Salvaging", LevelRequired = 80, Experience = 162, Duration = "~3:40 min", Notes = "Salvage XP only" },
        new() { Name = "Merchant shipwreck (Salvage)", Category = "Salvaging", LevelRequired = 87, Experience = 200, Duration = "~4 min", Notes = "Salvage XP only" },

        // Shipwreck Salvaging — Salvage + Sorting (Salvage XP + Sorting XP)
        new() { Name = "Small shipwreck (Salvage + Sorting)", Category = "Salvaging + Sorting", LevelRequired = 15, Experience = 15.5, Duration = "~1 min", Notes = "10 salvage + 5.5 sorting" },
        new() { Name = "Fisherman's shipwreck (Salvage + Sorting)", Category = "Salvaging + Sorting", LevelRequired = 26, Experience = 26, Duration = "~3 min", Notes = "17 salvage + 9 sorting" },
        new() { Name = "Barracuda shipwreck (Salvage + Sorting)", Category = "Salvaging + Sorting", LevelRequired = 35, Experience = 46.5, Duration = "~3 min", Notes = "31 salvage + 15.5 sorting" },
        new() { Name = "Large shipwreck (Salvage + Sorting)", Category = "Salvaging + Sorting", LevelRequired = 53, Experience = 72, Duration = "~3 min", Notes = "48 salvage + 24 sorting" },
        new() { Name = "Pirate shipwreck (Salvage + Sorting)", Category = "Salvaging + Sorting", LevelRequired = 64, Experience = 107.5, Duration = "~3 min", Notes = "76 salvage + 31.5 sorting" },
        new() { Name = "Mercenary shipwreck (Salvage + Sorting)", Category = "Salvaging + Sorting", LevelRequired = 73, Experience = 201.5, Duration = "~3:15 min", Notes = "138 salvage + 63.5 sorting" },
        new() { Name = "Fremennik shipwreck (Salvage + Sorting)", Category = "Salvaging + Sorting", LevelRequired = 80, Experience = 237, Duration = "~3:40 min", Notes = "162 salvage + 75 sorting" },
        new() { Name = "Merchant shipwreck (Salvage + Sorting)", Category = "Salvaging + Sorting", LevelRequired = 87, Experience = 295, Duration = "~4 min", Notes = "200 salvage + 95 sorting" },

        // Courier Tasks — grouped by level tier with representative XP values
        new() { Name = "Pandemonium platebody delivery", Category = "Courier Task", LevelRequired = 1, Experience = 71, Notes = "Port Sarim → The Pandemonium" },
        new() { Name = "Port Sarim spice delivery", Category = "Courier Task", LevelRequired = 1, Experience = 141, Notes = "The Pandemonium → Port Sarim" },
        new() { Name = "Hosidius rope delivery", Category = "Courier Task", LevelRequired = 5, Experience = 83, Notes = "Land's End → Hosidius" },
        new() { Name = "Land's End vegetable delivery", Category = "Courier Task", LevelRequired = 5, Experience = 166, Notes = "Hosidius → Land's End" },
        new() { Name = "Musa Point logs delivery", Category = "Courier Task", LevelRequired = 10, Experience = 72, Notes = "Port Sarim → Musa Point" },
        new() { Name = "Musa Point banana delivery", Category = "Courier Task", LevelRequired = 10, Experience = 144, Notes = "Port Sarim → Musa Point (round-trip)" },
        new() { Name = "Musa Point eye patch delivery", Category = "Courier Task", LevelRequired = 10, Experience = 162, Notes = "The Pandemonium → Musa Point (round-trip)" },
        new() { Name = "Port Piscarilius plank delivery", Category = "Courier Task", LevelRequired = 15, Experience = 230, Notes = "Land's End → Port Piscarilius" },
        new() { Name = "Land's End fish delivery", Category = "Courier Task", LevelRequired = 15, Experience = 460, Notes = "Port Piscarilius → Land's End (round-trip)" },
        new() { Name = "Port Sarim honey delivery", Category = "Courier Task", LevelRequired = 20, Experience = 525, Notes = "Catherby → Port Sarim" },
        new() { Name = "Port Piscarilius book delivery", Category = "Courier Task", LevelRequired = 20, Experience = 1838, Notes = "Port Sarim → Port Piscarilius (round-trip)" },
        new() { Name = "Brimhaven vodka delivery", Category = "Courier Task", LevelRequired = 25, Experience = 238, Notes = "Port Sarim → Brimhaven" },
        new() { Name = "Port Piscarilius honey delivery", Category = "Courier Task", LevelRequired = 25, Experience = 980, Notes = "Catherby → Port Piscarilius" },
        new() { Name = "Ardougne salamander delivery", Category = "Courier Task", LevelRequired = 28, Experience = 273, Notes = "Port Sarim → Ardougne" },
        new() { Name = "Ardougne rune delivery", Category = "Courier Task", LevelRequired = 28, Experience = 574, Notes = "Port Sarim → Ardougne (round-trip)" },
        new() { Name = "Port Sarim sword delivery", Category = "Courier Task", LevelRequired = 30, Experience = 641, Notes = "Port Khazard → Port Sarim" },
        new() { Name = "Ardougne fur delivery", Category = "Courier Task", LevelRequired = 30, Experience = 1880, Notes = "Port Piscarilius → Ardougne" },
        new() { Name = "Civitas illa Fortis artefact delivery", Category = "Courier Task", LevelRequired = 38, Experience = 951, Notes = "Ardougne → Civitas illa Fortis" },
        new() { Name = "Port Khazard huasca delivery", Category = "Courier Task", LevelRequired = 38, Experience = 1751, Notes = "Civitas illa Fortis → Port Khazard" },
        new() { Name = "Corsair Cove ship part delivery", Category = "Courier Task", LevelRequired = 40, Experience = 1190, Notes = "The Pandemonium → Corsair Cove" },
        new() { Name = "Corsair Cove fish delivery", Category = "Courier Task", LevelRequired = 40, Experience = 2692, Notes = "Port Piscarilius → Corsair Cove" },
        new() { Name = "Port Sarim sunbeam ale delivery", Category = "Courier Task", LevelRequired = 40, Experience = 1842, Notes = "Civitas illa Fortis → Port Sarim" },
        new() { Name = "Summer Shore potion delivery", Category = "Courier Task", LevelRequired = 46, Experience = 4228, Notes = "Aldarin → The Summer Shore" },
        new() { Name = "Aldarin crab paste delivery", Category = "Courier Task", LevelRequired = 46, Experience = 2144, Notes = "The Summer Shore → Aldarin" },
        new() { Name = "Ruin of Unkah fishing supplies delivery", Category = "Courier Task", LevelRequired = 48, Experience = 1703, Notes = "Ardougne → Ruins of Unkah" },
        new() { Name = "Void Knights' Outpost seed delivery", Category = "Courier Task", LevelRequired = 50, Experience = 3366, Notes = "Port Roberts → Void Knights' Outpost" },
        new() { Name = "Summer Shore meat delivery", Category = "Courier Task", LevelRequired = 50, Experience = 4866, Notes = "Port Roberts → The Summer Shore" },
        new() { Name = "Aldarin pest remains delivery", Category = "Courier Task", LevelRequired = 50, Experience = 3695, Notes = "Void Knights' Outpost → Aldarin" },
        new() { Name = "Void Knights' Outpost mace delivery", Category = "Courier Task", LevelRequired = 55, Experience = 4982, Notes = "Civitas illa Fortis → Void Knights' Outpost" },
        new() { Name = "Port Roberts silk delivery", Category = "Courier Task", LevelRequired = 55, Experience = 6413, Notes = "Ardougne → Port Roberts" },
        new() { Name = "Port Roberts honey delivery", Category = "Courier Task", LevelRequired = 60, Experience = 7830, Notes = "Catherby → Port Roberts" },
        new() { Name = "Rellekka fabric delivery", Category = "Courier Task", LevelRequired = 62, Experience = 8688, Notes = "Sunset Coast → Rellekka" },
        new() { Name = "Sunset Coast warhammer delivery", Category = "Courier Task", LevelRequired = 62, Experience = 4344, Notes = "Rellekka → Sunset Coast" },
        new() { Name = "Rellekka arrowtip delivery", Category = "Courier Task", LevelRequired = 64, Experience = 8947, Notes = "Void Knights' Outpost → Rellekka" },
        new() { Name = "Etceteria sword delivery", Category = "Courier Task", LevelRequired = 65, Experience = 9626, Notes = "Sunset Coast → Etceteria" },
        new() { Name = "Port Tyras snakeskin delivery", Category = "Courier Task", LevelRequired = 66, Experience = 3313, Notes = "Musa Point → Port Tyras" },
        new() { Name = "Ardougne meat delivery", Category = "Courier Task", LevelRequired = 66, Experience = 5625, Notes = "Port Tyras → Ardougne" },
        new() { Name = "Rellekka halberd delivery", Category = "Courier Task", LevelRequired = 66, Experience = 6321, Notes = "Port Tyras → Rellekka" },
        new() { Name = "Deepfin Point warhammer delivery", Category = "Courier Task", LevelRequired = 72, Experience = 8732, Notes = "Rellekka → Deepfin Point" },
        new() { Name = "Prifddinas silk delivery", Category = "Courier Task", LevelRequired = 72, Experience = 6957, Notes = "Ardougne → Prifddinas" },
        new() { Name = "Aldarin monkfish delivery", Category = "Courier Task", LevelRequired = 75, Experience = 8255, Notes = "Piscatoris → Aldarin" },
        new() { Name = "Lunar Isle coal delivery", Category = "Courier Task", LevelRequired = 76, Experience = 8265, Notes = "Deepfin Point → Lunar Isle" },
        new() { Name = "Lunar Isle potion delivery", Category = "Courier Task", LevelRequired = 80, Experience = 11519, Notes = "Aldarin → Lunar Isle" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();
}
