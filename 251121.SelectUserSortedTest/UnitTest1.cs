

//using _251121.SelectUserSortedApp;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;

namespace _251121.SelectUserSortedTest
{
    public class UserServiceTests
    {
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService();
        }

        [Fact]
        public void SelectUsers_WithValidUsersAndAge_ReturnsFilteredAndSortedUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 25, Name = "Иван" },
                new User { Id = Guid.NewGuid(), Age = 17, Name = "Андрей" },
                new User { Id = Guid.NewGuid(), Age = 30, Name = "Анна" },
                new User { Id = Guid.NewGuid(), Age = 20, Name = "Ирина" },
                new User { Id = Guid.NewGuid(), Age = 25, Name = "Петр" }
            };

            // Act
            var result = _userService.SelectUsers(users, 20);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.All(result, user => Assert.True(user.Age >= 20));
            
            // Проверяем сортировку по возрастанию возраста
            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.True(result.ElementAt(i).Age <= result.ElementAt(i + 1).Age);
            }
        }

        [Fact]
        public void SelectUsers_WithEmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var emptyUsers = new List<User>();

            // Act
            var result = _userService.SelectUsers(emptyUsers, 20);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SelectUsers_WithAllUsersBelowAge_ReturnsEmptyCollection()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 15, Name = "Андрей" },
                new User { Id = Guid.NewGuid(), Age = 17, Name = "Иван" },
                new User { Id = Guid.NewGuid(), Age = 18, Name = "Петр" }
            };

            // Act
            var result = _userService.SelectUsers(users, 20);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SelectUsers_WithAllUsersAboveAge_ReturnsAllUsersSorted()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 25, Name = "Иван" },
                new User { Id = Guid.NewGuid(), Age = 30, Name = "Анна" },
                new User { Id = Guid.NewGuid(), Age = 22, Name = "Петр" }
            };

            // Act
            var result = _userService.SelectUsers(users, 20);

            // Assert
            Assert.Equal(3, result.Count);
            
            // Проверяем сортировку
            Assert.Equal(22, result.ElementAt(0).Age);
            Assert.Equal(25, result.ElementAt(1).Age);
            Assert.Equal(30, result.ElementAt(2).Age);
        }

        [Fact]
        public void SelectUsers_WithBoundaryAge_IncludesUsersWithExactAge()
        {
            // Arrange
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            
            var users = new List<User>
            {
                new User { Id = userId1, Age = 20, Name = "Ирина" },
                new User { Id = userId2, Age = 21, Name = "Петр" }
            };

            // Act
            var result = _userService.SelectUsers(users, 20);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, user => user.Id == userId1);
            Assert.Contains(result, user => user.Id == userId2);
        }

        [Fact]
        public void SelectUsers_WithUsersHavingSameAge_PreservesAllAndMaintainsStableOrder()
        {
            // Arrange
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var userId3 = Guid.NewGuid();
            
            var users = new List<User>
            {
                new User { Id = userId1, Age = 25, Name = "Иван" },
                new User { Id = userId2, Age = 25, Name = "Петр" },
                new User { Id = userId3, Age = 25, Name = "Анна" },
                new User { Id = Guid.NewGuid(), Age = 30, Name = "Андрей" }
            };

            // Act
            var result = _userService.SelectUsers(users, 25);

            // Assert
            Assert.Equal(4, result.Count);
            
            // Все пользователи с возрастом 25 должны быть в начале в том же порядке
            Assert.Equal(userId1, result.ElementAt(0).Id);
            Assert.Equal(userId2, result.ElementAt(1).Id);
            Assert.Equal(userId3, result.ElementAt(2).Id);
        }

        [Fact]
        public void SelectUsers_WithNullUsers_ThrowsArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => _userService.SelectUsers(null, 20));
        }
        [Fact]
        public void SelectUsers_ResultIsSortedByAgeAscending()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 35, Name = "А" },
                new User { Id = Guid.NewGuid(), Age = 20, Name = "Б" },
                new User { Id = Guid.NewGuid(), Age = 30, Name = "В" },
                new User { Id = Guid.NewGuid(), Age = 25, Name = "Г" }
            };

            // Act
            var result = _userService.SelectUsers(users, 20);

            // Assert
            var expectedAges = new[] { 20, 25, 30, 35 };
            var actualAges = result.Select(u => u.Age).ToArray();
            
            Assert.Equal(expectedAges, actualAges);
        }
    }
}