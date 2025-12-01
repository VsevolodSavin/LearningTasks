using _251201CastToIntApp;

namespace _251201CastToIntTest;

public class UnitTest1
{
    private readonly CasterToLong _castertolong = new();
    
    [Fact]
    public void CastIntToLong_ReturnLong()
    {
        //Arrange
        ICollection<int> IntNums = new List<int> { 10, 20, 30, 40, 50 };
        ICollection<long> LongNums = new List<long> { 10L, 20L, 30L, 40L, 50L };

        //Act
        var result = _castertolong.CastIntToLong(IntNums);

        //Assert
        Assert.Equal(LongNums, result);

    }
}