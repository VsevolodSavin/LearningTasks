
/*
   Написать методы, которые возвращают bool. 
   1. Метод проверяет, что всем юзерам больше 18 лет.
        public bool AllAdultUsers(ICollection<User> users)
   2. Метод проверяет условие, что есть один юзер, которому больше 18 лет.
        public bool AnyAdultUser(ICollection<User> users)
   3. Метод проверяет содержится ли в списке конкретное значение 18 лет у юзера.
        public bool ContainsAdultUser(ICollection<User> users)
   
   public sealed record User
   {
       public required Guid Id { get; init; }
       public required int Age { get; init; }
       public string? Name { get; init; }
   }
   //All, Any, Contains
 */

namespace _251128CheckForAdultApp;

public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public string? Name { get; init; }
}


public class AdultCheck
{
    public bool AllAdultUsers(ICollection<User> users)
    {
        return users
            .All(user => user.Age >= 18);
    }

    public bool AnyAdultUser(ICollection<User> users)
    {
        return users
            .Any(user => user.Age >= 18);
    }

    public bool ContainsAdultUser(ICollection<User> users)
    {
        return users
            .Select(user => user.Age)
            .Contains(18);
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

        var adultCheck = new AdultCheck();
        var result1 = adultCheck.AllAdultUsers(users);
        var result2 = adultCheck.AnyAdultUser(users);
        var result3 = adultCheck.ContainsAdultUser(users);
        Console.WriteLine($"AllAdultUsers: {result1}");
        Console.WriteLine($"AnyAdultUser: {result2}");
        Console.WriteLine($"ContainsAdultUser: {result3}");
    }
}
