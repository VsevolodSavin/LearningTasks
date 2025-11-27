
// Написать метод, который меняет порядок элементов c помощью Reverse.

public class ElementReverse
{
    public ICollection<int> ReverseUserIds(ICollection<int>? userIds)
    {
        if (userIds == null)
        {
            return [];
        }
        return userIds
            .Reverse()
            .ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var elements = new List<int> { 2, 4, 7, 8, 10 };
        var reverser = new ElementReverse();
        var result = reverser.ReverseUserIds(elements);
        Console.WriteLine(string.Join(", ", result));
    }
} 