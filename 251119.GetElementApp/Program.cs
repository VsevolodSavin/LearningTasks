
//Написать метод, который возвращает элемент коллекции по указанному индексу с обработкой граничных случаев.
//public int? GetElementAtOrDefault(ICollection<int>? collection, int index);

public class ElementGetter
{
    public int? GetElementAtOrDefault(ICollection<int>? collection, int index)
    {
        return collection?.ElementAtOrDefault(index);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var elementGetter = new ElementGetter();
        var numbers = new List<int> { 10, 20, 30, 40, 50 };
        
        var result = elementGetter.GetElementAtOrDefault(numbers, -2);
        
        Console.WriteLine($"Элемент по индексу 2: {result}");
    }
}