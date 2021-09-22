using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* LINQ (Language Integrated Query)
 * 
 * LINQ ist eine Bibliothek von Erweiterungsmethoden, die verwendet wird, um Abfragen
 * (Queries) in C#-Syntax gegen verschiedene Datenquellen auszuführen. Abhägig von der
 * Datenquelle spricht man von LINQ to Objects, LINQ to Entities, LINQ to XML etc.
 * 
 * Damit LINQ verwendet werden kann, muss die Datenquelle das Interface IEnumerable
 * oder IEnumerable<T> implementieren. Eine Klasse, die IEnumerable oder IEnumerable<T>
 * implementiert, unterstützt Aufzählung (Enumeration). Das bedeutet, dass auf den
 * Inhalt der Aufzählung der Reihe nach, Element für Element zugegriffen werden kann.
 * Zum Beispiel implementieren Arrays und Listen das Interface IEnumerable<T>, wobei T
 * den Datentyp der Elemente der Aufzählung angibt.
 * 
 * Um LINQ einfacher zu verwenden, bindet man den Namespace System.Linq mit using ein.
 * 
 * Eine Abfrage spezifiziert, welche Daten von der Datenquelle abgefragt werden. Das
 * Abfragen von Daten erfolgt in 2 Schritten:
 *    1. Abfrage erstellen
 *    2. Abfrage ausführen
 * 
 * Abfragen werden in einer Abfragevariablen gespeichert. Eine Abfrage kann öfter
 * ausgeführt werden. Die Ausführung der Abfrage erfolgt nicht beim Erstellen der
 * Abfrage, sondern erst, wenn die Ergebnismenge benötigt wird, z.B. in einer
 * foreach-Schleife. Bei jedem Schleifendurchlauf wird ein Element des Abfrage-
 * Ergebnisses in der Iterationsvariablen bereitgestellt. Verschiedene LINQ-Operatoren
 * wie z.B. die Aggregations-, Element- und Konvertierungsoperatoren veranlassen die
 * Ausführung der Abfrage sofort (siehe Projekt LINQ2Objects_02_AggregationUndElemente).
 * 
 * LINQ-Abfragen kann man in 2 Varianten erstellen.
 * 
 * Es gibt die Abfragesyntax, die an die Sprache SQL angelehnt ist und daher für viele
 * Programmierer leicht und rasch zu erlernen ist.
 * 
 * LINQ ist aber in Form von Erweiterungsmethoden implementiert und der C# Compiler
 * übersetzt die Abfragesyntax in eine Serie von Aufrufen von Erweiterungsmethoden. An
 * die Erweiterungsmethoden werden Argumente in Form von Lambda-Ausdrücken übergeben.
 * 
 * Die Methodensyntax ist kompakt und anderem C# Code ähnlich. Sie ist auch umfassend.
 * Nicht alles, was in Methodensyntax verfügbar ist, kann auch in Abfragesyntax
 * formuliert werden (siehe auch Projekt LINQ2Objects_02_AggregationUndElemente).
 */

namespace Linq2Objects_01_Grundlagen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Eine einfache Query
            //------------------------------

            int[] nums = { 1, 2, 3, 4, -5, 78, 99, -11 };
            Console.WriteLine("Alle Werte in der Liste:");
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            //Eine Query die nur die positiven Werte zurückliefert.
            //positivNum ist die Abfragevariable (Query Variable).
            var positivNum = from n in nums
                             where n > 0
                             select n;

            // Der Abfragevariablen wird der Abfrageausdruck (Query Expression) zugewiesen.
            // Eine Abfrage beginnt immer mit dem Schlüsselwort from.
            // Die from-Klausel definiert eine Bereichsvariable n (Range Variable), der die
            // einzelnen Elemente der Datenquelle nums (Auflistung) zugewiesen werden.
            // Der Typ der Bereichsvariablen entspricht dem Typ der Elemente der Datenquelle.

            Console.WriteLine("Positive Werte in nums:");

            //Die Query mit einer foreach ausführen und die Abfrageergebnisse anzeigen.
            foreach (int item in positivNum)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            //ODER

            //positivNum.ToList()
            //    .ForEach(x => Console.WriteLine(x));


            //Die Query ein weiteres mal ausführen
            //----------------------------------------------

            nums[1] = 128; //Datenquelle ändern
            Console.WriteLine("nums[1] wurde auf -128 geändert!");
            Console.WriteLine();

            //Die Query ein weiters mal ausführen
            foreach (var item in positivNum)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");


            //Methodensyntax
            //--------------------------------------------

            //Eine Query die nur die negativen Werte zurückliefert, in Abfragesyntax.
            var negativNumA = from n in nums
                              where n < 0
                              select n;


            Console.WriteLine("Negative Werte ausgeben:");
            //Eine Query die nur die negativen Werte zurückliefert, in Methodensyntax.
            //Im Methodensyntax kann das Select-Statement weggelassen wird
            var negativNumB = nums.Where(n => n < 0)/*.Select(n => n)*/;

            foreach (var item in negativNumB)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            //Die Sequenz, die von Where() zurückgegeben wird, enthält bereits das Ergebnis. Man hätte auch 
            //"var negativNumB = nums.Where(n => n < 0);" schreiben können.



            //Beispiel: LINQ-Abfrage in Abfrage- und Methodensyntax die die Quadrate der ungeraden Zahlen in nums liefert
            //-----------------------------------------------------------------------------------------------------

            //Abfragesyntax

            var queryA = from n in nums
                         where n % 2 != 0   // ACHTUNG BEI NEGATIVEN WERTEN (n % 2 == 1 funktioniert nicht)
                         select n * n;

            Console.WriteLine("Quadrate der ungeraden Zahlen in nums, Abfragesyntax");
            foreach (var item in queryA)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");


            //Methodensyntax

            //Math.Abs gibt die Absolute Zahl zurück
            var queryM = nums
                .Where(n => Math.Abs(n % 2) == 1)
                .Select(n => n * n);

            Console.WriteLine("Quadrate der ungeraden Zahlen in nums, Methodensyntax");
            foreach (var item in queryM)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");


            Console.ReadKey();
        }
    }
}
