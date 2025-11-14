//Написать метод, который фильтрует коллекцию чисел, возвращая только положительные числа
//public ICollection<int> GetPositiveNumbers(ICollection<int> numbers)

namespace PositiveNumbersOnlyApp
{
    public class CheckForPositive
    {
        public ICollection<int> GetPositiveNumbers(ICollection<int> numbers)
        {
            var positiveList = new List<int>();
            foreach (int num in numbers)
            {
                if (num > 0)
                    positiveList.Add(num);
            }
            return positiveList;
        }
        public static void Main(string[] args)
        {
            var checker = new CheckForPositive();
            var allNumbers = new List<int> { -2, -1, 0, 1, 2, 3 };
            
            var positiveNumbers = checker.GetPositiveNumbers(allNumbers);

            foreach (var num in positiveNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}