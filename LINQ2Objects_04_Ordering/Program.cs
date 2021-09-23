using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// -> Exception, weil Reverse() einen Wert vom Typ IEnumerable<char> zurückgibt.
// OrderBy benötigt aber einen Typ, der IComparable implementiert (hier string).
// Eine der Überladungen der Concat-Methode der Klasse String verkettet Auflistungen
// vom Typ IEnumerable<T> zu einem String.

namespace LINQ2Objects_04_Ordering
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
