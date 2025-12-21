/* Нужно сравнить 2 списка значимого типа

   var list = Enumerable.Range(0, 100).ToList();
   var list1 = Enumerable.Range(0, 90).ToList();

   //Пример вызова
   bool result = list.AreSequencesEqual(list, list1);

public bool AreSequencesEqual(
   ICollection<int> firstList, 
   ICollection<int> firstList)
*/

namespace _251222AreSequencesEqualApp;


public sealed class Comparator
{
   public bool AreSequencesEqual(ICollection<int> firstList, ICollection<int> secondList)
   {
      return firstList.SequenceEqual(secondList);
   }
}


class Program
{
   static void Main(string[] args)
   {
      var list = Enumerable.Range(0, 100).ToList();
      var list1 = Enumerable.Range(0, 90).ToList();

      var compare = new Comparator();
      
      bool result = compare.AreSequencesEqual(list, list1);

      Console.WriteLine(result);
   }
}