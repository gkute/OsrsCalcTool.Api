namespace OsrsCalcTool.Api.Models;

public class RunCategoryPlan
{
    public required string Category { get; init; }
    public required string SeedName { get; init; }
    public int AccessiblePatches { get; init; }
    public double XpPerRun { get; init; }
    public double RunsPerDay { get; init; }
    public double XpPerDay => XpPerRun * RunsPerDay;
    public double GrowthHours { get; init; }
    public string? PaymentItem { get; init; }
    public int PaymentPerPatch { get; init; }
    public int? SaplingItemId { get; init; }
    public int? PaymentItemId { get; init; }
    public int SaplingPrice { get; set; }
    public int PaymentItemPrice { get; set; }

    public string RunFrequency => RunsPerDay switch
    {
        >= 2 => $"{RunsPerDay:F0}x daily",
        >= 1 => "1x daily",
        >= 0.5 => $"Every {1.0 / RunsPerDay:F1} days",
        > 0 => $"Every {1.0 / RunsPerDay:F0} days",
        _ => "—"
    };

    public int TotalRunsNeeded(double totalDays) =>
        (int)Math.Ceiling(totalDays * RunsPerDay);

    public int TotalSeedsNeeded(double totalDays) =>
        TotalRunsNeeded(totalDays) * AccessiblePatches;

    public int TotalPaymentNeeded(double totalDays) =>
        PaymentItem is not null ? TotalSeedsNeeded(totalDays) * PaymentPerPatch : 0;

    public long TotalSaplingCost(double totalDays) =>
        (long)TotalSeedsNeeded(totalDays) * SaplingPrice;

    public long TotalPaymentCost(double totalDays) =>
        (long)TotalPaymentNeeded(totalDays) * PaymentItemPrice;

    public long TotalCost(double totalDays) =>
        TotalSaplingCost(totalDays) + TotalPaymentCost(totalDays);

    public string PaymentDisplay => PaymentItem is not null
        ? $"{PaymentPerPatch}x {PaymentItem}"
        : "—";
}

public class FarmRunPlan
{
    public List<RunCategoryPlan> Categories { get; init; } = [];
    public double TotalDailyXp => Categories.Sum(c => c.XpPerDay);
    public double DaysToTarget(long xpNeeded) =>
        TotalDailyXp > 0 ? xpNeeded / TotalDailyXp : 0;

    public static double GetRunsPerDay(string category, double growthHours) => category switch
    {
        "Herb" => 2,
        "Tree" => Math.Min(2, Math.Floor(24.0 / growthHours)),
        "Fruit Tree" => 1,
        "Hardwood" => growthHours > 0 ? 24.0 / growthHours : 0,
        "Calquat" => 1,
        "Crystal" => 1,
        "Celastrus" => 1,
        "Redwood" => growthHours > 0 ? 24.0 / growthHours : 0,
        _ => growthHours > 0 ? Math.Min(2, Math.Floor(24.0 / growthHours)) : 0
    };
}
