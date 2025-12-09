
using _251209CompareGroupingApp;

namespace _251209CompareGroupingTest;

public class UnitTest1
{
    private readonly Methods _methods = new();
    
    private readonly List<User> _testUsers = new()
    {
        new User { Id = Guid.NewGuid(), Age = 25, Name = "Анна" },
        new User { Id = Guid.NewGuid(), Age = 30, Name = "Иван" },
        new User { Id = Guid.NewGuid(), Age = 25, Name = "Мария" },
        new User { Id = Guid.NewGuid(), Age = 30, Name = "Петр" },
        new User { Id = Guid.NewGuid(), Age = 30, Name = "Ольга" }
    };
    
    [Fact]
    public void GroupByAgeUsingDictionary_WithDuplicateAges_ReturnsFirstUserOnly()
    {
        // Arrange
        var expectedCount = 2;
            
        // Act
        var result = _methods.GroupByAgeUsingDictionary(_testUsers);
            
        // Assert
        Assert.Equal(expectedCount, result.Count);
        Assert.Equal("Анна", result[25].Name); 
        Assert.Equal("Иван", result[30].Name); 
    }
    
    [Fact]
    public void GroupByAgeUsingLookup_WithDuplicateAges_ReturnsAllUsers()
    {
        // Arrange
        var age30ExpectedCount = 3;
            
        // Act
        var result = _methods.GroupByAgeUsingLookup(_testUsers);
            
        // Assert
        var age30Group = result[30].ToList();
        Assert.Equal(age30ExpectedCount, age30Group.Count);
        Assert.Contains(age30Group, u => u.Name == "Иван");
        Assert.Contains(age30Group, u => u.Name == "Петр");
        Assert.Contains(age30Group, u => u.Name == "Ольга");
    }
    
    [Fact]
    public void GroupByAgeUsingDictionary_WithMissingKey_ThrowsKeyNotFoundException()
    {
        // Arrange
        var result = _methods.GroupByAgeUsingDictionary(_testUsers);
            
        // Act/Assert
        Assert.Throws<KeyNotFoundException>(() => result[99]);
    }
    
    [Fact]
    public void GroupByAgeUsingLookup_WithMissingKey_ReturnsEmptyCollection()
    {
        // Arrange
        var result = _methods.GroupByAgeUsingLookup(_testUsers);
            
        // Act
        var missingKeyResult = result[99];
            
        // Assert
        Assert.Empty(missingKeyResult);
        Assert.NotNull(missingKeyResult);
    }
    
}