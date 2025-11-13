
using Xunit;
using Assert = Xunit.Assert;

namespace OddNumbersOnlyTest
{
    public class OddNumbersUnitTest
    {
        //Смешанные числа
        [Fact]
        public void GetOdd_WithMixedNumbers_ReturnsOnlyOdd()
        {
            // Arrange
            var filter = new OddNumbersOnlyApp.CheckForOdd();
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var result = filter.GetOdd(numbers).ToList();

            // Assert
            Assert.Equal(new List<int> { 1, 3, 5 }, result);
        }
        //Отрицательные числа
        [Fact]
        public void GetOdd_NegativeNumbers_ReturnsOddNegativeNumbers()
        {
            // Arrange
            var filter = new OddNumbersOnlyApp.CheckForOdd();
            var input = new List<int> { -3, -2, -1, 0, 1, 2, 3 };
            var expected = new List<int> { -3, -1, 1, 3 };

            // Act
            var result = filter.GetOdd(input).ToList();

            // Assert
            Assert.Equal(expected, result);
        }

        //Ноль
        [Fact]
        public void GetOdd_WithZero_ZeroNotIncluded()
        {
            // Arrange
            var filter = new OddNumbersOnlyApp.CheckForOdd();
            var input = new List<int> { -2, -1, 0, 1, 2 };
            var expected = new List<int> { -1, 1 };

            // Act
            var result = filter.GetOdd(input).ToList();

            // Assert
            Assert.Equal(expected, result);
        }

        //Большие числа
        [Fact]
        public void GetOdd_LargeNumbers_ReturnsOddLargeNumbers()
        {
            // Arrange
            var filter = new OddNumbersOnlyApp.CheckForOdd();
            var input = new List<int> { int.MaxValue, int.MaxValue - 1, 1000000, 1000001 };
            var expected = new List<int> { int.MaxValue, 1000001 };

            // Act
            var result = filter.GetOdd(input).ToList();

            // Assert
            Assert.Equal(expected, result);
        }

        //Дубликаты нечетных чисел
        [Fact]
        public void GetOdd_DuplicateOddNumbers_ReturnsAllDuplicates()
        {
            // Arrange
            var filter = new OddNumbersOnlyApp.CheckForOdd();
            var input = new List<int> { 1, 1, 3, 3, 5, 5, 2, 4 };
            var expected = new List<int> { 1, 1, 3, 3, 5, 5 };

            // Act
            var result = filter.GetOdd(input).ToList();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}