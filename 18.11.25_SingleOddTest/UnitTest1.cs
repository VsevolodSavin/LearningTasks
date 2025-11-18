

using System;
using System.Collections.Generic;
using Xunit;
using Assert = Xunit.Assert;

namespace SingleOddApp.Tests
{
    public class OddNumberFinderTests
    {
        private readonly OddNumberFinder _finder;

        public OddNumberFinderTests()
        {
            _finder = new OddNumberFinder();
        }

        [Fact]
        public void GetSingleOddNumber_WhenNullCollection_ReturnsNull()
        {
            // Arrange
            ICollection<int>? numbers = null;

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetSingleOddNumber_WhenEmptyCollection_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int>();

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetSingleOddNumber_WhenOnlyEvenNumbers_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int> { 2, 4, 6, 8, 10 };

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetSingleOddNumber_WhenSingleOddNumber_ReturnsThatNumber()
        {
            // Arrange
            var numbers = new List<int> { 2, 4, 7, 8, 10 };
            var expected = 7;

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetSingleOddNumber_WhenSingleOddNumberAtBeginning_ReturnsThatNumber()
        {
            // Arrange
            var numbers = new List<int> { 3, 2, 4, 6 };
            var expected = 3;

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetSingleOddNumber_WhenSingleOddNumberAtEnd_ReturnsThatNumber()
        {
            // Arrange
            var numbers = new List<int> { 2, 4, 6, 5 };
            var expected = 5;

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetSingleOddNumber_WhenSingleNegativeOddNumber_ReturnsThatNumber()
        {
            // Arrange
            var numbers = new List<int> { -3, 2, 4, 6 };
            var expected = -3;

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetSingleOddNumber_WhenSingleZero_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int> { 0 };

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetSingleOddNumber_WhenMultipleOddNumbers_ThrowsInvalidOperationException()
        {
            // Arrange
            var numbers = new List<int> { 1, 2, 3, 5 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _finder.GetSingleOddNumber(numbers));
        }

        [Fact]
        public void GetSingleOddNumber_WhenAllOddNumbers_ThrowsInvalidOperationException()
        {
            // Arrange
            var numbers = new List<int> { 1, 3, 5, 7 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _finder.GetSingleOddNumber(numbers));
        }

        [Fact]
        public void GetSingleOddNumber_WhenTwoOddNumbers_ThrowsInvalidOperationException()
        {
            // Arrange
            var numbers = new List<int> { 1, 3, 4, 6 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _finder.GetSingleOddNumber(numbers));
        }

        [Fact]
        public void GetSingleOddNumber_WhenLargeNumbers_ReturnsCorrectResult()
        {
            // Arrange
            var numbers = new List<int> { 1000000, 1000001, 1000002 };
            var expected = 1000001;

            // Act
            var result = _finder.GetSingleOddNumber(numbers);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}