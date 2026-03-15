namespace OsrsCalcTool.Api.Models;

/// <summary>
/// Holds per-skill user selections (quests, outfit pieces, toggles, etc.)
/// that should persist across navigation and app restarts.
/// </summary>
public class SkillSelectionState
{
    public HashSet<string> CompletedQuests { get; set; } = [];
    public Dictionary<string, bool> OutfitPieces { get; set; } = [];
    public Dictionary<string, bool> Toggles { get; set; } = [];
    public Dictionary<string, string> Selections { get; set; } = [];
    public string? SelectedBonus { get; set; }
}
