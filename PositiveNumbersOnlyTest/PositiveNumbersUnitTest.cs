
using PositiveNumbersOnlyApp;
using Xunit;
using Assert = Xunit.Assert;

namespace PositiveNumbersOnlyTest;

public class Tests
{
    //Возврат только положительных чисел
    [Fact]
    public void GetPositiveNumbers_StandardCase_ReturnsOnlyPositive()
    {
        // Arrange
        var checker = new CheckForPositive();
        var input = new List<int> { -2, -1, 0, 1, 2, 3 };

        // Act
        var result = checker.GetPositiveNumbers(input);

        // Assert
        Assert.Equal(new List<int> { 1, 2, 3 }, result);
    }
    //Только отрицательные значения
    [Fact]
    public void GetPositiveNumbers_AllNegative_ReturnsEmptyList()
    {
        // Arrange
        var checker = new CheckForPositive();
        var input = new List<int> { -5, -10, -1 };

        // Act
        var result = checker.GetPositiveNumbers(input);

        // Assert
        Assert.Empty(result);
    }
    //Пустой массив
    [Fact]
    public void GetPositiveNumbers_EmptyArray_ReturnsEmptyList()
    {
        // Arrange
        var checker = new CheckForPositive();
        var input = new List<int>();

        // Act
        var result = checker.GetPositiveNumbers(input);

        // Assert
        Assert.Empty(result);
    }
    //Граничные значения
    [Fact]
    public void GetPositiveNumbers_BoundaryValues_HandlesCorrectly()
    {
        // Arrange
        var checker = new CheckForPositive();
        var input = new List<int> { int.MinValue, -1, 0, 1, int.MaxValue };

        // Act
        var result = checker.GetPositiveNumbers(input);

        // Assert
        Assert.Equal(new List<int> { 1, int.MaxValue }, result);
    }
}