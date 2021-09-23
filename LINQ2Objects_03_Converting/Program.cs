using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Jede Query, die eine Sequenz von Elementen zurückliefert, liefert diese als
 * IEnumerable<T> zurück. Es kann schwierig sein, mit diesem Typ weiter zu arbeiten.
 * Mit Hilfe der Konvertierungsoperatoren ToList, ToArray, ToDictionary und TLookup
 * kann IEnumerable<T> in eine Liste List<T>, ein Array T[], ein 
 * Dictionary<TKey,TValue> oder ein Lookup<TKey,TElement> umgewandelt werden.
 * 
 * Die Konvertierungsoperatoren haben eine sofortige Ausführung der Abfrage zur Folge.
 * 
 * Hinweis:
 * Der Unterschied zwischen Dictionary und Lookup besteht darin, dass ein Dictionary
 * einzelne Werte einem Schlüssel zuordnet, während ein Lookup eine Collection von
 * Werten einem Schlüssel zuordnet (z.B. Ortsnamen, die mit A, B, C etc. beginnen).
 */

namespace LINQ2Objects_03_Converting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { -2, 5, -6, -5, -3, 2, 8, 4, 3, -7, 10 };

            //ToArray
            //--------

            var query = from n in nums
                         where n < 0
                         select n * 10;

            int[] arrNeg10Times = query.ToArray(); // Abfrage wird hier ausgeführt!

            Console.WriteLine("arrNeg10Times:");

            foreach (var item in arrNeg10Times)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            // ToList
            // ------

            //List<int> ints = (from n in nums
            //                  where n < 0
            //                  select n * 10).ToList();

            List<int> listPos10Times = nums
                .Where(n => n > 0)
                .Select(n => n * 10)
                .ToList();

            Console.WriteLine("\nints2:");

            Console.WriteLine(string.Join(", ", listPos10Times));
            Console.WriteLine();


            // ToDictionary
            // ------------

            List<Person> people = Person.CreateData();

            Dictionary<int, Person> persDict = people.Where(n => n.Nachname.StartsWith("S"))
                .ToDictionary(n => n.Id);

            foreach (var item in persDict)
            {
                Console.WriteLine("Key: " + item.Key + ", Person" + item.Value);
            }

            Console.ReadKey();
        }
    }
}
