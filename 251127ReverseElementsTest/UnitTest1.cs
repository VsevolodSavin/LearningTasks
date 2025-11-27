

using Xunit;

namespace _251127ReverseElementsTest
{
    public class ElementReverseTests
    {
        [Fact]
        public void ReverseUserIds_WhenNullCollection_ReturnsEmptyList()
        {
            // Arrange
            var reverser = new ElementReverse();
            ICollection<int>? input = null;

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ReverseUserIds_WhenEmptyCollection_ReturnsEmptyList()
        {
            // Arrange
            var reverser = new ElementReverse();
            var input = new List<int>();

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ReverseUserIds_WhenSingleElement_ReturnsSameElement()
        {
            // Arrange
            var reverser = new ElementReverse();
            var input = new List<int> { 42 };

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.Single(result);
            Assert.Equal(42, result.First());
        }

        [Fact]
        public void ReverseUserIds_WhenMultipleElements_ReturnsReversedOrder()
        {
            // Arrange
            var reverser = new ElementReverse();
            var input = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.Equal(new[] { 5, 4, 3, 2, 1 }, result);
        }

        [Fact]
        public void ReverseUserIds_WhenOriginalExample_ReturnsCorrectReversal()
        {
            // Arrange
            var reverser = new ElementReverse();
            var input = new List<int> { 2, 4, 7, 8, 10 };

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.Equal(new[] { 10, 8, 7, 4, 2 }, result);
        }

        [Fact]
        public void ReverseUserIds_WhenCollectionWithDuplicates_ReturnsReversedOrderWithDuplicates()
        {
            // Arrange
            var reverser = new ElementReverse();
            var input = new List<int> { 1, 2, 2, 3, 3, 3 };

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.Equal(new[] { 3, 3, 3, 2, 2, 1 }, result);
        }

        [Fact]
        public void ReverseUserIds_WhenCollectionWithNegativeNumbers_ReturnsReversedOrder()
        {
            // Arrange
            var reverser = new ElementReverse();
            var input = new List<int> { -1, -2, -3, -4 };

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.Equal(new[] { -4, -3, -2, -1 }, result);
        }

        [Fact]
        public void ReverseUserIds_WhenCollectionWithZero_ReturnsReversedOrder()
        {
            // Arrange
            var reverser = new ElementReverse();
            var input = new List<int> { 0, 1, -1 };

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.Equal(new[] { -1, 1, 0 }, result);
        }

        [Fact]
        public void ReverseUserIds_ResultIsNewCollection_OriginalCollectionNotModified()
        {
            // Arrange
            var reverser = new ElementReverse();
            var original = new List<int> { 1, 2, 3, 4, 5 };
            var input = new List<int>(original); 

            // Act
            var result = reverser.ReverseUserIds(input);

            // Assert
            Assert.Equal(new[] { 5, 4, 3, 2, 1 }, result);
            Assert.Equal(original, input); 
        }
    }
}