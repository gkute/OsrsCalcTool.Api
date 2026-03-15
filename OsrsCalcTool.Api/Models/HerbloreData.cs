namespace OsrsCalcTool.Api.Models;

public record Ingredient(string Name, int? ItemId = null, int Quantity = 1);

public class HerbloreAction
{
    public required string Name { get; init; }
    public required string Category { get; init; }
    public int LevelRequired { get; init; }
    public double Experience { get; init; }
    public required IReadOnlyList<Ingredient> Ingredients { get; init; }
    public Ingredient? UnfPotionAlternative { get; init; }
    public int? OutputItemId { get; init; }

    public string MaterialsDisplay => GetMaterialsDisplay(false);

    public string GetMaterialsDisplay(bool useUnfPotion)
    {
        var ingredients = GetEffectiveIngredients(useUnfPotion);
        return ingredients.Count switch
        {
            0 => "—",
            _ => string.Join(" + ", ingredients.Select(FormatIngredient))
        };
    }

    public IReadOnlyList<Ingredient> GetEffectiveIngredients(bool useUnfPotion)
    {
        if (useUnfPotion && UnfPotionAlternative is not null)
            return [UnfPotionAlternative, .. Ingredients.Skip(1)];
        return Ingredients;
    }

    private static string FormatIngredient(Ingredient i) =>
        i.Quantity > 1 ? $"{i.Name} x{i.Quantity}" : i.Name;

    /// <summary>
    /// Calculates the GE 2% tax on a sell price, floored, capped at 5M per item.
    /// Items sold below 50gp have no tax.
    /// </summary>
    public static long CalculateGeTax(long sellPrice)
    {
        if (sellPrice < 50) return 0;
        var tax = (long)(sellPrice * 0.02);
        return Math.Min(tax, 5_000_000);
    }
}

public static class HerbloreData
{
    public static IReadOnlyList<HerbloreAction> Actions { get; } =
    [
        // Cleaning herbs
        new() { Name = "Clean guam leaf", Category = "Clean Herb", LevelRequired = 3, Experience = 2.5, Ingredients = [new("Grimy guam leaf", 199)], OutputItemId = 249 },
        new() { Name = "Clean marrentill", Category = "Clean Herb", LevelRequired = 5, Experience = 3.8, Ingredients = [new("Grimy marrentill", 201)], OutputItemId = 251 },
        new() { Name = "Clean tarromin", Category = "Clean Herb", LevelRequired = 11, Experience = 5, Ingredients = [new("Grimy tarromin", 203)], OutputItemId = 253 },
        new() { Name = "Clean harralander", Category = "Clean Herb", LevelRequired = 20, Experience = 6.3, Ingredients = [new("Grimy harralander", 205)], OutputItemId = 255 },
        new() { Name = "Clean ranarr weed", Category = "Clean Herb", LevelRequired = 25, Experience = 7.5, Ingredients = [new("Grimy ranarr weed", 207)], OutputItemId = 257 },
        new() { Name = "Clean toadflax", Category = "Clean Herb", LevelRequired = 30, Experience = 8, Ingredients = [new("Grimy toadflax", 3049)], OutputItemId = 2998 },
        new() { Name = "Clean irit leaf", Category = "Clean Herb", LevelRequired = 40, Experience = 8.8, Ingredients = [new("Grimy irit leaf", 209)], OutputItemId = 259 },
        new() { Name = "Clean avantoe", Category = "Clean Herb", LevelRequired = 48, Experience = 10, Ingredients = [new("Grimy avantoe", 211)], OutputItemId = 261 },
        new() { Name = "Clean kwuarm", Category = "Clean Herb", LevelRequired = 54, Experience = 11.3, Ingredients = [new("Grimy kwuarm", 213)], OutputItemId = 263 },
        new() { Name = "Clean huasca", Category = "Clean Herb", LevelRequired = 58, Experience = 11.8, Ingredients = [new("Grimy huasca", 30094)], OutputItemId = 30097 },
        new() { Name = "Clean snapdragon", Category = "Clean Herb", LevelRequired = 59, Experience = 11.8, Ingredients = [new("Grimy snapdragon", 3051)], OutputItemId = 3000 },
        new() { Name = "Clean cadantine", Category = "Clean Herb", LevelRequired = 65, Experience = 12.5, Ingredients = [new("Grimy cadantine", 215)], OutputItemId = 265 },
        new() { Name = "Clean lantadyme", Category = "Clean Herb", LevelRequired = 67, Experience = 13.1, Ingredients = [new("Grimy lantadyme", 2485)], OutputItemId = 2481 },
        new() { Name = "Clean dwarf weed", Category = "Clean Herb", LevelRequired = 70, Experience = 13.8, Ingredients = [new("Grimy dwarf weed", 217)], OutputItemId = 267 },
        new() { Name = "Clean torstol", Category = "Clean Herb", LevelRequired = 75, Experience = 15, Ingredients = [new("Grimy torstol", 219)], OutputItemId = 269 },

        // Unfinished potions
        new() { Name = "Guam potion (unf)", Category = "Unfinished Potion", LevelRequired = 3, Experience = 0, Ingredients = [new("Guam leaf", 249), new("Vial of water", 227)], OutputItemId = 91 },
        new() { Name = "Marrentill potion (unf)", Category = "Unfinished Potion", LevelRequired = 5, Experience = 0, Ingredients = [new("Marrentill", 251), new("Vial of water", 227)], OutputItemId = 93 },
        new() { Name = "Tarromin potion (unf)", Category = "Unfinished Potion", LevelRequired = 12, Experience = 0, Ingredients = [new("Tarromin", 253), new("Vial of water", 227)], OutputItemId = 95 },
        new() { Name = "Harralander potion (unf)", Category = "Unfinished Potion", LevelRequired = 22, Experience = 0, Ingredients = [new("Harralander", 255), new("Vial of water", 227)], OutputItemId = 97 },
        new() { Name = "Ranarr potion (unf)", Category = "Unfinished Potion", LevelRequired = 30, Experience = 0, Ingredients = [new("Ranarr weed", 257), new("Vial of water", 227)], OutputItemId = 99 },
        new() { Name = "Toadflax potion (unf)", Category = "Unfinished Potion", LevelRequired = 34, Experience = 0, Ingredients = [new("Toadflax", 2998), new("Vial of water", 227)], OutputItemId = 3002 },
        new() { Name = "Irit potion (unf)", Category = "Unfinished Potion", LevelRequired = 45, Experience = 0, Ingredients = [new("Irit leaf", 259), new("Vial of water", 227)], OutputItemId = 101 },
        new() { Name = "Avantoe potion (unf)", Category = "Unfinished Potion", LevelRequired = 50, Experience = 0, Ingredients = [new("Avantoe", 261), new("Vial of water", 227)], OutputItemId = 103 },
        new() { Name = "Kwuarm potion (unf)", Category = "Unfinished Potion", LevelRequired = 55, Experience = 0, Ingredients = [new("Kwuarm", 263), new("Vial of water", 227)], OutputItemId = 105 },
        new() { Name = "Huasca potion (unf)", Category = "Unfinished Potion", LevelRequired = 58, Experience = 0, Ingredients = [new("Huasca", 30097), new("Vial of water", 227)], OutputItemId = 30100 },
        new() { Name = "Snapdragon potion (unf)", Category = "Unfinished Potion", LevelRequired = 63, Experience = 0, Ingredients = [new("Snapdragon", 3000), new("Vial of water", 227)], OutputItemId = 3004 },
        new() { Name = "Cadantine potion (unf)", Category = "Unfinished Potion", LevelRequired = 66, Experience = 0, Ingredients = [new("Cadantine", 265), new("Vial of water", 227)], OutputItemId = 107 },
        new() { Name = "Cadantine blood potion (unf)", Category = "Unfinished Potion", LevelRequired = 80, Experience = 0, Ingredients = [new("Cadantine", 265), new("Vial of blood", 22446)], OutputItemId = 22443 },
        new() { Name = "Lantadyme potion (unf)", Category = "Unfinished Potion", LevelRequired = 69, Experience = 0, Ingredients = [new("Lantadyme", 2481), new("Vial of water", 227)], OutputItemId = 2483 },
        new() { Name = "Dwarf weed potion (unf)", Category = "Unfinished Potion", LevelRequired = 72, Experience = 0, Ingredients = [new("Dwarf weed", 267), new("Vial of water", 227)], OutputItemId = 109 },
        new() { Name = "Torstol potion (unf)", Category = "Unfinished Potion", LevelRequired = 78, Experience = 0, Ingredients = [new("Torstol", 269), new("Vial of water", 227)], OutputItemId = 111 },

        // Potions
        new() { Name = "Attack potion", Category = "Potion", LevelRequired = 3, Experience = 25, Ingredients = [new("Guam leaf", 249), new("Eye of newt", 221)], UnfPotionAlternative = new("Guam potion (unf)", 91), OutputItemId = 121 },
        new() { Name = "Antipoison", Category = "Potion", LevelRequired = 5, Experience = 37.5, Ingredients = [new("Marrentill", 251), new("Unicorn horn dust", 235)], UnfPotionAlternative = new("Marrentill potion (unf)", 93), OutputItemId = 175 },
        new() { Name = "Relicym's balm", Category = "Potion", LevelRequired = 8, Experience = 40, Ingredients = [new("Rogue's purse"), new("Snake weed")], OutputItemId = 4844 },
        new() { Name = "Strength potion", Category = "Potion", LevelRequired = 12, Experience = 50, Ingredients = [new("Tarromin", 253), new("Limpwurt root", 225)], UnfPotionAlternative = new("Tarromin potion (unf)", 95), OutputItemId = 115 },
        new() { Name = "Serum 207", Category = "Potion", LevelRequired = 15, Experience = 50, Ingredients = [new("Tarromin", 253), new("Ashes", 592)], UnfPotionAlternative = new("Tarromin potion (unf)", 95), OutputItemId = 3410 },
        new() { Name = "Guthix rest tea", Category = "Potion", LevelRequired = 18, Experience = 59, Ingredients = [new("Harralander", 255), new("Guam leaf", 249, 2), new("Marrentill", 251)], OutputItemId = 4419 },
        new() { Name = "Compost potion", Category = "Potion", LevelRequired = 22, Experience = 60, Ingredients = [new("Harralander", 255), new("Volcanic ash", 21622)], UnfPotionAlternative = new("Harralander potion (unf)", 97), OutputItemId = 6472 },
        new() { Name = "Restore potion", Category = "Potion", LevelRequired = 22, Experience = 62.5, Ingredients = [new("Harralander", 255), new("Red spiders' eggs", 223)], UnfPotionAlternative = new("Harralander potion (unf)", 97), OutputItemId = 127 },
        new() { Name = "Guthix balance", Category = "Potion", LevelRequired = 22, Experience = 50, Ingredients = [new("Restore potion(3)", 127), new("Garlic", 1550), new("Silver dust", 7650)], OutputItemId = 7662 },
        new() { Name = "Blamish oil", Category = "Potion", LevelRequired = 25, Experience = 80, Ingredients = [new("Harralander", 255), new("Blamish snail slime")], UnfPotionAlternative = new("Harralander potion (unf)", 97) },
        new() { Name = "Energy potion", Category = "Potion", LevelRequired = 26, Experience = 67.5, Ingredients = [new("Harralander", 255), new("Chocolate dust", 1975)], UnfPotionAlternative = new("Harralander potion (unf)", 97), OutputItemId = 3010 },
        new() { Name = "Defence potion", Category = "Potion", LevelRequired = 30, Experience = 75, Ingredients = [new("Ranarr weed", 257), new("White berries", 239)], UnfPotionAlternative = new("Ranarr potion (unf)", 99), OutputItemId = 133 },
        new() { Name = "Agility potion", Category = "Potion", LevelRequired = 34, Experience = 80, Ingredients = [new("Toadflax", 2998), new("Toad's legs", 2152)], UnfPotionAlternative = new("Toadflax potion (unf)", 3002), OutputItemId = 3034 },
        new() { Name = "Combat potion", Category = "Potion", LevelRequired = 36, Experience = 84, Ingredients = [new("Harralander", 255), new("Goat horn dust", 9736)], UnfPotionAlternative = new("Harralander potion (unf)", 97), OutputItemId = 9741 },
        new() { Name = "Prayer potion", Category = "Potion", LevelRequired = 38, Experience = 87.5, Ingredients = [new("Ranarr weed", 257), new("Snape grass", 231)], UnfPotionAlternative = new("Ranarr potion (unf)", 99), OutputItemId = 139 },
        new() { Name = "Super attack", Category = "Potion", LevelRequired = 45, Experience = 100, Ingredients = [new("Irit leaf", 259), new("Eye of newt", 221)], UnfPotionAlternative = new("Irit potion (unf)", 101), OutputItemId = 145 },
        new() { Name = "Superantipoison", Category = "Potion", LevelRequired = 48, Experience = 106.3, Ingredients = [new("Irit leaf", 259), new("Unicorn horn dust", 235)], UnfPotionAlternative = new("Irit potion (unf)", 101), OutputItemId = 181 },
        new() { Name = "Fishing potion", Category = "Potion", LevelRequired = 50, Experience = 112.5, Ingredients = [new("Avantoe", 261), new("Snape grass", 231)], UnfPotionAlternative = new("Avantoe potion (unf)", 103), OutputItemId = 151 },
        new() { Name = "Super energy", Category = "Potion", LevelRequired = 52, Experience = 117.5, Ingredients = [new("Avantoe", 261), new("Mort myre fungus", 2970)], UnfPotionAlternative = new("Avantoe potion (unf)", 103), OutputItemId = 3018 },
        new() { Name = "Hunter potion", Category = "Potion", LevelRequired = 53, Experience = 120, Ingredients = [new("Avantoe", 261), new("Kebbit teeth dust", 10111)], UnfPotionAlternative = new("Avantoe potion (unf)", 103), OutputItemId = 10000 },
        new() { Name = "Goading potion", Category = "Potion", LevelRequired = 54, Experience = 132, Ingredients = [new("Harralander", 255), new("Aldarium", 29993)], UnfPotionAlternative = new("Harralander potion (unf)", 97), OutputItemId = 30140 },
        new() { Name = "Super strength", Category = "Potion", LevelRequired = 55, Experience = 125, Ingredients = [new("Kwuarm", 263), new("Limpwurt root", 225)], UnfPotionAlternative = new("Kwuarm potion (unf)", 105), OutputItemId = 157 },
        new() { Name = "Haemostatic poultice", Category = "Potion", LevelRequired = 56, Experience = 27, Ingredients = [new("Elkhorn coral", 31481), new("Squid paste", 31569)], OutputItemId = 31587 },
        new() { Name = "Haemostatic dressing", Category = "Potion", LevelRequired = 56, Experience = 100, Ingredients = [new("Haemostatic poultice", 31587), new("Cotton yarn", 31469)], OutputItemId = 31593 },
        new() { Name = "Prayer regeneration potion", Category = "Potion", LevelRequired = 58, Experience = 132, Ingredients = [new("Huasca", 30097), new("Aldarium", 29993)], UnfPotionAlternative = new("Huasca potion (unf)", 30100), OutputItemId = 30128 },
        new() { Name = "Weapon poison", Category = "Potion", LevelRequired = 60, Experience = 137.5, Ingredients = [new("Kwuarm", 263), new("Dragon scale dust", 241)], UnfPotionAlternative = new("Kwuarm potion (unf)", 105), OutputItemId = 187 },
        new() { Name = "Super fishing potion", Category = "Potion", LevelRequired = 62, Experience = 140.5, Ingredients = [new("Pillar coral", 31484), new("Haddock eye", 32357)], OutputItemId = 31605 },
        new() { Name = "Super restore", Category = "Potion", LevelRequired = 63, Experience = 142.5, Ingredients = [new("Snapdragon", 3000), new("Red spiders' eggs", 223)], UnfPotionAlternative = new("Snapdragon potion (unf)", 3004), OutputItemId = 3026 },
        new() { Name = "Sanfew serum", Category = "Potion", LevelRequired = 65, Experience = 160, Ingredients = [new("Super restore(4)", 3024), new("Unicorn horn dust", 235), new("Snake weed"), new("Nail beast nails", 10937)], OutputItemId = 10925 },
        new() { Name = "Super defence", Category = "Potion", LevelRequired = 66, Experience = 150, Ingredients = [new("Cadantine", 265), new("White berries", 239)], UnfPotionAlternative = new("Cadantine potion (unf)", 107), OutputItemId = 163 },
        new() { Name = "Extreme energy potion", Category = "Potion", LevelRequired = 66, Experience = 84, Ingredients = [new("Super energy(4)", 3016), new("Yellow fin", 32360)], OutputItemId = 31614 },
        new() { Name = "Super hunter potion", Category = "Potion", LevelRequired = 67, Experience = 154, Ingredients = [new("Pillar coral", 31484), new("Crab paste", 31708)], OutputItemId = 31629 },
        new() { Name = "Antidote+", Category = "Potion", LevelRequired = 68, Experience = 155, Ingredients = [new("Toadflax", 2998), new("Yew roots", 6049)], UnfPotionAlternative = new("Toadflax potion (unf)", 3002), OutputItemId = 5945 },
        new() { Name = "Antifire potion", Category = "Potion", LevelRequired = 69, Experience = 157.5, Ingredients = [new("Lantadyme", 2481), new("Dragon scale dust", 241)], UnfPotionAlternative = new("Lantadyme potion (unf)", 2483), OutputItemId = 2454 },
        new() { Name = "Divine super attack potion", Category = "Potion", LevelRequired = 70, Experience = 2, Ingredients = [new("Super attack(4)", 2436), new("Crystal dust", 23964)], OutputItemId = 23685 },
        new() { Name = "Divine super defence potion", Category = "Potion", LevelRequired = 70, Experience = 2, Ingredients = [new("Super defence(4)", 2442), new("Crystal dust", 23964)], OutputItemId = 23691 },
        new() { Name = "Divine super strength potion", Category = "Potion", LevelRequired = 70, Experience = 2, Ingredients = [new("Super strength(4)", 2440), new("Crystal dust", 23964)], OutputItemId = 23697 },
        new() { Name = "Ranging potion", Category = "Potion", LevelRequired = 72, Experience = 162.5, Ingredients = [new("Dwarf weed", 267), new("Wine of zamorak", 245)], UnfPotionAlternative = new("Dwarf weed potion (unf)", 109), OutputItemId = 169 },
        new() { Name = "Weapon poison+", Category = "Potion", LevelRequired = 73, Experience = 190, Ingredients = [new("Cactus spine", 6016), new("Red spiders' eggs", 223)], OutputItemId = 5937 },
        new() { Name = "Divine ranging potion", Category = "Potion", LevelRequired = 74, Experience = 2, Ingredients = [new("Ranging potion(4)", 2444), new("Crystal dust", 23964)], OutputItemId = 23733 },
        new() { Name = "Magic potion", Category = "Potion", LevelRequired = 76, Experience = 172.5, Ingredients = [new("Lantadyme", 2481), new("Potato cactus", 3138)], UnfPotionAlternative = new("Lantadyme potion (unf)", 2483), OutputItemId = 3042 },
        new() { Name = "Stamina potion", Category = "Potion", LevelRequired = 77, Experience = 102, Ingredients = [new("Super energy(4)", 3016), new("Amylase crystal", 12640, 4)], OutputItemId = 12625 },
        new() { Name = "Zamorak brew", Category = "Potion", LevelRequired = 78, Experience = 175, Ingredients = [new("Torstol", 269), new("Jangerberries", 247)], UnfPotionAlternative = new("Torstol potion (unf)", 111), OutputItemId = 189 },
        new() { Name = "Divine magic potion", Category = "Potion", LevelRequired = 78, Experience = 2, Ingredients = [new("Magic potion(4)", 3040), new("Crystal dust", 23964)], OutputItemId = 23745 },
        new() { Name = "Antidote++", Category = "Potion", LevelRequired = 79, Experience = 177.5, Ingredients = [new("Irit leaf", 259), new("Magic roots", 6051)], UnfPotionAlternative = new("Irit potion (unf)", 101), OutputItemId = 5954 },
        new() { Name = "Bastion potion", Category = "Potion", LevelRequired = 80, Experience = 155, Ingredients = [new("Cadantine", 265), new("Wine of zamorak", 245)], UnfPotionAlternative = new("Cadantine blood potion (unf)", 22443), OutputItemId = 22461 },
        new() { Name = "Battlemage potion", Category = "Potion", LevelRequired = 80, Experience = 155, Ingredients = [new("Cadantine", 265), new("Potato cactus", 3138)], UnfPotionAlternative = new("Cadantine blood potion (unf)", 22443), OutputItemId = 22449 },
        new() { Name = "Saradomin brew", Category = "Potion", LevelRequired = 81, Experience = 180, Ingredients = [new("Toadflax", 2998), new("Crushed nest", 6693)], UnfPotionAlternative = new("Toadflax potion (unf)", 3002), OutputItemId = 6687 },
        new() { Name = "Surge potion", Category = "Potion", LevelRequired = 81, Experience = 185, Ingredients = [new("Torstol", 269), new("Demonic tallow", 30800)], UnfPotionAlternative = new("Torstol potion (unf)", 111) },
        new() { Name = "Weapon poison++", Category = "Potion", LevelRequired = 82, Experience = 190, Ingredients = [new("Cave nightshade", 2398), new("Poison ivy berries", 6018)], OutputItemId = 5940 },
        new() { Name = "Extended antifire", Category = "Potion", LevelRequired = 84, Experience = 110, Ingredients = [new("Antifire potion(4)", 2452), new("Lava scale shard", 11994, 4)], OutputItemId = 11951 },
        new() { Name = "Ancient brew", Category = "Potion", LevelRequired = 85, Experience = 190, Ingredients = [new("Dwarf weed", 267), new("Nihil dust", 26368)], UnfPotionAlternative = new("Dwarf weed potion (unf)", 109), OutputItemId = 26342 },
        new() { Name = "Extended stamina potion", Category = "Potion", LevelRequired = 85, Experience = 110, Ingredients = [new("Stamina potion(4)", 12625), new("Marlin scales", 32362, 4)], OutputItemId = 31638 },
        new() { Name = "Divine bastion potion", Category = "Potion", LevelRequired = 86, Experience = 2, Ingredients = [new("Bastion potion(4)", 22461), new("Crystal dust", 23964)], OutputItemId = 24635 },
        new() { Name = "Divine battlemage potion", Category = "Potion", LevelRequired = 86, Experience = 2, Ingredients = [new("Battlemage potion(4)", 22449), new("Crystal dust", 23964)], OutputItemId = 24641 },
        new() { Name = "Anti-venom", Category = "Potion", LevelRequired = 87, Experience = 120, Ingredients = [new("Antidote++(4)", 5952), new("Zulrah's scales", 12934, 20)], OutputItemId = 12905 },
        new() { Name = "Menaphite remedy", Category = "Potion", LevelRequired = 88, Experience = 200, Ingredients = [new("Dwarf weed", 267), new("Lily of the sands", 27272)], UnfPotionAlternative = new("Dwarf weed potion (unf)", 109), OutputItemId = 27205 },
        new() { Name = "Armadyl brew", Category = "Potion", LevelRequired = 89, Experience = 205, Ingredients = [new("Umbral coral", 31487), new("Rainbow crab paste", 31710)], OutputItemId = 31653 },
        new() { Name = "Super combat potion", Category = "Potion", LevelRequired = 90, Experience = 150, Ingredients = [new("Torstol", 269), new("Super attack(4)", 2436), new("Super strength(4)", 2440), new("Super defence(4)", 2442)], OutputItemId = 12695 },
        new() { Name = "Forgotten brew", Category = "Potion", LevelRequired = 91, Experience = 145, Ingredients = [new("Ancient brew(4)", 26340), new("Ancient essence", 27616, 80)], OutputItemId = 27629 },
        new() { Name = "Super antifire potion", Category = "Potion", LevelRequired = 92, Experience = 130, Ingredients = [new("Antifire potion(4)", 2452), new("Crushed superior dragon bones", 21975)], OutputItemId = 21978 },
        new() { Name = "Anti-venom+", Category = "Potion", LevelRequired = 94, Experience = 125, Ingredients = [new("Anti-venom(4)", 12905), new("Torstol", 269)], OutputItemId = 12913 },
        new() { Name = "Extended anti-venom+", Category = "Potion", LevelRequired = 94, Experience = 20, Ingredients = [new("Anti-venom+(4)", 12913), new("Araxyte venom sack", 29784)], OutputItemId = 29824 },
        new() { Name = "Divine super combat potion", Category = "Potion", LevelRequired = 97, Experience = 2, Ingredients = [new("Super combat potion(4)", 12695), new("Crystal dust", 23964)], OutputItemId = 23757 },
        new() { Name = "Extended super antifire", Category = "Potion", LevelRequired = 98, Experience = 160, Ingredients = [new("Super antifire potion(4)", 21978), new("Lava scale shard", 11994, 4)], OutputItemId = 22209 },

        // Herbed tar
        new() { Name = "Guam tar", Category = "Tar", LevelRequired = 19, Experience = 30, Ingredients = [new("Guam leaf", 249), new("Swamp tar", 1939, 15)] },
        new() { Name = "Marrentill tar", Category = "Tar", LevelRequired = 31, Experience = 42.5, Ingredients = [new("Marrentill", 251), new("Swamp tar", 1939, 15)] },
        new() { Name = "Tarromin tar", Category = "Tar", LevelRequired = 39, Experience = 55, Ingredients = [new("Tarromin", 253), new("Swamp tar", 1939, 15)] },
        new() { Name = "Harralander tar", Category = "Tar", LevelRequired = 44, Experience = 72.5, Ingredients = [new("Harralander", 255), new("Swamp tar", 1939, 15)] },
        new() { Name = "Irit tar", Category = "Tar", LevelRequired = 55, Experience = 85, Ingredients = [new("Irit leaf", 259), new("Swamp tar", 1939, 15)] },
    ];

    public static IEnumerable<string> Categories =>
        Actions.Select(a => a.Category).Distinct().Order();
}
