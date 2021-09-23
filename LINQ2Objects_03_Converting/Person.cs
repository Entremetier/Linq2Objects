using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2Objects_03_Converting
{
    public class Person
    {
        //Eigenschaften
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Beruf { get; set; }

        public Person(int id, string vorname, string nachname, string beruf)
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
            Beruf = beruf;
        }

        public static List<Person> CreateData()
        {
            List<Person> people = new List<Person>
            {
                new Person(1, "Rick", "Sanchez", "Herscher über das Universum"),
                new Person(2, "Homer", "Simpson", "Sicherheitsinspektor"),
                new Person(3, "Sterling", "Archer", "Geheimagent"),
                new Person(4, "Cyril", "Figgis", "Buchhalter"),
                new Person(5, "Lana", "Kane", "Geheimagentin")
            };

            return people;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Vorname)}={Vorname}, {nameof(Nachname)}={Nachname}, " +
                $"{nameof(Beruf)}={Beruf}}}";
        }
    }
}
