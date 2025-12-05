/*
Необходимо из двух списков пользователей найти тех, у кого совпадает имя (с учетом регистра).
Использовать метод IntersectBy.

public sealed record User
   {
       public required Guid Id { get; init; }
       public required int Age { get; init; }
       public required string Name { get; init; }
   }

   public ICollection<User> FindUsersWithSameName(
       ICollection<User> firstGroup,
       ICollection<User> secondGroup)


*/

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("_251205SameNameTest")]


namespace _251205SameNameApp;


public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public required string Name { get; init; }
}


public sealed class FilterName
{
    public ICollection<User> FindUsersWithSameName(
        ICollection<User> firstGroup, 
        ICollection<User> secondGroup)
    {
        return firstGroup.IntersectBy(
            secondGroup
                .Select(u => u.Name),
            u => u.Name)
            .ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
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

        var filter = new FilterName();
        var filteredUsers = filter.FindUsersWithSameName(firstUserGroup, secondUserGroup);

        Console.WriteLine(filteredUsers);

        foreach (var user in filteredUsers)
        {
            Console.WriteLine(string.Join(", ", user.Name));
        }
    }
}


