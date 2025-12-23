// See https://aka.ms/new-console-template for more information

namespace _251224AreRefClassSequencesEqualApp;


public sealed class User 
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
}

public sealed class Method
{
    public bool AreSequencesEqual(ICollection<User> firstList, ICollection<User> secondList)
    {
        return firstList.Select(u => u.Id)
            .SequenceEqual(secondList.Select(u => u.Id));
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        
        IList<User> firstList = new List<User>
        {
            new User { Id = id1, Age = 25},
            new User { Id = id2, Age = 17}
        }; 
        
        IList<User> secondList = new List<User>
        {
            new User { Id = id1, Age = 25},
            new User { Id = id2, Age = 17}
        };

        var comparator = new Method();
        var result = comparator.AreSequencesEqual(firstList, secondList);
        Console.WriteLine(result);
    }
}