/* Нужно сравнить 2 списка ссылочного типа. 
public sealed record User 
   {
       public required Guid Id { get; init; }
       public required int Age { get; init; }
   }
   
   public bool AreSequencesEqual(
       ICollection<User> firstList, 
       ICollection<User> firstList)

*/


namespace _251223AreRefSequencesEqualApp;



public sealed record User 
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
}


public sealed class Comparator
{
    public bool AreSequencesEqual(ICollection<User> firstList, ICollection<User> secondList)
    {
        return firstList.Select(u => u.Age)
            .SequenceEqual(secondList.Select(u => u.Age));
        //return firstList.Count() == secondList.Count()
    }
}


class Program
{
    static void Main(string[] args)
    {
        IList<User> firstList = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25},
            new User { Id = Guid.NewGuid(), Age = 17},
            new User { Id = Guid.NewGuid(), Age = 18},
            new User { Id = Guid.NewGuid(), Age = 20},
            new User { Id = Guid.NewGuid(), Age = 95},
            new User { Id = Guid.NewGuid(), Age = 25}
        }; 
        
        IList<User> secondList = new List<User>
        {
            new User { Id = Guid.NewGuid(), Age = 25},
            new User { Id = Guid.NewGuid(), Age = 17},
            new User { Id = Guid.NewGuid(), Age = 18},
            new User { Id = Guid.NewGuid(), Age = 20},
            new User { Id = Guid.NewGuid(), Age = 95},
            new User { Id = Guid.NewGuid(), Age = 25}
        };

        var compare = new Comparator();

        var result = compare.AreSequencesEqual(firstList, secondList);

        Console.WriteLine(result);
    }
}