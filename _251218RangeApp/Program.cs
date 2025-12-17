// Необходимо написать метод постраничного вывода объектов, который принимает на вход два параметра Take и Skip
// Реализовать его с помощью срезов для ProductRecord списка

namespace _251218RangeApp;

public record ProductRecord(int Id, string Name, decimal Price);

public sealed class Method
{
    public ProductRecord[] GetPage(List<ProductRecord> source, int skip, int take)
    {
        int start = skip;
        int end = skip + take;
            
        return source.ToArray()[start..end];
    }
}

class Program
{
    static void Main(string[] args)
    {
        var ranger = new Method();
            
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };

        var result = ranger.GetPage(products, skip: 1, take: 0);
        
        foreach (var product in result)
        {
            Console.WriteLine($"{product.Name}");
        }
    }
}