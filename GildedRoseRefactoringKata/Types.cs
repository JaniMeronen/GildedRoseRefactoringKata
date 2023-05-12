namespace GildedRoseRefactoringKata;

using System.Collections.Immutable;

public sealed record Item(string Name, int Quality, int SellIn);

public sealed record GildedRose(ImmutableList<Item> Items);