using Microsoft.AspNetCore.Mvc;
using OsrsCalcTool.Api.Models;

namespace OsrsCalcTool.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private static readonly string[] SkillNames =
    [
        "Overall", "Attack", "Defence", "Strength", "Hitpoints",
        "Ranged", "Prayer", "Magic", "Cooking", "Woodcutting",
        "Fletching", "Fishing", "Firemaking", "Crafting", "Smithing",
        "Mining", "Herblore", "Agility", "Thieving", "Slayer",
        "Farming", "Runecrafting", "Hunter", "Construction", "Sailing"
    ];

    [HttpGet]
    [ProducesResponseType<string[]>(StatusCodes.Status200OK)]
    public IActionResult GetSkills() => Ok(SkillNames);

    [HttpGet("experience-table")]
    [ProducesResponseType<Dictionary<int, long>>(StatusCodes.Status200OK)]
    public IActionResult GetExperienceTable()
    {
        var table = Enumerable.Range(1, ExperienceTable.MaxLevel)
            .ToDictionary(level => level, ExperienceTable.GetXpForLevel);
        return Ok(table);
    }

    [HttpGet("{skill}/actions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetActions(string skill)
    {
        object? actions = skill.ToLowerInvariant() switch
        {
            "agility" => AgilityData.Actions,
            "construction" => ConstructionData.ToSkillActions(),
            "cooking" => CookingData.Actions,
            "crafting" => CraftingData.Actions,
            "farming" => FarmingData.Actions,
            "firemaking" => FiremakingData.Actions,
            "fishing" => FishingData.Actions,
            "fletching" => FletchingData.Actions,
            "herblore" => HerbloreData.Actions,
            "hunter" => HunterData.Actions,
            "magic" => MagicData.Actions,
            "mining" => MiningData.Actions,
            "prayer" => PrayerData.Actions,
            "runecrafting" => RunecraftingData.Actions,
            "sailing" => SailingData.Actions,
            "smithing" => SmithingData.ToSkillActions(),
            "thieving" => ThievingData.Actions,
            "woodcutting" => WoodcuttingData.Actions,
            _ => null
        };

        if (actions is null)
            return NotFound($"No actions found for skill '{skill}'.");

        return Ok(actions);
    }

    [HttpGet("{skill}/quests")]
    [ProducesResponseType<IReadOnlyList<string>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetQuests(string skill)
    {
        IReadOnlyList<string>? quests = skill.ToLowerInvariant() switch
        {
            "agility"      => AgilityData.Quests,
            "construction" => ConstructionData.Quests,
            "farming"      => FarmingPatchData.FarmingQuests,
            "fishing"      => FishingData.Quests,
            "fletching"    => FletchingData.Quests,
            "hunter"       => HunterData.Quests,
            "magic"        => MagicData.Quests,
            "mining"       => MiningData.Quests,
            "runecrafting" => RunecraftingData.Quests,
            "smithing"     => SmithingData.Quests,
            "thieving"     => ThievingData.Quests,
            _ => null
        };

        if (quests is null)
            return NotFound($"No quests found for skill '{skill}'.");

        return Ok(quests);
    }

    [HttpGet("farming/patches")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetFarmingPatches()
    {
        return Ok(new
        {
            TreePatches = FarmingPatchData.TreePatches,
            FruitTreePatches = FarmingPatchData.FruitTreePatches,
            HerbPatches = FarmingPatchData.HerbPatches,
            HardwoodPatches = FarmingPatchData.HardwoodPatches,
            SpecialPatches = FarmingPatchData.SpecialPatches,
        });
    }

    [HttpGet("{skill}/outfit")]
    [ProducesResponseType<OutfitDefinition>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSkillOutfit(string skill)
    {
        if (OutfitData.BySkill.TryGetValue(skill.ToLowerInvariant(), out var outfit))
            return Ok(outfit);
        return NotFound($"No outfit data found for skill '{skill}'.");
    }

    [HttpGet("prayer/bonuses")]
    [ProducesResponseType<IReadOnlyList<PrayerBonus>>(StatusCodes.Status200OK)]
    public IActionResult GetPrayerBonuses() => Ok(PrayerData.Bonuses);
}
