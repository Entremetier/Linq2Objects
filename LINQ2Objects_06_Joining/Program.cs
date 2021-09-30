using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2Objects_06_Joining
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Id = 1, Name = "Kara Ben Nemsi" };
            Person p2 = new Person { Id = 2, Name = "Daktari" };
            Person p3 = new Person { Id = 3, Name = "Don Quijote" };

            Tier t1 = new Tier { Name = "Rosinante", OwnerId = 3 };
            Tier t2 = new Tier { Name = "Clarence", OwnerId = 2 };
            Tier t3 = new Tier { Name = "Rih", OwnerId = 1 };
            Tier t4 = new Tier { Name = "Judy", OwnerId = 2 };

            List<Person> personen = new List<Person> { p1, p2, p3 };
            List<Tier> tiere = new List<Tier> { t1, t2, t3, t4 };


            // Personen/Tier-Freundschaften (Beziehungen) , Personen und Tiere
            // die zusammengehören)
            // ---------------------------------------------------------------

            Console.WriteLine("Personen/Tier-Freundschaften:");
            var q1 = from p in personen
                     join t in tiere on p.Id equals t.OwnerId
                     select new { Person = p.Name, Tier = t.Name }; // neuer anonymer Typ

            Console.WriteLine("q1");
            foreach (var freunde in q1)
            {
                Console.WriteLine(freunde);
            }
            Console.WriteLine();

            // ODER

            var q2 = from p in personen
                     from t in tiere
                     where p.Id == t.OwnerId
                     select $"{p.Name} hat {t.Name} als Freund";

            Console.WriteLine("q2");
            foreach (string freunde in q2)
            {
                Console.WriteLine(freunde);
            }
            Console.WriteLine();


            // Das obige Beispiel in Methodensyntax
            // ------------------------------------

            var q3 = personen       // personen = äußere Sequenz
                .Join
                (
                tiere,              // tiere = innere Sequenz
                p => p.Id,          // äußere Schlüssel 
                t => t.OwnerId,     // innerer Schlüssel
                // (p, t) in Klammern weil es sich um zwei Datentypen handelt
                (p, t) => new { Person = p.Name, Tier = t.Name }    // Ergebnisselektor                                                     
                );

            Console.WriteLine("q3");
            foreach (var item in q3)
            {
                Console.WriteLine($"{item.Tier} gehört zu {item.Person}");
            }
            Console.WriteLine();



            Console.ReadKey(); 
        }
    }
}
