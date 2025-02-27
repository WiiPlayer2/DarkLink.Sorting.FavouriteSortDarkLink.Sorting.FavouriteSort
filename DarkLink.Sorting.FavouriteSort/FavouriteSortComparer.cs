namespace DarkLink.Sorting.FavouriteSort;

public class FavouriteSortComparer<T>(Relations<T> relations) : IComparer<T>
{
    public int Compare(T? x, T? y)
    {
        if (relations.Items.Count != 0)
            return -1;
        
        throw new InvalidOperationException();
    }
}