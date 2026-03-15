namespace OsrsCalcTool.Api.Models;

public class FarmingAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double PlantXp { get; init; }
    public double HarvestXp { get; init; }
    public double TotalXp => PlantXp + HarvestXp;
    public TimeSpan? GrowthTime { get; init; }
    public string? Payment { get; init; }
    public int PaymentQuantity { get; init; }
    public int? SaplingItemId { get; init; }
    public int? PaymentItemId { get; init; }
    public int? ItemId { get; init; }

    public string GrowthTimeDisplay => GrowthTime switch
    {
        null => "—",
        { TotalHours: >= 1 } t => $"{(int)t.TotalHours}h {t.Minutes:D2}m",
        { } t => $"{t.Minutes}m"
    };

    public string PaymentDisplay => Payment is not null
        ? $"{PaymentQuantity}x {Payment}"
        : "—";
}

public static class FarmingData
{
    public static IReadOnlyList<FarmingAction> Actions { get; } =
    [
        // Allotments (4 growth stages × 10 min each = 40 min)
        new() { Name = "Potato", Category = "Allotment", LevelRequired = 1, PlantXp = 8, HarvestXp = 9, GrowthTime = TimeSpan.FromMinutes(40), ItemId = 5318 },
        new() { Name = "Onion", Category = "Allotment", LevelRequired = 5, PlantXp = 9.5, HarvestXp = 10.5, GrowthTime = TimeSpan.FromMinutes(40), ItemId = 5319 },
        new() { Name = "Cabbage", Category = "Allotment", LevelRequired = 7, PlantXp = 10, HarvestXp = 11.5, GrowthTime = TimeSpan.FromMinutes(40), ItemId = 5324 },
        new() { Name = "Tomato", Category = "Allotment", LevelRequired = 12, PlantXp = 12.5, HarvestXp = 14, GrowthTime = TimeSpan.FromMinutes(40), ItemId = 5322 },
        new() { Name = "Sweetcorn", Category = "Allotment", LevelRequired = 20, PlantXp = 17, HarvestXp = 19, GrowthTime = TimeSpan.FromMinutes(60), ItemId = 5320 },
        new() { Name = "Strawberry", Category = "Allotment", LevelRequired = 31, PlantXp = 26, HarvestXp = 29, GrowthTime = TimeSpan.FromMinutes(60), ItemId = 5323 },
        new() { Name = "Watermelon", Category = "Allotment", LevelRequired = 47, PlantXp = 48.5, HarvestXp = 54.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5321 },
        new() { Name = "Snape grass", Category = "Allotment", LevelRequired = 61, PlantXp = 82, HarvestXp = 82, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 22879 },

        // Herbs (4 growth stages × 20 min each = 80 min)
        new() { Name = "Guam", Category = "Herb", LevelRequired = 9, PlantXp = 11, HarvestXp = 12.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5291 },
        new() { Name = "Marrentill", Category = "Herb", LevelRequired = 14, PlantXp = 13.5, HarvestXp = 15, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5292 },
        new() { Name = "Tarromin", Category = "Herb", LevelRequired = 19, PlantXp = 16, HarvestXp = 18, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5293 },
        new() { Name = "Harralander", Category = "Herb", LevelRequired = 26, PlantXp = 21.5, HarvestXp = 24, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5294 },
        new() { Name = "Ranarr", Category = "Herb", LevelRequired = 32, PlantXp = 27, HarvestXp = 30.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5295 },
        new() { Name = "Toadflax", Category = "Herb", LevelRequired = 38, PlantXp = 34, HarvestXp = 38.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5296 },
        new() { Name = "Irit", Category = "Herb", LevelRequired = 44, PlantXp = 43, HarvestXp = 48.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5297 },
        new() { Name = "Avantoe", Category = "Herb", LevelRequired = 50, PlantXp = 54.5, HarvestXp = 61.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5298 },
        new() { Name = "Kwuarm", Category = "Herb", LevelRequired = 56, PlantXp = 69, HarvestXp = 78, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5299 },
        new() { Name = "Snapdragon", Category = "Herb", LevelRequired = 62, PlantXp = 87.5, HarvestXp = 98.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5300 },
        new() { Name = "Cadantine", Category = "Herb", LevelRequired = 67, PlantXp = 106.5, HarvestXp = 120, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5301 },
        new() { Name = "Lantadyme", Category = "Herb", LevelRequired = 73, PlantXp = 134.5, HarvestXp = 151.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5302 },
        new() { Name = "Dwarf weed", Category = "Herb", LevelRequired = 79, PlantXp = 170.5, HarvestXp = 192, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5303 },
        new() { Name = "Torstol", Category = "Herb", LevelRequired = 85, PlantXp = 199.5, HarvestXp = 224.5, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5304 },

        // Hops
        new() { Name = "Barley", Category = "Hop", LevelRequired = 3, PlantXp = 8.5, HarvestXp = 9.5, GrowthTime = TimeSpan.FromMinutes(40), ItemId = 5305 },
        new() { Name = "Hammerstone", Category = "Hop", LevelRequired = 4, PlantXp = 9, HarvestXp = 10, GrowthTime = TimeSpan.FromMinutes(40), ItemId = 5307 },
        new() { Name = "Asgarnian", Category = "Hop", LevelRequired = 8, PlantXp = 10.9, HarvestXp = 12, GrowthTime = TimeSpan.FromMinutes(50), ItemId = 5308 },
        new() { Name = "Jute", Category = "Hop", LevelRequired = 13, PlantXp = 13, HarvestXp = 14.5, GrowthTime = TimeSpan.FromMinutes(50), ItemId = 5306 },
        new() { Name = "Yanillian", Category = "Hop", LevelRequired = 16, PlantXp = 14.5, HarvestXp = 16, GrowthTime = TimeSpan.FromMinutes(60), ItemId = 5309 },
        new() { Name = "Krandorian", Category = "Hop", LevelRequired = 21, PlantXp = 17.5, HarvestXp = 19.5, GrowthTime = TimeSpan.FromMinutes(70), ItemId = 5310 },
        new() { Name = "Wildblood", Category = "Hop", LevelRequired = 28, PlantXp = 23, HarvestXp = 26, GrowthTime = TimeSpan.FromMinutes(80), ItemId = 5311 },

        // Flowers (4 growth stages × 5 min each = 20 min)
        new() { Name = "Marigold", Category = "Flower", LevelRequired = 2, PlantXp = 8.5, HarvestXp = 47, GrowthTime = TimeSpan.FromMinutes(20), ItemId = 5096 },
        new() { Name = "Rosemary", Category = "Flower", LevelRequired = 11, PlantXp = 12, HarvestXp = 66.5, GrowthTime = TimeSpan.FromMinutes(20), ItemId = 5097 },
        new() { Name = "Nasturtium", Category = "Flower", LevelRequired = 24, PlantXp = 19.5, HarvestXp = 111, GrowthTime = TimeSpan.FromMinutes(20), ItemId = 5098 },
        new() { Name = "Woad", Category = "Flower", LevelRequired = 25, PlantXp = 20.5, HarvestXp = 115.5, GrowthTime = TimeSpan.FromMinutes(20), ItemId = 5099 },
        new() { Name = "Limpwurt", Category = "Flower", LevelRequired = 26, PlantXp = 21.5, HarvestXp = 120, GrowthTime = TimeSpan.FromMinutes(20), ItemId = 5100 },
        new() { Name = "White lily", Category = "Flower", LevelRequired = 52, PlantXp = 42, HarvestXp = 250, GrowthTime = TimeSpan.FromMinutes(20), ItemId = 22887 },

        // Trees
        new() { Name = "Oak tree", Category = "Tree", LevelRequired = 15, PlantXp = 14, HarvestXp = 467.3, GrowthTime = new TimeSpan(3, 20, 0), Payment = "Basket of tomatoes", PaymentQuantity = 1, SaplingItemId = 5370, PaymentItemId = 5968, ItemId = 5370 },
        new() { Name = "Willow tree", Category = "Tree", LevelRequired = 30, PlantXp = 25, HarvestXp = 1456.5, GrowthTime = new TimeSpan(4, 0, 0), Payment = "Basket of apples", PaymentQuantity = 1, SaplingItemId = 5371, PaymentItemId = 5986, ItemId = 5371 },
        new() { Name = "Maple tree", Category = "Tree", LevelRequired = 45, PlantXp = 45, HarvestXp = 3403.4, GrowthTime = new TimeSpan(5, 20, 0), Payment = "Basket of oranges", PaymentQuantity = 1, SaplingItemId = 5372, PaymentItemId = 5396, ItemId = 5372 },
        new() { Name = "Yew tree", Category = "Tree", LevelRequired = 60, PlantXp = 81, HarvestXp = 7069.9, GrowthTime = new TimeSpan(6, 40, 0), Payment = "Cactus spine", PaymentQuantity = 10, SaplingItemId = 5373, PaymentItemId = 6016, ItemId = 5373 },
        new() { Name = "Magic tree", Category = "Tree", LevelRequired = 75, PlantXp = 145.5, HarvestXp = 13768.3, GrowthTime = new TimeSpan(8, 0, 0), Payment = "Coconut", PaymentQuantity = 25, SaplingItemId = 5374, PaymentItemId = 5974, ItemId = 5374 },

        // Fruit trees
        new() { Name = "Apple tree", Category = "Fruit Tree", LevelRequired = 27, PlantXp = 22, HarvestXp = 1199.5, GrowthTime = new TimeSpan(16, 0, 0), Payment = "Sweetcorn", PaymentQuantity = 9, SaplingItemId = 5496, PaymentItemId = 5988, ItemId = 5496 },
        new() { Name = "Banana tree", Category = "Fruit Tree", LevelRequired = 33, PlantXp = 28, HarvestXp = 1750.5, GrowthTime = new TimeSpan(16, 0, 0), Payment = "Basket of apples", PaymentQuantity = 4, SaplingItemId = 5497, PaymentItemId = 5986, ItemId = 5497 },
        new() { Name = "Orange tree", Category = "Fruit Tree", LevelRequired = 39, PlantXp = 35.5, HarvestXp = 2470.2, GrowthTime = new TimeSpan(16, 0, 0), Payment = "Basket of strawberries", PaymentQuantity = 3, SaplingItemId = 5498, PaymentItemId = 5406, ItemId = 5498 },
        new() { Name = "Curry tree", Category = "Fruit Tree", LevelRequired = 42, PlantXp = 40, HarvestXp = 2906.9, GrowthTime = new TimeSpan(16, 0, 0), Payment = "Basket of bananas", PaymentQuantity = 5, SaplingItemId = 5499, PaymentItemId = 5416, ItemId = 5499 },
        new() { Name = "Pineapple tree", Category = "Fruit Tree", LevelRequired = 51, PlantXp = 57, HarvestXp = 4605.7, GrowthTime = new TimeSpan(16, 0, 0), Payment = "Watermelon", PaymentQuantity = 10, SaplingItemId = 5500, PaymentItemId = 5982, ItemId = 5500 },
        new() { Name = "Papaya tree", Category = "Fruit Tree", LevelRequired = 57, PlantXp = 72, HarvestXp = 6146.4, GrowthTime = new TimeSpan(16, 0, 0), Payment = "Pineapple", PaymentQuantity = 10, SaplingItemId = 5501, PaymentItemId = 2114, ItemId = 5501 },
        new() { Name = "Palm tree", Category = "Fruit Tree", LevelRequired = 68, PlantXp = 110.5, HarvestXp = 10150.1, GrowthTime = new TimeSpan(16, 0, 0), Payment = "Papaya fruit", PaymentQuantity = 15, SaplingItemId = 5502, PaymentItemId = 5972, ItemId = 5502 },
        new() { Name = "Dragonfruit tree", Category = "Fruit Tree", LevelRequired = 81, PlantXp = 140, HarvestXp = 17335, GrowthTime = new TimeSpan(16, 0, 0), Payment = "Coconut", PaymentQuantity = 15, SaplingItemId = 22866, PaymentItemId = 5974, ItemId = 22866 },

        // Hardwood
        new() { Name = "Teak tree", Category = "Hardwood", LevelRequired = 35, PlantXp = 35, HarvestXp = 7290, GrowthTime = new TimeSpan(74, 40, 0), Payment = "Limpwurt root", PaymentQuantity = 15, SaplingItemId = 21477, PaymentItemId = 225, ItemId = 21477 },
        new() { Name = "Mahogany tree", Category = "Hardwood", LevelRequired = 55, PlantXp = 63, HarvestXp = 15720, GrowthTime = new TimeSpan(85, 20, 0), Payment = "Yanillian hops", PaymentQuantity = 25, SaplingItemId = 21480, PaymentItemId = 6009, ItemId = 21480 },
        new() { Name = "Camphor tree", Category = "Hardwood", LevelRequired = 66, PlantXp = 88, HarvestXp = 17840, GrowthTime = new TimeSpan(85, 20, 0), Payment = "White berries", PaymentQuantity = 10, SaplingItemId = 31502, PaymentItemId = 239, ItemId = 31502 },
        new() { Name = "Ironwood tree", Category = "Hardwood", LevelRequired = 80, PlantXp = 145, HarvestXp = 20380, GrowthTime = new TimeSpan(85, 20, 0), Payment = "Curry leaf", PaymentQuantity = 10, SaplingItemId = 31505, PaymentItemId = 5970, ItemId = 31505 },
        new() { Name = "Rosewood tree", Category = "Hardwood", LevelRequired = 92, PlantXp = 252, HarvestXp = 23100, GrowthTime = new TimeSpan(106, 40, 0), Payment = "Dragonfruit", PaymentQuantity = 8, SaplingItemId = 31508, PaymentItemId = 22929, ItemId = 31508 },

        // Special
        new() { Name = "Calquat tree", Category = "Special", LevelRequired = 72, PlantXp = 129.5, HarvestXp = 12096, GrowthTime = new TimeSpan(21, 20, 0), Payment = "Poison ivy berries", PaymentQuantity = 8, SaplingItemId = 5503, PaymentItemId = 6018, ItemId = 5503 },
        new() { Name = "Crystal tree", Category = "Crystal", LevelRequired = 74, PlantXp = 126, HarvestXp = 13240, GrowthTime = new TimeSpan(8, 0, 0), ItemId = 23661 },
        new() { Name = "Spirit tree", Category = "Special", LevelRequired = 83, PlantXp = 199.5, HarvestXp = 19301.8, GrowthTime = new TimeSpan(58, 40, 0), Payment = "Monkey nuts", PaymentQuantity = 5, SaplingItemId = 5375, PaymentItemId = 4012, ItemId = 5375 },
        new() { Name = "Celastrus tree", Category = "Special", LevelRequired = 85, PlantXp = 204, HarvestXp = 14130, GrowthTime = new TimeSpan(13, 20, 0), Payment = "Potato cactus", PaymentQuantity = 8, SaplingItemId = 22856, PaymentItemId = 3138, ItemId = 22856 },
        new() { Name = "Redwood tree", Category = "Special", LevelRequired = 90, PlantXp = 230, HarvestXp = 22450, GrowthTime = new TimeSpan(106, 40, 0), Payment = "Dragonfruit", PaymentQuantity = 6, SaplingItemId = 22871, PaymentItemId = 22929, ItemId = 22871 },
        new() { Name = "Hespori", Category = "Special", LevelRequired = 65, PlantXp = 0, HarvestXp = 12600, GrowthTime = new TimeSpan(22, 0, 0), ItemId = 22875 },
        new() { Name = "Giant seaweed", Category = "Special", LevelRequired = 23, PlantXp = 21, HarvestXp = 21, GrowthTime = TimeSpan.FromMinutes(40), ItemId = 21490 },
        new() { Name = "Cactus", Category = "Special", LevelRequired = 55, PlantXp = 66.5, HarvestXp = 374, GrowthTime = new TimeSpan(9, 20, 0), ItemId = 5280 },
        new() { Name = "Potato cactus", Category = "Special", LevelRequired = 64, PlantXp = 68, HarvestXp = 2592, GrowthTime = new TimeSpan(9, 20, 0), ItemId = 22873 },

        // Bushes (5 growth stages × 20 min each = various)
        new() { Name = "Redberry bush", Category = "Bush", LevelRequired = 10, PlantXp = 11.5, HarvestXp = 64, GrowthTime = new TimeSpan(1, 40, 0), ItemId = 5101 },
        new() { Name = "Cadavaberry bush", Category = "Bush", LevelRequired = 22, PlantXp = 18, HarvestXp = 102.5, GrowthTime = new TimeSpan(2, 0, 0), ItemId = 5102 },
        new() { Name = "Dwellberry bush", Category = "Bush", LevelRequired = 36, PlantXp = 31.5, HarvestXp = 177.5, GrowthTime = new TimeSpan(2, 20, 0), ItemId = 5103 },
        new() { Name = "Jangerberry bush", Category = "Bush", LevelRequired = 48, PlantXp = 50.5, HarvestXp = 284.5, GrowthTime = new TimeSpan(2, 40, 0), ItemId = 5104 },
        new() { Name = "Whiteberry bush", Category = "Bush", LevelRequired = 59, PlantXp = 78, HarvestXp = 437.5, GrowthTime = new TimeSpan(3, 0, 0), ItemId = 5105 },
        new() { Name = "Poison ivy bush", Category = "Bush", LevelRequired = 70, PlantXp = 120, HarvestXp = 674, GrowthTime = new TimeSpan(3, 20, 0), ItemId = 5106 },

        // Compost (no growth time — instant use)
        new() { Name = "Compost", Category = "Compost", LevelRequired = 1, PlantXp = 0, HarvestXp = 18, ItemId = 6032 },
        new() { Name = "Supercompost", Category = "Compost", LevelRequired = 1, PlantXp = 0, HarvestXp = 26, ItemId = 6034 },
        new() { Name = "Ultracompost", Category = "Compost", LevelRequired = 1, PlantXp = 0, HarvestXp = 36, ItemId = 21483 },

        // Mushroom
        new() { Name = "Bittercap mushroom", Category = "Mushroom", LevelRequired = 53, PlantXp = 61.5, HarvestXp = 413.4, GrowthTime = new TimeSpan(4, 0, 0), ItemId = 5282 },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();
}
