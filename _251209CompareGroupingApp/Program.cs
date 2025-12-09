// Сравнение ToDictionary и ToLookup при группировке пользователей по возрасту
// Необходимо создать два метода для группировки коллекции пользователей по их возрасту (Age).

namespace _251209CompareGroupingApp;
public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public required string? Name { get; init; }
}


public sealed class Methods
{
    // Группирует пользователей по возрасту, используя ToDictionary.
    // Ключ - возраст (Age), значение - первый пользователь с таким возрастом.
    public Dictionary<int, User> GroupByAgeUsingDictionary(ICollection<User> users)
    {
        return users
            .DistinctBy(x => x.Age)
            .ToDictionary(x => x.Age, x => x);
    }
    

    // Группирует пользователей по возрасту, используя ToLookup.
    // Ключ - возраст (Age), значение - последовательность всех пользователей этого возраста.
    public ILookup<int, User> GroupByAgeUsingLookup(ICollection<User> users)
    {
        return users
            .ToLookup(x => x.Age, x => x);
    }
}


public static class Program
{
    public static void Main()
    {
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Анна" },
            new User { Id = Guid.NewGuid(), Age = 30, Name = "Иван" },
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Мария" },
            new User { Id = Guid.NewGuid(), Age = 30, Name = "Петр" },
            new User { Id = Guid.NewGuid(), Age = 35, Name = "Ольга" }
        };

        var methods = new Methods();
        
        Console.WriteLine("Группировка с ToDictionary:");
        var dictResult = methods.GroupByAgeUsingDictionary(users);
        foreach (var item in dictResult)
        {
            Console.WriteLine($"Возраст: {item.Key}, Имя: {item.Value.Name}");
        }

        Console.WriteLine("Группировка с ToLookup:");
        var lookupResult = methods.GroupByAgeUsingLookup(users);
        foreach (var group in lookupResult)
        {
            Console.WriteLine($"Возраст: {group.Key}");
            foreach (var user in group)
            {
                Console.WriteLine($"{user.Name}");
            }
        }
    }
}