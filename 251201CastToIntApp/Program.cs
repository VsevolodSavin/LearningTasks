

// скастить коллекцию интов в коллекцию лонгов
// public ICollection<long> CastIntToLong(ICollection<int> list)

namespace _251201CastToIntApp;

public class CasterToLong
{
    public ICollection<long> CastIntToLong(ICollection<int> list)
    {
        return list
            .Select(i => (long)i)
            .ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var caster = new CasterToLong();
        var numbers = new List<int> { 10, 20, 30, 40, 50 };

        var cast = caster.CastIntToLong(numbers);
        Console.WriteLine(cast);
    }
}