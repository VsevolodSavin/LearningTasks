
using _251222AreSequencesEqualApp;

namespace _251222AreSequencesEqualTest;

public class UnitTest1
{
    [Fact]
    public void GetEqualLists_ReturnTrue()
    {
        //Arrange
        var compare = new Comparator();
        var list = Enumerable.Range(0, 100).ToList();
        var list1 = Enumerable.Range(0, 100).ToList();
        
        //Act
        bool result = compare.AreSequencesEqual(list, list1);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void GetDifferentLists_ReturnFalse()
    {
        //Arrange
        var compare = new Comparator();
        var list = Enumerable.Range(0, 100).ToList();
        var list1 = Enumerable.Range(0, 90).ToList();
        
        //Act
        bool result = compare.AreSequencesEqual(list, list1);
        
        //Assert
        Assert.False(result);
    }
}