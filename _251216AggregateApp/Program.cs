// Написать метод сложения всех значений в массиве int[]. Не забыть про тесты. 

namespace _251216AggregateApp;

public sealed class Method
{
    public int? AggregateNumbers(ICollection<int>? numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            return null;
        }
        return numbers
            .Aggregate((x, y) => x + y);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var aggregator = new Method();
            
        int[] nums = { int.MaxValue, 1 };

        var result = aggregator.AggregateNumbers(nums);

        Console.WriteLine(int.MaxValue);
        Console.WriteLine(int.MinValue);
        Console.WriteLine($"Сумма: {string.Join(", ", result)}");
    }
}