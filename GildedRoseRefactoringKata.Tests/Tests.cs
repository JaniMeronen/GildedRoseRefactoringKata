namespace GildedRoseRefactoringKata.Tests;

using System.Collections.Immutable;
using System.Text;

[UsesVerify]
public static class Tests
{
    [Fact]
    public static Task TestAsync()
    {
        // Assign
        GildedRose sut = new(ImmutableList.Create<Item>
        (
            new("+5 Dexterity Vest", 20, 10),
            new("Aged Brie", 0, 2),
            new("Elixir of the Mongoose", 7, 5),
            new("Sulfuras, Hand of Ragnaros", 80, 0),
            new("Sulfuras, Hand of Ragnaros", 80, -1),
            new("Backstage passes to a TAFKAL80ETC concert", 20, 15),
            new("Backstage passes to a TAFKAL80ETC concert", 49, 10),
            new("Backstage passes to a TAFKAL80ETC concert", 49, 5),
            new("Conjured Mana Cake", 6, 3)
        ));

        var sb = new StringBuilder().AppendLine("OMGHAI!");

        // Act
        var target = Enumerable.Range(0, 31).Aggregate((sut, sb), (tuple, day) =>
        {
            var sb = tuple.Item2
                .AppendJoin(' ', new string[] { new string('-', 8), nameof(day), day.ToString(), new string('-', 8) })
                .AppendLine()
                .AppendJoin(", ", new string[] { nameof(Item.Name), nameof(Item.SellIn), nameof(Item.Quality) })
                .AppendLine()
                .AppendJoin(Environment.NewLine, tuple.Item1.Items.Select(item => $"{item.Name}, {item.SellIn}, {item.Quality}"))
                .AppendLine();

            var sut = tuple.Item1.Update();

            return (sut, sb);
        }).Item2.ToString();

        // Assert
        return Verify(target);
    }
}