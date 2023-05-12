namespace GildedRoseRefactoringKata;

public static class Updating
{
    public static GildedRose Update(this GildedRose gildedRose) => new(gildedRose.Items.ConvertAll(Update));

    public static Item Update(this Item item) => item
        .UpdateSellIn()
        .UpdateQuality();

    static Item UpdateQuality(this Item item)
    {
        var change = item.Name switch
        {
            "Aged Brie" => item.SellIn < 0 ? 2 : 1,
            "Backstage passes to a TAFKAL80ETC concert" => item.SellIn switch
            {
                < 0 => -item.Quality,
                < 5 => 3,
                < 10 => 2,
                _ => 1
            },
            "Sulfuras, Hand of Ragnaros" => 0,
            _ => item.SellIn < 0 ? -2 : -1
        };

        return change == 0 ? item : item with { Quality = int.Clamp(item.Quality + change, 0, 50) };
    }

    static Item UpdateSellIn(this Item item) =>
        item.Name == "Sulfuras, Hand of Ragnaros" ? item :
        item with { SellIn = item.SellIn - 1 };
}