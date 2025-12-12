// See https://aka.ms/new-console-template for more information

namespace _251212UserActionsApp;

public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public required string? Name { get; init; }
}


public sealed class Methods
{ 
    //Создать метод, который добавляет нового пользователя в конец коллекции.
    //Использовать метод Append. Сравнить его работу с ручным добавлением через List.Add()
    public ICollection<User> AddUserAtEnd(ICollection<User> users, User newUser)
    {
        return users
            .Append(newUser)
            .ToList();
    }
    
    //Объединить две коллекции пользователей в одну
    //Использовать метод Concat. Сравнить его работу с ручным объединением через AddRange()
    public ICollection<User> MergeUserCollections(ICollection<User> firstGroup, ICollection<User> secondGroup)
    {
        return firstGroup
            .Concat(secondGroup)
            .ToList();
    }
    
    //Создать метод, который добавляет нового пользователя в начало коллекции.
    //Использовать метод Prepend. Сравнить его работу с ручной вставкой через Insert()
    public ICollection<User> AddUserAtBeginning(ICollection<User> users, User newUser)
    {
        return users
            .Prepend(newUser)
            .ToList();
    }

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

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Age = 30,
            Name = "Анатолий"
        };

        var method = new Methods();
        var appendedUsers = method.AddUserAtEnd(firstUserGroup, newUser);

        foreach (var user in appendedUsers)
        {
            Console.WriteLine($"  {user.Name}, {user.Age}");
        }
    }
}