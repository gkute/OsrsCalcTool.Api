namespace OsrsCalcTool.Api.Models;

public class HiscoreEntry
{
    public string SkillName { get; set; } = string.Empty;
    public int Rank { get; set; }
    public int Level { get; set; }
    public long Experience { get; set; }
}
