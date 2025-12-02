/*
Сгруппировать пользователей по возрасту.
Возвращать словарь, где ключ - возраст, значение - список пользователей этого возраста

public sealed record User
   {
       public required Guid Id { get; init; }
       public required int Age { get; init; }
       public string? Name { get; init; }
   }
   
public Dictionary<int, List<User>> GroupUsersByAge(ICollection<User> users)
*/

namespace _251202GroupByApp;

public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public string? Name { get; init; }
}

public class GroupBy
{
    public Dictionary<int, List<User>> GroupUsersByAge(ICollection<User> users)
    {
        return users
            .GroupBy(x => x.Age)
            .ToDictionary(g => g.Key, g => g.ToList());
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
            new User { Id = Guid.NewGuid(), Age = 18, Name = "Анна" },
            new User { Id = Guid.NewGuid(), Age = 20, Name = "Ирина" },
            new User { Id = Guid.NewGuid(), Age = 25, Name = "Петр" }
        };

        var groupBy = new GroupBy();

        var groupedList = groupBy.GroupUsersByAge(users);
       
        foreach (var group in groupedList)
        {
            //Console.WriteLine(string.Join(", ", group.Value));
            var userNames = string.Join(", ", group.Value.Select(u => u.Name ?? "Без имени"));
            Console.WriteLine($"{group.Key}: {userNames}");
        }
    }
}