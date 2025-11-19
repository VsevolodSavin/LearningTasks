namespace _251119.GetElementTest;

using System.Collections.Generic;
using Xunit;

public class ElementGetterTests
{
    private readonly ElementGetter _elementGetter;

    public ElementGetterTests()
    {
        _elementGetter = new ElementGetter();
    }

    [Fact]
    public void GetElementAtOrDefault_ValidIndex_ReturnsElement()
    {
        // Arrange
        var collection = new List<int> { 10, 20, 30, 40, 50 };
        int index = 2;

        // Act
        var result = _elementGetter.GetElementAtOrDefault(collection, index);

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void GetElementAtOrDefault_IndexZero_ReturnsFirstElement()
    {
        // Arrange
        var collection = new List<int> { 10, 20, 30 };
        int index = 0;

        // Act
        var result = _elementGetter.GetElementAtOrDefault(collection, index);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void GetElementAtOrDefault_LastIndex_ReturnsLastElement()
    {
        // Arrange
        var collection = new List<int> { 10, 20, 30 };
        int index = 2;

        // Act
        var result = _elementGetter.GetElementAtOrDefault(collection, index);

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void GetElementAtOrDefault_NegativeIndex_ReturnsNull()
    {
        // Arrange
        var collection = new List<int> { 10, 20, 30 };
        int index = -1;

        // Act
        var result = _elementGetter.GetElementAtOrDefault(collection, index);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetElementAtOrDefault_IndexOutOfRange_ReturnsNull()
    {
        // Arrange
        var collection = new List<int> { 10, 20, 30 };
        int index = 5;

        // Act
        var result = _elementGetter.GetElementAtOrDefault(collection, index);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetElementAtOrDefault_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var collection = new List<int>();
        int index = 0;

        // Act
        var result = _elementGetter.GetElementAtOrDefault(collection, index);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetElementAtOrDefault_NullCollection_ReturnsNull()
    {
        // Arrange
        ICollection<int>? collection = null;
        int index = 0;

        // Act
        var result = _elementGetter.GetElementAtOrDefault(collection, index);

        // Assert
        Assert.Null(result);
    }
}