namespace OsrsCalcTool.Api.Models;

public class AgilityAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public bool Members { get; init; }
    public string? Notes { get; init; }
    public string? QuestRequirement { get; init; }
}

public static class AgilityData
{
    public static IReadOnlyList<string> Quests { get; } =
    [
        "Song of the Elves",
        "Sins of the Father",
    ];

    public static IReadOnlyList<AgilityAction> Actions { get; } =
    [
        // ── Rooftop courses ─────────────────────────────────────────────
        new() { Name = "Gnome Stronghold course", Category = "Rooftop", LevelRequired = 1, Experience = 86.5, Notes = "Marks of grace" },
        new() { Name = "Draynor Village rooftop", Category = "Rooftop", LevelRequired = 10, Experience = 120, Members = true, Notes = "Marks of grace" },
        new() { Name = "Al Kharid rooftop", Category = "Rooftop", LevelRequired = 20, Experience = 180, Members = true, Notes = "Marks of grace" },
        new() { Name = "Varrock rooftop", Category = "Rooftop", LevelRequired = 30, Experience = 238, Members = true, Notes = "Marks of grace" },
        new() { Name = "Canifis rooftop", Category = "Rooftop", LevelRequired = 40, Experience = 240, Members = true, Notes = "Marks of grace" },
        new() { Name = "Falador rooftop", Category = "Rooftop", LevelRequired = 50, Experience = 440, Members = true, Notes = "Marks of grace" },
        new() { Name = "Seers' Village rooftop", Category = "Rooftop", LevelRequired = 60, Experience = 570, Members = true, Notes = "Marks of grace; Kandarin hard diary = 20% more marks" },
        new() { Name = "Pollnivneach rooftop", Category = "Rooftop", LevelRequired = 70, Experience = 890, Members = true, Notes = "Marks of grace" },
        new() { Name = "Rellekka rooftop", Category = "Rooftop", LevelRequired = 80, Experience = 780, Members = true, Notes = "Marks of grace" },
        new() { Name = "Ardougne rooftop", Category = "Rooftop", LevelRequired = 90, Experience = 793, Members = true, Notes = "Marks of grace; best at 90+" },

        // ── Other courses ───────────────────────────────────────────────
        new() { Name = "Barbarian Outpost course", Category = "Course", LevelRequired = 35, Experience = 153.2, Members = true },
        new() { Name = "Ape Atoll course", Category = "Course", LevelRequired = 48, Experience = 580, Members = true, Notes = "Requires greegree" },
        new() { Name = "Wilderness course", Category = "Course", LevelRequired = 52, Experience = 571.4, Members = true, Notes = "Wilderness; skull sceptre parts" },
        new() { Name = "Werewolf course", Category = "Course", LevelRequired = 60, Experience = 730, Members = true },
        new() { Name = "Dorgesh-Kaan course", Category = "Course", LevelRequired = 70, Experience = 2750, Members = true, Notes = "Per lap avg; slower completion" },
        new() { Name = "Prifddinas course", Category = "Course", LevelRequired = 75, Experience = 1340, Members = true, QuestRequirement = "Song of the Elves", Notes = "Crystal shards; high XP" },
        new() { Name = "Shayzien Advanced course", Category = "Course", LevelRequired = 45, Experience = 508, Members = true },
        new() { Name = "Colossal Wyrm course", Category = "Course", LevelRequired = 50, Experience = 600, Members = true, Notes = "Cam Torum" },

        // ── Hallowed Sepulchre ──────────────────────────────────────────
        new() { Name = "Hallowed Sepulchre (Floor 1)", Category = "Hallowed Sepulchre", LevelRequired = 52, Experience = 575, Members = true, QuestRequirement = "Sins of the Father" },
        new() { Name = "Hallowed Sepulchre (Floor 2)", Category = "Hallowed Sepulchre", LevelRequired = 62, Experience = 2200, Members = true, QuestRequirement = "Sins of the Father" },
        new() { Name = "Hallowed Sepulchre (Floor 3)", Category = "Hallowed Sepulchre", LevelRequired = 72, Experience = 4600, Members = true, QuestRequirement = "Sins of the Father" },
        new() { Name = "Hallowed Sepulchre (Floor 4)", Category = "Hallowed Sepulchre", LevelRequired = 82, Experience = 7800, Members = true, QuestRequirement = "Sins of the Father" },
        new() { Name = "Hallowed Sepulchre (Floor 5)", Category = "Hallowed Sepulchre", LevelRequired = 92, Experience = 13200, Members = true, QuestRequirement = "Sins of the Father", Notes = "Best Agility XP/hr in the game" },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();
}
