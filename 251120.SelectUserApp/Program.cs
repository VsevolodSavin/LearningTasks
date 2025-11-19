/* Написать метод, который возвращает список идентификаторов пользователей из списка users,
где возраст пользователей больше age.
public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public string? Name { get; init; }
}

public ICollection<Guid> SelectUserIds(ICollection<User> users, int age) */

public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public string? Name { get; init; }
}

public class UserService
{
    public ICollection<Guid> SelectUserIds(ICollection<User> users, int age)
    {
        return users
            .Where(user => user.Age > age)
            .Select(user => user.Id)
            .ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Alice" },
            new User { Id = Guid.NewGuid(), Age = 17, Name = "Bob" },
            new User { Id = Guid.NewGuid(), Age = 30, Name = "Charlie" }
        };
        
        var userService = new UserService();
        var result = userService.SelectUserIds(users, 20);
        
        Console.WriteLine("Пользователи старше 20 лет");
        Console.WriteLine($"Найдено пользователей: {result.Count}");
        
        var foundUsers = users.Where(u => result.Contains(u.Id));
        foreach (var user in foundUsers)
        {
            Console.WriteLine($"- {user.Name} (возраст: {user.Age})");
        }
    }
}