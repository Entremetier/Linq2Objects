using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2Objects_08_let
{
    public class Student
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Id { get; set; }
        public List<int> Punkte { get; set; }

        public Student(string vorname, string nachname, int id, List<int> punkte)
        {
            Vorname = vorname;
            Nachname = nachname;
            Id = id;
            Punkte = punkte;
        }
    }
}
