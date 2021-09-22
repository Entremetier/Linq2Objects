using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Aggregationsoperatoren liefern einen skalaren Wert zurück, im Allgemeinen einen
 * numerischen. Die am häufigsten genutzten Aggregationsoperatoren sind Count, Min,
 * Max, Sum und Average.
 * 
 * Elementoperatoren liefern genau 1 Element (darum heißen sie Elementoperatoren) zurück. Elementoperatoren sind z.B.
 * First, Last, ElementAt, Single und die zugehörigen ...OrDefault Operatoren.
 * 
 * Abfragen mit Aggregations- oder Elementoperatoren werden SOFORT (ohne foreach-
 * Schleife) ausgeführt, um das Resultat zu erhalten.
 */

namespace LINQ2Objects_02_AggregationUndElemente
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -2, 5, -6, -5, -3, 2, 8, 4, 3, -7, 10 };

            Console.WriteLine("Alle Werte in nums:");
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            //Aggregationsoperatoren
            //-----------------------

            //Abfrage die die positiven geraden Werte in nums zurückliefert (Abfragesyntax)
            Console.WriteLine("Positive gerade Werte in nums:");
            var posEvenNums = from n in nums
                              where n > 0 && n % 2 == 0
                              select n;

            //Hier wird die Auswertung sofort gemacht und das Ergebnis wird in die var gespeichert
            //var posEvenNums = (from n in nums
            //                   where n > 0 && n % 2 == 0
            //                   select n).Sum();

            foreach (var item in posEvenNums)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Aggregationsoperatoren liefern einen skalaren Wert zurück:");
            Console.WriteLine("Anzahl: " + posEvenNums.Count());
            Console.WriteLine("Minimum: " + posEvenNums.Min());
            Console.WriteLine("Maximum: " + posEvenNums.Max());
            Console.WriteLine("Summe: " + posEvenNums.Sum());
            Console.WriteLine("Average: " + posEvenNums.Average());


            //Elementoperatoren
            Console.WriteLine("\nNegative ungerade Werte in nums:");
            var negOddNums = from n in nums
                              where n < 0 && n % 2 == -1    // -1 weil negative Zahlen
                              select n;

            foreach (var item in negOddNums)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Elementoperatoren liefern genau 1 Element zurück:");
            Console.WriteLine("Erstes Element: " + negOddNums.First());
            Console.WriteLine("Letztes Element: " + negOddNums.Last());
            Console.WriteLine("2. Element: " + negOddNums.ElementAt(1));


            //Wird eine Query mit Aggregations- oder Elementoperatoren verwendet, dann wird die Abfrage SOFORT (ohne foreach)
            //ausgeführt, um das Resultat zu erhalten.


            //Query die die Anzahl der Werte in nums zurückliefert, die > -5 und  <= 5 sind
            var anzahl = (from n in nums
                          where n > -5 && n <= 5
                          select n)
                          .Count();


            //...OrDefault()
            //--------------

            Console.WriteLine("\nAnzahl Werte die > -5 und  <= 5 sind: " + anzahl);

            Console.WriteLine("\n1.Wert > 5 in nums: " + nums.First(n => n > 5));

            //Wenn keiner der Werte übereinstimmt kommt es zu einer InvalidOperationException, weil es kein Ergebnis gibt.
            //Um das zu verhindern verwendet man den ...OrDefault Operator.
            //Console.WriteLine("\n1.Wert > 5 in nums: " + nums.First(n => n > 10));    



            // Single und SingleOrDefault
            // --------------------------


            Console.WriteLine("\nEinziger Wert > 9 in nums: " + nums.Single(n => n > 9));
            // Console.WriteLine("\nEinziger Wert > 7 in nums: " + nums.Single(n => n > 7));
            // Das obige Statement löst eine InvalidOperaException aus, weil es MEHR als 1 Ergebnis gibt.
            // Auch wenn man SingleOrDefault verwendet


            //Console.WriteLine("\nEinziger Wert > 7 in nums: " + nums.SingleOrDefault(n => n > 7));


            Console.WriteLine("Einziger Wert > 10 in nums: " + nums.SingleOrDefault(n => n > 10));

            // Im Gegensatz zu First garantiert Single, dass es nur EIN Ergebnis gibt.
            // Gibt es mehrere Ergebnisse, dann wird, auch bei SingleOrDefault, eine Exception geworfen.
            // Single wird bei der Abfrage auf IDs und Primärschlüssel verwendet.



            Console.ReadKey();
        }
    }
}
