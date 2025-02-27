using FluentAssertions;

namespace DarkLink.Sorting.FavouriteSort.Tests;

[TestClass]
public class FavouriteSortComparerTest
{
    [TestMethod]
    public void EmptyCollectionIsUnaffected()
    {
        // Arrange
        var subject = CreateSubject();
        var unsorted = new string[] { }; 
        var sorted = new string[] { }; 

        // Act
        var result = unsorted.Order(subject);

        // Assert
        result.Should().BeEquivalentTo(sorted);
    }

    private FavouriteSortComparer<string> CreateSubject()
    {
        return new FavouriteSortComparer<string>();
    }
}