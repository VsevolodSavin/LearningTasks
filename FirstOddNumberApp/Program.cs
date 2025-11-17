
// Написать метод, который возвращает первое нечетное число из списка.
//public int? GetFirstOddNumber(ICollection<int>? numbers)

namespace FirstOddNumberApp
{
    public class CheckForFirstOdd
    {
        public int? GetFirstOddNumber(ICollection<int>? numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return null;
            }

            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    return number;
                }
            }

            return null;
        }

        static void Main(string[] args)
        {
            var findfirstodd = new CheckForFirstOdd();
            var numbers = new List<int> { 2, 4, 4, 8, 4, 1 };
            Console.WriteLine($"{string.Join(", ", numbers)}; Значение: {findfirstodd.GetFirstOddNumber(numbers)}");
        }
    }
}