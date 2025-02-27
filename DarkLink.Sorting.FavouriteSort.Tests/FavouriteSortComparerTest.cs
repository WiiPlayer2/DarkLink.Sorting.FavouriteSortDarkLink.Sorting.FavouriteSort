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
    
    [TestMethod]
    public void WithoutRelationsThrowsException()
    {
        // Arrange
        var subject = CreateSubject();
        var unsorted = new[] { "henlo", "dere" }; 

        // Act
        var act = () => unsorted.Order(subject).ToList();

        // Assert
        act.Should().ThrowExactly<InvalidOperationException>()
            .Which.InnerException.Should().BeOfType<InvalidOperationException>();
    }

    [TestMethod]
    public void WithDirectRelationReturnsComparison()
    {
        // Arrange
        var item1 = "henlo";
        var item2 = "dere";
        var relations = new Relations<string>([
            new("item1", "item2"),
        ]);
        var subject = CreateSubject(relations: relations);

        // Act
        var result = subject.Compare(item1, item2);

        // Assert
        result.Should().BeNegative();
    }

    private FavouriteSortComparer<string> CreateSubject(Relations<string>? relations = default)
    {
        relations ??= Relations<string>.Empty;
        return new FavouriteSortComparer<string>(relations);
    }
}