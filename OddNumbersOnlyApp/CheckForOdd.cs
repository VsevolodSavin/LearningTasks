
//Написать метод, который фильтрует коллекцию чисел, возвращая только нечётные числа
//public IEnumerable<int> GetOdd(ICollection<int> nums)

namespace OddNumbersOnlyApp;
public class CheckForOdd
{
    public IEnumerable<int> GetOdd(ICollection<int> nums)
    {
        foreach (int num in nums)
        {
            if (num % 2 != 0) 
                yield return num;
        }
    }

    public static void Main()
    {
        var filter = new CheckForOdd();
        var inputList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        
        foreach (var oddNum in filter.GetOdd(inputList))
            Console.WriteLine(oddNum);
    }
}


      
