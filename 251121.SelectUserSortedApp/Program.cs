/*
Написать метод, который возвращает список
отсортированных по неубыванию возраста пользователей из списка users.

public sealed record User
   {
       public required Guid Id { get; init; }
       public required int Age { get; init; }
       public string? Name { get; init; }
   }
    public ICollection<User> SelectUsers(ICollection<User> users, int age)

*/

public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public string? Name { get; init; }
}

public class UserService
{
    public ICollection<User> SelectUsers(ICollection<User> users, int age)
    {
        return users
            .Where(user => user.Age >= age)
            .OrderBy(user => user.Age)
            .ToList();
    }
}


class Program
{
    static void Main(string[] args)
    {
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Иван" },
            new User { Id = Guid.NewGuid(), Age = 17, Name = "Андрей" },
            new User { Id = Guid.NewGuid(), Age = 30, Name = "Анна" },
            new User { Id = Guid.NewGuid(), Age = 20, Name = "Ирина" },
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Петр" }
        };

        var userService = new UserService();
        var result = userService.SelectUsers(users, 20);
        
        Console.WriteLine("Пользователи с возрастом >= 20 (сортировка по возрасту):");
        foreach (var user in result)
        {
            Console.WriteLine($"- {user.Name}, возраст: {user.Age}");
        }
    }
}