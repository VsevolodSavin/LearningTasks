
using _251223AreRefSequencesEqualApp;

namespace _251223AreRefSequencesEqualTest;

public class UnitTest1
{
    [Fact]
    public void GetEqualLists_ReturnTrue()
    {
        //Arrange
        var compare = new Comparator();
        
        IList<User> firstList = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25},
            new User { Id = Guid.NewGuid(), Age = 17},
            new User { Id = Guid.NewGuid(), Age = 18},
            new User { Id = Guid.NewGuid(), Age = 20},
            new User { Id = Guid.NewGuid(), Age = 95},
            new User { Id = Guid.NewGuid(), Age = 25}
        }; 
        
        IList<User> secondList = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25},
            new User { Id = Guid.NewGuid(), Age = 17},
            new User { Id = Guid.NewGuid(), Age = 18},
            new User { Id = Guid.NewGuid(), Age = 20},
            new User { Id = Guid.NewGuid(), Age = 95},
            new User { Id = Guid.NewGuid(), Age = 25}
        };
        
        //Act
        var result = compare.AreSequencesEqual(firstList, secondList);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void GetDifferentLists_ReturnFalse()
    {
        //Arrange
        var compare = new Comparator();
        
        IList<User> firstList = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 0},
            new User { Id = Guid.NewGuid(), Age = 17},
            new User { Id = Guid.NewGuid(), Age = 18},
            new User { Id = Guid.NewGuid(), Age = 20},
            new User { Id = Guid.NewGuid(), Age = 95},
            new User { Id = Guid.NewGuid(), Age = 25}
        }; 
        
        IList<User> secondList = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25},
            new User { Id = Guid.NewGuid(), Age = 17},
            new User { Id = Guid.NewGuid(), Age = 18},
            new User { Id = Guid.NewGuid(), Age = 20},
            new User { Id = Guid.NewGuid(), Age = 95},
            new User { Id = Guid.NewGuid(), Age = 25}
        };
        
        //Act
        var result = compare.AreSequencesEqual(firstList, secondList);
        
        //Assert
        Assert.False(result);
    }
}