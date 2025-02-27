namespace DarkLink.Sorting.FavouriteSort;

public class FavouriteSortComparer<T>(Relations<T> relations, IEqualityComparer<T> equalityComparer) : IComparer<T>
{
    public int Compare(T? x, T? y)
    {
        if (relations.Items.Count != 0)
            return equalityComparer.Equals(relations.Items.First().Lower, x) ? -1 : 1;

        throw new InvalidOperationException();
    }
}