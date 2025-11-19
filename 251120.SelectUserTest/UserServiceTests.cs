// UserServiceTests.cs
namespace _251120.SelectUserTest;

using System;
using System.Collections.Generic;
using Xunit;

public class UserServiceTests
{
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userService = new UserService();
    }

    [Fact]
    public void SelectUserIds_WithValidUsers_ReturnsCorrectIds()
    {
        // Arrange
        var userId1 = Guid.NewGuid();
        var userId2 = Guid.NewGuid();
        var userId3 = Guid.NewGuid();
        
        var users = new List<User>
        {
            new User { Id = userId1, Age = 25, Name = "Alice" },
            new User { Id = userId2, Age = 17, Name = "Bob" },
            new User { Id = userId3, Age = 30, Name = "Charlie" }
        };
        
        // Act
        var result = _userService.SelectUserIds(users, 20);
        
        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(userId1, result);
        Assert.Contains(userId3, result);
        Assert.DoesNotContain(userId2, result);
    }
    
    [Fact]
    public void SelectUserIds_WithEmptyList_ReturnsEmptyCollection()
    {
        // Arrange
        var emptyUsers = new List<User>();
        
        // Act
        var result = _userService.SelectUserIds(emptyUsers, 20);
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void SelectUserIds_WithAllUsersBelowAge_ReturnsEmptyCollection()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 15, Name = "Alice" },
            new User { Id = Guid.NewGuid(), Age = 17, Name = "Bob" },
            new User { Id = Guid.NewGuid(), Age = 18, Name = "Charlie" }
        };
        
        // Act
        var result = _userService.SelectUserIds(users, 20);
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void SelectUserIds_WithBoundaryAge_ReturnsCorrectUsers()
    {
        // Arrange
        var userId1 = Guid.NewGuid();
        var userId2 = Guid.NewGuid();
        
        var users = new List<User>
        {
            new User { Id = userId1, Age = 20, Name = "Alice" },
            new User { Id = userId2, Age = 21, Name = "Bob" }
        };
        
        // Act
        var result = _userService.SelectUserIds(users, 20);
        
        // Assert
        Assert.Single(result);
        Assert.Contains(userId2, result);
        Assert.DoesNotContain(userId1, result);
    }
    
    [Fact]
    public void SelectUserIds_WithNullUsers_ThrowsArgumentNullException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => _userService.SelectUserIds(null, 20));
    }
    
    [Theory]
    [InlineData(18, 2)]
    [InlineData(25, 1)]
    [InlineData(30, 0)]
    [InlineData(15, 3)]
    public void SelectUserIds_WithDifferentAges_ReturnsCorrectCount(int age, int expectedCount)
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 20, Name = "Alice" },
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Bob" },
            new User { Id = Guid.NewGuid(), Age = 30, Name = "Charlie" }
        };
        
        // Act
        var result = _userService.SelectUserIds(users, age);
        
        // Assert
        Assert.Equal(expectedCount, result.Count);
    }
}