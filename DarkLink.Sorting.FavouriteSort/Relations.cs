namespace DarkLink.Sorting.FavouriteSort;

public record Relations<T>(IReadOnlyCollection<Relation<T>> Items)
{
    public static Relations<T> Empty { get; } = new([]);
}