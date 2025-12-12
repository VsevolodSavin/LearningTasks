using _251212UserActionsApp;

namespace _251212UserActionsTest
{
    public class MethodsTests
    {
        private readonly Methods _methods = new Methods();

        [Fact]
        public void AddUserAtEnd_ShouldAddUserToEndOfCollection()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 25, Name = "Иван" },
                new User { Id = Guid.NewGuid(), Age = 30, Name = "Мария" }
            };
            var newUser = new User { Id = Guid.NewGuid(), Age = 35, Name = "Алексей" };

            // Act
            var result = _methods.AddUserAtEnd(users, newUser);
            var resultList = result.ToList();

            // Assert
            Assert.Equal(3, resultList.Count);
            Assert.Equal(newUser, resultList.Last());
            Assert.Equal(users[0], resultList[0]);
            Assert.Equal(users[1], resultList[1]);
        }
        
        [Fact]
        public void AddUserAtEnd_WithEmptyCollection_ShouldReturnCollectionWithSingleUser()
        {
            // Arrange
            var users = new List<User>();
            var newUser = new User { Id = Guid.NewGuid(), Age = 35, Name = "Алексей" };

            // Act
            var result = _methods.AddUserAtEnd(users, newUser);
            var resultList = result.ToList();

            // Assert
            Assert.Single(resultList);
            Assert.Equal(newUser, resultList[0]);
        }
        
        [Fact]
        public void MergeUserCollections_ShouldCombineTwoCollections()
        {
            // Arrange
            var firstGroup = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 25, Name = "Иван" },
                new User { Id = Guid.NewGuid(), Age = 30, Name = "Мария" }
            };
            var secondGroup = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 35, Name = "Алексей" }
            };

            // Act
            var result = _methods.MergeUserCollections(firstGroup, secondGroup);
            var resultList = result.ToList();

            // Assert
            Assert.Equal(3, resultList.Count);
            Assert.Equal(firstGroup[0], resultList[0]);
            Assert.Equal(firstGroup[1], resultList[1]);
            Assert.Equal(secondGroup[0], resultList[2]);
        }

        [Fact]
        public void MergeUserCollections_WithEmptySecondCollection_ShouldReturnFirstCollection()
        {
            // Arrange
            var firstGroup = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 25, Name = "Иван" },
                new User { Id = Guid.NewGuid(), Age = 30, Name = "Мария" }
            };
            var secondGroup = new List<User>();

            // Act
            var result = _methods.MergeUserCollections(firstGroup, secondGroup);
            var resultList = result.ToList();

            // Assert
            Assert.Equal(2, resultList.Count);
            Assert.Equal(firstGroup[0], resultList[0]);
            Assert.Equal(firstGroup[1], resultList[1]);
        }

        [Fact]
        public void MergeUserCollections_WithEmptyFirstCollection_ShouldReturnSecondCollection()
        {
            // Arrange
            var firstGroup = new List<User>();
            var secondGroup = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 35, Name = "Алексей" }
            };

            // Act
            var result = _methods.MergeUserCollections(firstGroup, secondGroup);
            var resultList = result.ToList();

            // Assert
            Assert.Single(resultList);
            Assert.Equal(secondGroup[0], resultList[0]);
        }

        [Fact]
        public void AddUserAtBeginning_ShouldAddUserToBeginningOfCollection()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 25, Name = "Иван" },
                new User { Id = Guid.NewGuid(), Age = 30, Name = "Мария" }
            };
            var newUser = new User { Id = Guid.NewGuid(), Age = 35, Name = "Алексей" };

            // Act
            var result = _methods.AddUserAtBeginning(users, newUser);
            var resultList = result.ToList();

            // Assert
            Assert.Equal(3, resultList.Count);
            Assert.Equal(newUser, resultList.First());
            Assert.Equal(users[0], resultList[1]);
            Assert.Equal(users[1], resultList[2]);
        }

        [Fact]
        public void AddUserAtBeginning_WithEmptyCollection_ShouldReturnCollectionWithSingleUser()
        {
            // Arrange
            var users = new List<User>();
            var newUser = new User { Id = Guid.NewGuid(), Age = 35, Name = "Алексей" };

            // Act
            var result = _methods.AddUserAtBeginning(users, newUser);
            var resultList = result.ToList();

            // Assert
            Assert.Single(resultList);
            Assert.Equal(newUser, resultList[0]);
        }
    }
}