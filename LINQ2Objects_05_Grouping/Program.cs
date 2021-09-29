using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2Objects_05_Grouping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> vornamen = new List<string> 
            { "Hans", "Lu", "Eva", "Anna", "Jan", "Leo", "Nora", "Ali", "Lisa", "Al", "Ben", "Lena", "Ed", "Ida" };


            // Die Vornamen nach der Länge der Vornamen gruppieren (Abfragesyntax)

            // Gruppieren benötigt kein select, den group liefert schon ein IEnumerable zurück
            Console.WriteLine("Query1:");
            var query1 = from vn in vornamen
                         group vn by vn.Length;

            // Abfrage ausführen und Resultate ausgeben
            
            foreach (var gruppe in query1)      // Iteration über die Gruppen der Abfrage
            {
                Console.Write("Die Länge ist " + gruppe.Key + ": ");

                foreach (string vn in gruppe)    // Iteration über die Vornamen einer Gruppe
                {
                    Console.Write(vn + ", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // Vornamen nach der Länge gruppieren und die Gruppen sortieren, Abfragesyntax

            Console.WriteLine("Query2:");
            var query2 = from vn in vornamen
                         orderby vn                     // Nach Vornamen sortieren
                         group vn by vn.Length into gr
                         orderby gr.Key                // Die Gruppen nach dem Key sortiern
                         select gr;                    // Select oder group by muss letzte Klausel sein!

            AusgabeQueryResults(query2);


            // Die vorherige Query in Methodensyntax und die Gruppen nach Vornamen sortieren
            // -----------------------------------------------------------------------------

            Console.WriteLine("Query3:");
            var query3 = vornamen
                .OrderBy(vn => vn)          //VOR GroupBy nach Vornamen sortieren
                .GroupBy(vn => vn.Length)
                .OrderBy(gr => gr.Key);

            AusgabeQueryResults(query3);


            // Gruppen herausfiltern die mehr als 4 Elemente beinhalten (Abfragesyntax)
            //-------------------------------------------------------------------------

            Console.WriteLine("Query4:");
            var query4 = from vn in vornamen
                         group vn by vn.Length into gr
                         where gr.Count() > 4           // entspricht der HAVING-Klausel in SQL
                         select gr;

            AusgabeQueryResults(query4);


            // Gruppen herausfiltern die mehr als 4 Elemente beinhalten (Methodensyntax)
            //-------------------------------------------------------------------------

            Console.WriteLine("Query5:");
            var query5 = vornamen
                .OrderBy(vn => vn)
                .GroupBy(vn => vn.Length)
                .Where(gr => gr.Count() > 4)
                .OrderBy(gr => gr.Key);

            AusgabeQueryResults(query5);

            Console.ReadKey();
        }

        static void AusgabeQueryResults(IEnumerable<IGrouping<int, string>> query)
        {
            foreach (var gruppe in query)
            {
                Console.Write("Die Länge ist " + gruppe.Key + ": ");

                foreach (string vorname in gruppe)
                {
                    Console.Write(" " + vorname);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
