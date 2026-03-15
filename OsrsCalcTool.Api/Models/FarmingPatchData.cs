namespace OsrsCalcTool.Api.Models;

public class FarmingPatch
{
    public required string Location { get; init; }
    public required string PatchType { get; init; }
    public int FarmingLevelRequired { get; init; }
    public string? QuestRequired { get; init; }
    public int? OtherSkillLevel { get; init; }
    public string? OtherSkillName { get; init; }
    public int PatchCount { get; init; } = 1;
}

public static class FarmingPatchData
{
    public static IReadOnlyList<string> FarmingQuests { get; } =
    [
        "Priest in Peril",
        "Bone Voyage",
        "My Arm's Big Adventure",
        "Making Friends with My Arm",
        "Mourning's End Part I",
        "Song of the Elves",
        "Children of the Sun",
        "The Ribbiting Tale of a Lily Pad Labour Dispute",
    ];

    public static IReadOnlyList<FarmingPatch> TreePatches { get; } =
    [
        new() { Location = "Lumbridge", PatchType = "Tree", FarmingLevelRequired = 1 },
        new() { Location = "Varrock", PatchType = "Tree", FarmingLevelRequired = 1 },
        new() { Location = "Falador Park", PatchType = "Tree", FarmingLevelRequired = 1 },
        new() { Location = "Taverley", PatchType = "Tree", FarmingLevelRequired = 1 },
        new() { Location = "Gnome Stronghold", PatchType = "Tree", FarmingLevelRequired = 1 },
        new() { Location = "Farming Guild", PatchType = "Tree", FarmingLevelRequired = 65 },
        new() { Location = "Nemus Retreat (Varlamore)", PatchType = "Tree", FarmingLevelRequired = 1, QuestRequired = "Children of the Sun" },
    ];

    public static IReadOnlyList<FarmingPatch> FruitTreePatches { get; } =
    [
        new() { Location = "Gnome Stronghold", PatchType = "Fruit Tree", FarmingLevelRequired = 1 },
        new() { Location = "Tree Gnome Village", PatchType = "Fruit Tree", FarmingLevelRequired = 1 },
        new() { Location = "Brimhaven", PatchType = "Fruit Tree", FarmingLevelRequired = 1 },
        new() { Location = "Catherby", PatchType = "Fruit Tree", FarmingLevelRequired = 1 },
        new() { Location = "Lletya", PatchType = "Fruit Tree", FarmingLevelRequired = 1, QuestRequired = "Mourning's End Part I" },
        new() { Location = "Farming Guild", PatchType = "Fruit Tree", FarmingLevelRequired = 85 },
        new() { Location = "Kastori (Varlamore)", PatchType = "Fruit Tree", FarmingLevelRequired = 1, QuestRequired = "Children of the Sun" },
    ];

    public static IReadOnlyList<FarmingPatch> HerbPatches { get; } =
    [
        new() { Location = "Falador", PatchType = "Herb", FarmingLevelRequired = 1 },
        new() { Location = "Catherby", PatchType = "Herb", FarmingLevelRequired = 1 },
        new() { Location = "Ardougne", PatchType = "Herb", FarmingLevelRequired = 1 },
        new() { Location = "Morytania", PatchType = "Herb", FarmingLevelRequired = 1, QuestRequired = "Priest in Peril" },
        new() { Location = "Hosidius", PatchType = "Herb", FarmingLevelRequired = 1 },
        new() { Location = "Farming Guild", PatchType = "Herb", FarmingLevelRequired = 65 },
        new() { Location = "Troll Stronghold", PatchType = "Herb", FarmingLevelRequired = 1, QuestRequired = "My Arm's Big Adventure" },
        new() { Location = "Weiss", PatchType = "Herb", FarmingLevelRequired = 1, QuestRequired = "Making Friends with My Arm" },
        new() { Location = "Civitas illa Fortis (Varlamore)", PatchType = "Herb", FarmingLevelRequired = 1, QuestRequired = "Children of the Sun" },
    ];

    public static IReadOnlyList<FarmingPatch> HardwoodPatches { get; } =
    [
        new() { Location = "Fossil Island (x3)", PatchType = "Hardwood", FarmingLevelRequired = 1, QuestRequired = "Bone Voyage", PatchCount = 3 },
        new() { Location = "Varlamore", PatchType = "Hardwood", FarmingLevelRequired = 1, QuestRequired = "The Ribbiting Tale of a Lily Pad Labour Dispute" },
        new() { Location = "Angler's Retreat", PatchType = "Hardwood", FarmingLevelRequired = 1, OtherSkillLevel = 51, OtherSkillName = "Sailing" },
    ];

    public static IReadOnlyList<FarmingPatch> SpecialPatches { get; } =
    [
        new() { Location = "Tai Bwo Wannai", PatchType = "Calquat", FarmingLevelRequired = 72 },
        new() { Location = "Kastori (Varlamore)", PatchType = "Calquat", FarmingLevelRequired = 72, QuestRequired = "Children of the Sun" },
        new() { Location = "The Summer Shore", PatchType = "Calquat", FarmingLevelRequired = 72 },
        new() { Location = "Prifddinas", PatchType = "Crystal", FarmingLevelRequired = 74, QuestRequired = "Song of the Elves" },
        new() { Location = "Farming Guild", PatchType = "Celastrus", FarmingLevelRequired = 85 },
        new() { Location = "Farming Guild", PatchType = "Redwood", FarmingLevelRequired = 90 },
    ];

    public static bool IsAccessible(FarmingPatch patch, int farmingLevel, HashSet<string> completedQuests, Dictionary<string, int>? otherSkills = null)
    {
        if (farmingLevel < patch.FarmingLevelRequired)
            return false;

        if (patch.QuestRequired is not null && !completedQuests.Contains(patch.QuestRequired))
            return false;

        if (patch.OtherSkillName is not null && patch.OtherSkillLevel is not null)
        {
            var level = otherSkills?.GetValueOrDefault(patch.OtherSkillName, 0) ?? 0;
            if (level < patch.OtherSkillLevel)
                return false;
        }

        return true;
    }
}
