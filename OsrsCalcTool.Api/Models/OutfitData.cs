namespace OsrsCalcTool.Api.Models;

public record OutfitPiece(string Name, double BonusPercent);

public class OutfitDefinition
{
    public required string OutfitName { get; init; }
    public required IReadOnlyList<OutfitPiece> Pieces { get; init; }
    public double FullSetBonusPercent { get; init; }
    public string? Notes { get; init; }
}

public static class OutfitData
{
    public static readonly Dictionary<string, OutfitDefinition> BySkill = new()
    {
        ["mining"] = new OutfitDefinition
        {
            OutfitName = "Prospector",
            Pieces =
            [
                new("Prospector helmet", 0.4),
                new("Prospector jacket", 0.8),
                new("Prospector legs", 0.6),
                new("Prospector boots", 0.2),
            ],
            FullSetBonusPercent = 0.5,
        },
        ["fishing"] = new OutfitDefinition
        {
            OutfitName = "Angler",
            Pieces =
            [
                new("Angler hat", 0.4),
                new("Angler top", 0.8),
                new("Angler waders", 0.6),
                new("Angler boots", 0.2),
            ],
            FullSetBonusPercent = 0.5,
        },
        ["woodcutting"] = new OutfitDefinition
        {
            OutfitName = "Lumberjack",
            Pieces =
            [
                new("Lumberjack hat", 0.4),
                new("Lumberjack top", 0.8),
                new("Lumberjack legs", 0.6),
                new("Lumberjack boots", 0.2),
            ],
            FullSetBonusPercent = 0.5,
        },
        ["firemaking"] = new OutfitDefinition
        {
            OutfitName = "Pyromancer",
            Pieces =
            [
                new("Pyromancer hood", 0.4),
                new("Pyromancer garb", 0.8),
                new("Pyromancer robe", 0.6),
                new("Pyromancer boots", 0.2),
            ],
            FullSetBonusPercent = 0.5,
        },
        ["smithing"] = new OutfitDefinition
        {
            OutfitName = "Goldsmith Gauntlets",
            Pieces = [new("Goldsmith gauntlets", 0)],
            FullSetBonusPercent = 0,
            Notes = "Gold bars: 22.5 → 56.2 XP",
        },
    };
}
