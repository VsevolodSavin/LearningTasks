using _251216AggregateApp;

namespace _251216AggregateTest;


public class UnitTestForAggregate
{
    [Fact]
    public void GetNumbersInArray_ReturnsSum()
    {
        //Arrange
        var aggregator = new Method();
        int[] nums = { 1, 2, 3, 4 };
        
        //Act
        var result = aggregator.AggregateNumbers(nums);
        
        //Assert
        Assert.Equal(10, result);
    }
    
    [Fact]
    public void GetNegatineNumbersInArray_ReturnsSum()
    {
        //Arrange
        var aggregator = new Method();
        int[] nums = { -1, -2, -3, -4 };
        
        //Act
        var result = aggregator.AggregateNumbers(nums);
        
        //Assert
        Assert.Equal(-10, result);
    }
    
    [Fact]
    public void GetZerosInArray_ReturnsSum()
    {
        //Arrange
        var aggregator = new Method();
        int[] nums = { 0, 0 };
        
        //Act
        var result = aggregator.AggregateNumbers(nums);
        
        //Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void GetEmptyArray_ReturnsNull()
    {
        //Arrange
        var aggregator = new Method();
        int[] nums = [];
        
        //Act
        var result = aggregator.AggregateNumbers(nums);
        
        //Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void GetNullArray_ReturnsNull()
    {
        //Arrange
        var aggregator = new Method();
        int[] nums = null;
        
        //Act
        var result = aggregator.AggregateNumbers(nums);
        
        //Assert
        Assert.Null(result);
    }
    
}