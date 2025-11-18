
// Написать метод, который возвращает единственное нечетное число из списка.
// Если значения по фильтру нет, то метод возвращает значение по умолчанию.
// Если нечетных чисел в коллекции несколько, то метод инициирует ошибку
// public int? GetSingleOddNumber(ICollection<int>? numbers);

namespace SingleOddApp
{
    public class OddNumberFinder
    {
        public int? GetSingleOddNumber(ICollection<int>? numbers)
        {
            return numbers?
                .Where(n => n % 2 != 0)
                .Select(n => (int?)n)
                .SingleOrDefault();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var finder = new OddNumberFinder();
            
            var numbers = new List<int> { 2, 4, 7, 8, 10 };
            var result = finder.GetSingleOddNumber(numbers);
            
            Console.WriteLine($"Список: {string.Join(", ", numbers)}");
            Console.WriteLine($"Единственное нечетное число: {result?.ToString() ?? "null"}");
        }
    }
}


