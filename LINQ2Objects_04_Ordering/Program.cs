using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LINQ2Objects_04_Ordering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Eine Liste mit strings sortieren
            // ---------------------------------

            List<string> strList = new List<string> { "first", "then", "and then", "finally" };

            // Die Liste alphabetisch sortieren (Abfragesyntax)
            var sort1 = from s in strList
                        orderby s
                        select s;

            Console.WriteLine("Liste alphabetisch sortiert:");
            Console.WriteLine(string.Join(", ", sort1));
            Console.WriteLine();


            // Liste nach der länge der Elemente sortieren (Abfragesyntax)
            var sortLeng = from s in strList
                           orderby s.Length
                           select s;

            Console.WriteLine("Liste der länge nach sortiert:");
            Console.WriteLine(string.Join(", ", sortLeng));
            Console.WriteLine();


            // Liste nach dem 3. Zeichen der Elemente, alphabetisch, sortieren (Abfragesyntax)
            var sortChar = from s in strList
                           orderby s[2]
                           select s;

            sortChar = strList.OrderBy(s => s[2]);

            Console.WriteLine("Liste nach dem dritten Zeichen sortiert:");
            Console.WriteLine(string.Join(", ", sortChar));
            Console.WriteLine();


            // Liste nach den umgedrehten Elementen sortieren (die strings werden von hinten nach vorn geschrieben)
            var sortReverse = strList.OrderBy(s => s.Reverse()
            .ToString());
            // -> Exception, weil Reverse() einen Wert vom Typ IEnumerable<char> zurückgibt.
            // OrderBy benötigt aber einen Typ, der IComparable implementiert (hier string).
            // Eine der Überladungen der Concat-Methode der Klasse String verkettet Auflistungen
            // vom Typ IEnumerable<T> zu einem String.


            var sortReverse2 = strList
                .OrderBy(s => string.Concat(s.Reverse()))
                .Select(s => string.Concat(s.Reverse()));

            Console.WriteLine("Liste umgedreht sortiert:");
            foreach (var item in sortReverse2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            //Liste nach dem letzten und dem ersten Zeichen der Elemente sortieren
            var lastAndFirstChar = strList
                .OrderBy(s => s.Last())
                .ThenBy(s => s.First());

            Console.WriteLine("Nach dem letzten und dem ersten Zeichen sortiert:");
            Console.WriteLine(string.Join(", ", lastAndFirstChar));
            Console.WriteLine();



            // Ein Autoarray sortieren
            // ---------------------------------

            Auto[] autoArray = new Auto[]
            {
               new Auto("Opel Corsa" ,2012),
               new Auto("VW Transporter", 2014),
               new Auto("Audi A6", 2015),
               new Auto("VW Caddy", 2015),
               new Auto("Skoda Octavia" , 2018),
               new Auto("VW Golf", 2019),
               new Auto("Ford Fiesta", 2012),
               new Auto("VW Polo", 2014)
            };

            // nach Modell sortieren

            var sortedCars = autoArray
                .OrderBy(a => a.Modell);


            Console.WriteLine("Autos nach Modell sortiert:");
            foreach (Auto item in sortedCars)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // nach Baujahr absteigend und dann nach Modell sortieren

            var sortedCarsM = autoArray
                .OrderByDescending(a => a.Baujahr)
                .ThenBy(a => a.Modell);


            Console.WriteLine("Autos nach Baujahr absteigend und Modell sortiert (Methodensyntax):");
            Console.WriteLine(string.Join("\n", sortedCarsM));
            Console.WriteLine();

            // ODER in Abfragesyntax

            var sortedCarsA = from a in autoArray
                              orderby a.Baujahr descending,
                              a.Modell
                              select a;

            Console.WriteLine("Autos nach Baujahr absteigend und Modell sortiert (Abfragesyntax):");
            Console.WriteLine(string.Join("\n", sortedCarsA));
            Console.WriteLine();



            Console.ReadKey();
        }
    }
}
