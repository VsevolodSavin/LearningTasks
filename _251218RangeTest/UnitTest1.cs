
using _251218RangeApp;

namespace _251218RangeTest;

public class UnitTest1
{
    [Fact]
    public void GetSkipAndTake_ReturnNeededElements()
    {
        //Arrange
        var ranger = new Method();
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };
        
        //Act
        var result = ranger.GetPage(products, skip: 1, take: 2);
        
        //Assert
        Assert.Equal("Product_2", result[0].Name);
        Assert.Equal("Product_3", result[1].Name);
    }
    
    [Fact]
    public void GetZeroedSkip_ReturnFirstElements()
    {
        // Arrange
        var ranger = new Method();
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };

        // Act
        var result = ranger.GetPage(products, skip: 0, take: 3);

        // Assert
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0].Id);
        Assert.Equal(3, result[2].Id);
    }
    
    [Fact]
    public void GetZeroedTake_ReturnEmptyValue()
    {
        // Arrange
        var ranger = new Method();
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };

        // Act
        var result = ranger.GetPage(products, skip: 1, take: 0);

        // Assert
        Assert.Empty(result);
    }
}