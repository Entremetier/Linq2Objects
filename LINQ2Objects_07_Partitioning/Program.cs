using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Die Partitioning-Operatoren, die manchmal auch als Paging-Operatoren bezeichnet
 * werden oder den Filtering-Operatoren zugerechnet werden, sind:
 * 
 *    Take        liefert die ersten x Elemente zurück und verwirft den Rest.
 *    Skip        ignoriert die ersten x Elemente liefert den Rest zurück.
 *    TakeWhile   gibt Elemente aus einer Sequenz zurück, solange ein Kriterium
 *                true ist.
 *    SkipWhile   ignoriert Elemente aus einer Sequenz, solange ein Kriterium true ist.
 * 
 * Die Partitioning-Operatoren existieren nur in Methodensyntax.
 */

namespace LINQ2Objects_07_Partitioning
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, -2, 3, 0, -4, 5, -5, 6 };


            // Beispiele zu Take
            // -----------------

            // Die ersten 4 Elemente in nums

            Console.WriteLine("Die ersten 4 Elemente in nums:");

            foreach (int num in nums.Take(4))
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Die ersten 3 positiven Elemente in nums ermitteln

            Console.WriteLine("Die ersten 3 positiven Elemente in nums ermitteln");

            var query1 = (from n in nums
                          where n > 0
                          select n)
                          .Take(3);

            foreach (int num in query1)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine();


            // Beispiele zu Skip
            // -----------------

            // nums ohne den ersten beiden Elementen

            Console.WriteLine("nums ohne den ersten beiden Elementen:");

            foreach (int num in nums.Skip(2))
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // 4 ungerade Werte in nums ohne den ersten beiden ungeraden Elementen

            Console.WriteLine("4 ungerade Werte in nums ohne den ersten beiden ungeraden Elementen:");

            var query2 = nums
                .Where(n => n % 2 != 0)     // ODER .Where(n => Math.Abs(n %2) == 1)
                .Skip(2)
                .Take(4);

            foreach (int num in query2)
            {
                Console.Write(num + " ");

            }
            Console.WriteLine();
            Console.WriteLine();


            // Beispiel zu TakeWhile
            // ---------------------

            // Alle Elemente in nums, die vor der ersten 0 stehen

            Console.WriteLine("Alle Elemente in nums, die vor der ersten 0 stehen:");

            // var query3 = nums
            //    .TakeWhile(x => x != 0);

            // ODER

            foreach (int num in nums.TakeWhile(x => x != 0))
            {
                Console.Write(num + " ");

            }
            Console.WriteLine();
            Console.WriteLine();


            // Beispiel zu SkipWhile
            // ---------------------

            // Die ersten 3 Elemente in nums, ab der ersten 0

            Console.WriteLine("Die ersten 3 Elemente in nums, ab der ersten 0:");

            var query4 = nums
                .SkipWhile(x => x != 0)
                .Take(3);

            foreach (int num in query4)
            {
                Console.Write(num + " ");

            }
            Console.WriteLine();
            Console.WriteLine();



            Console.ReadKey();
        }
    }
}
