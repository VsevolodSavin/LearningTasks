
using _251224AreRefClassSequencesEqualApp;

namespace _251224AreRefClassSequencesEqualTest;

public class UnitTest1
{
    [Fact]
    public void GetEqualLists_ReturnTrue()
    {
        //Arrange
        var comparator = new Method();
        
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        
        IList<User> firstList = new List<User>
        {
            new User { Id = id1, Age = 25},
            new User { Id = id2, Age = 17}
        }; 
        
        IList<User> secondList = new List<User>
        {
            new User { Id = id1, Age = 25},
            new User { Id = id2, Age = 17}
        };
        
        //Act
        var result = comparator.AreSequencesEqual(firstList, secondList);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void GetDifferentLists_ReturnFalse()
    {
        //Arrange
        var comparator = new Method();
        
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        
        IList<User> firstList = new List<User>
        {
            new User { Id = id1, Age = 25},
            new User { Id = id1, Age = 17}
        }; 
        
        IList<User> secondList = new List<User>
        {
            new User { Id = id2, Age = 25},
            new User { Id = id2, Age = 17}
        };
        
        //Act
        var result = comparator.AreSequencesEqual(firstList, secondList);
        
        //Assert
        Assert.False(result);
    }
}