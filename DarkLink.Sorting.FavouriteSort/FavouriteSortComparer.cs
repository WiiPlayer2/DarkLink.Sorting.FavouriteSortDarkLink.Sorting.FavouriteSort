namespace DarkLink.Sorting.FavouriteSort;

public class FavouriteSortComparer<T>(Relations<T> relations, IEqualityComparer<T> equalityComparer) : IComparer<T>
{
    public int Compare(T? x, T? y)
    {
        var relation = relations.Items.FirstOrDefault(relation =>
            equalityComparer.Equals(x, relation.Lower) && equalityComparer.Equals(y, relation.Higher) ||
            equalityComparer.Equals(x, relation.Higher) && equalityComparer.Equals(y, relation.Lower));
        if(relation is not null)
            return equalityComparer.Equals(relation.Lower, x) ? -1 : 1;

        throw new InvalidOperationException();
    }
}