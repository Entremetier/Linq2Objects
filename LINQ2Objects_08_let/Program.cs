using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Mit dem let-Operator kann man das Resultat eines Ausdrucks in einer neuen Bereichs-
 * variablen speichern. Auf die Variable kann dann in nachfolgenden Klauseln zugegriffen
 * werden.
 */

namespace LINQ2Objects_08_let
{
    class Program
    {
        static void Main(string[] args)
        {
            //            List<Student> studenten = new List<Student>
            //{
            //   new Student("Klaus", "Hafner", 131, new List<int> {97, 92, 81, 60}),
            //   new Student("Suzie", "Heger", 132, new List<int> {75, 84, 91, 39}),
            //   new Student("Jakob", "Nachbargauer", 133, new List<int> {38, 54, 65, 42}),
            //   new Student("Joseph", "Dreier", 134, new List<int> {97, 89, 85, 82}),
            //   new Student("Sarah", "Hellwagner", 135, new List<int> {35, 72, 91, 70}),
            //   new Student("Gerlinde", "Meisterhofer", 136, new List<int> {68, 79, 88, 92}),
            //   new Student("Günther", "Lagler", 137, new List<int> {99, 81, 84, 77}),
            //   new Student("Peter", "Wanisch", 138, new List<int> {96, 94, 83, 93})
            //};



            //            string[] gedicht =
            //            {
            //   "Ein Wiesel saß auf einem Kiesel inmitten Bachgeriesel.",
            //   "Wisst ihr weshalb?",
            //   "Das Mondkalb verriet es mir im stillen:",
            //   "Das raffinierte Tier tat's um des Reimes willen."
            //};

            // Übung:
            // Alle Studenten in 100er-Gesamtpunktezahlgruppen (0-99, 100-199, 200-299, ...)
            // zusammenfassen und nach den Gruppen, und innerhalb der Gruppen nach der
            // Gesamtpunktezahl, jeweils absteigend sortieren.
            //
            // Der Output sollte wie folgt aussehen:
            //
            // 300 - 399:
            //     Peter Wanisch             366 Punkte
            //     Joseph Dreier             353 Punkte
            //     Günther Lagler            341 Punkte
            //     Klaus Hafner              330 Punkte
            //     Gerlinde Meisterhofer     327 Punkte
            //
            // 200 - 299:
            //     Suzie Heger               289 Punkte
            //     Sarah Hellwagner          268 Punkte
            //
            // 100 - 199:
            //     Jakob Nachbargauer        199 Punkte
            // -----------------------------------------------------------------------------
        }
    }
}
