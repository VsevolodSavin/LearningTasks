using Xunit;
using System.Collections.Generic;
using FirstOddNumberApp;
using Assert = Xunit.Assert;

namespace FirstOddNumberTest
{
    public class UnitTest1
    {
        private readonly CheckForFirstOdd _checker;

        public UnitTest1()
        {
            _checker = new CheckForFirstOdd();
        }

        [Fact]
        public void GetFirstOddNumber_ListWithOddNumbers_ReturnsFirstOdd()
        {
            // Arrange
            var numbers = new List<int> { 2, 4, 7, 8, 10 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void GetFirstOddNumber_ListWithoutOddNumbers_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int> { 2, 4, 6, 8, 10 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetFirstOddNumber_EmptyList_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int>();

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetFirstOddNumber_NullInput_ReturnsNull()
        {
            // Arrange
            ICollection<int> numbers = null;

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetFirstOddNumber_FirstElementIsOdd_ImmediateReturn()
        {
            // Arrange
            var numbers = new List<int> { 3, 5, 7, 9 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void GetFirstOddNumber_NegativeOddNumbers_ReturnsFirstNegativeOdd()
        {
            // Arrange
            var numbers = new List<int> { -2, -3, -5, -6 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Equal(-3, result);
        }

        [Fact]
        public void GetFirstOddNumber_MixedPositiveNegative_ReturnsFirstOdd()
        {
            // Arrange
            var numbers = new List<int> { -4, 2, -3, 6, 9 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Equal(-3, result);
        }

        [Fact]
        public void GetFirstOddNumber_SingleOddNumber_ReturnsThatNumber()
        {
            // Arrange
            var numbers = new List<int> { 5 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void GetFirstOddNumber_SingleEvenNumber_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int> { 4 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetFirstOddNumber_LargeNumbers_ReturnsFirstOdd()
        {
            // Arrange
            var numbers = new List<int> { 1000000, 2000000, 3000001, 4000000 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Equal(3000001, result);
        }

        [Fact]
        public void GetFirstOddNumber_AllNegativeEven_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int> { -2, -4, -6, -8 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetFirstOddNumber_ZeroInList_ReturnsFirstOddAfterZero()
        {
            // Arrange
            var numbers = new List<int> { 0, 2, 1, 4 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetFirstOddNumber_OnlyZero_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int> { 0 };

            // Act
            var result = _checker.GetFirstOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }
    }
}