
using _251205SameNameApp;
namespace _251205SameNameTest;

public class UnitTest1
{
    private readonly FilterName _filter = new();
    
    [Fact]
    public void GetUsersWithSameName_ReturnCommonNamedUsers()
    {
        //Arrange
        IList<User> firstUserGroup = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Иван" },
            new User { Id = Guid.NewGuid(), Age = 17, Name = "Андрей" },
            new User { Id = Guid.NewGuid(), Age = 18, Name = "Анна" },
            new User { Id = Guid.NewGuid(), Age = 20, Name = "Ирина" },
            new User { Id = Guid.NewGuid(), Age = 95, Name = "Ирина" },
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Петр" }
        };

        IList<User> secondUserGroup = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Анна" },
            new User { Id = Guid.NewGuid(), Age = 17, Name = "Василий" },
            new User { Id = Guid.NewGuid(), Age = 18, Name = "Дмитрий" },
            new User { Id = Guid.NewGuid(), Age = 20, Name = "Владимир" },
            new User { Id = Guid.NewGuid(), Age = 95, Name = "Владислав" },
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Петр" }
        };
        
        IList<User> expectedUsers = new List<User>
        {
            firstUserGroup[2], firstUserGroup[5]
        };
        
        //Act
        var obtainedUsers = _filter.FindUsersWithSameName(firstUserGroup, secondUserGroup);
            
        //Assert
        Assert.Equal(expectedUsers, obtainedUsers);

    }
}